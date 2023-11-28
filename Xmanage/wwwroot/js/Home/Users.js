//modalAddLabour
function AddWorker(e) {
    var data = this.dataItem($(e.currentTarget).closest("tr"));
    var idLabour = $("#IdLabour").text()
    var jsonObject = {
        IdUser: data.Id,
        IdLabour: idLabour
    };
    var jsonString = JSON.stringify(jsonObject);
    $.ajax({
        async: false,
        type: "Post",
        url: "/api/apihome/apiusers/addworker",
        dataType: "json",
        data: { json: jsonString },
        success: function (result) {

        },
        error: function (error) {
            // Handle any errors here
            console.error(error);
        }
    })
    reloadGridWorkers();
    reloadGridCheckList();
}
function onDataBoundGridUsers(e) {
    e.sender.one("dataBound", function () {
        e.sender.dataSource.read();
    });
}