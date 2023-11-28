
function onDataBoundGridWorkers(e) {
    e.sender.one("dataBound", function () {
        e.sender.dataSource.read();
    });
}
function ShowModal() {
    $('#AddLabour').modal('show');
}
function ModalClose() {
    DeleteDefaultLabour();
    $('#AddLabour').modal('hide');
    $('.modal-backdrop').remove();
}
function AddLabour(e) {
    //var data = this.dataItem($(e.currentTarget).closest("tr"));
    CreateDefaultLabour();
    reloadGridWorkers();
    reloadGridCheckList();
    ShowModal();
}
function CreateDefaultLabour() {
    $.ajax({
        async: false,
        type: "Post",
        url: "/api/apihome/apilabour/CreateDefaultLabour",
        success: function (id) {
            document.getElementById("IdLabour").innerHTML = id;
            var idLabour = $("#IdLabour").text();
        },
        error: function (error) {
            // Handle any errors here
            console.error(error);
        }
    })
}
function DeleteDefaultLabour() {
    var idLabour = $("#IdLabour").text();
    $.ajax({
        async: false,
        type: "Post",
        url: "/api/apihome/apilabour/DeleteDefaultLabour",
        dataType: "json",
        data: { idLabour: idLabour },
        success: function (result) {
           
        },
        error: function (error) {
            // Handle any errors here
            console.error(error);
        }
    })
}

function Save() {
    //var data = {
    //    "Company": $("#LabourCompany").text(),
    //    "Describe": $("#LabourDescribe").text(),
    //    "DateDeadline": $("#DateDeadline").data("kendoDatePicker").value(),
    //    "IdPriority": $("#Priorita").data("kendoDropDownList").value(),
    //    "IdStatus": $("#Status").data("kendoDropDownList").value(),
    //    "IdLabour": $("#IdLabour").text()
    //}; 

    var data = {
        "Company": "ss",
        "Describe": $("#LabourDescribe").text(),
        "DateDeadline": $("#DateDeadline").data("kendoDatePicker").value(),
        "IdPriority": $("#Priorita").data("kendoDropDownList").value(),
        "IdStatus": $("#Status").data("kendoDropDownList").value(),
        "IdLabour": $("#IdLabour").text()
    }; 
    console.dir(data);
    $.ajax({
        type: "Post",
        url: "/api/apihome/apilabour/SaveDefaultLabour",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data),
        success: function (result) {
        
        },
        error: function (error) {
            // Handle any errors here
            console.error(error);
        },
        async:false
    })
}
function additionalDataGridWorkers() {// idlabour send to controller
    var idLabour = $("#IdLabour").text()
    return {
        idLabour: idLabour
    };
}
function RowIdGridChecklist(e) {//id o row in ChecklistGrid
    var data = this.dataItem($(e.currentTarget).closest("tr"));
    return {
        id: data.Id
    };
}



