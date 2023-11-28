function DeleteWorker(e) {
    var data = this.dataItem($(e.currentTarget).closest("tr"));
    var idLabour = $("#IdLabour").text()
    var jsonObject = {
        IdWorker: data.Id,
        IdLabour: idLabour
    };
    var jsonString = JSON.stringify(jsonObject);
    $.ajax({
        async: false,
        type: "POST",
        url: "/api/apihome/apiworkers/DeleteWorkers",
        dataType: "json",
        data: { json: jsonString },
        success: function (result) {
            console.dir(result);
            alert(result);
        },
        error: function (error) {
            // Handle any errors here
            console.error(error);
        }
    })
    reloadGridWorkers();
}
function reloadGridWorkers() {
    var grid = $("#GridWorkers").data("kendoGrid");
    grid.dataSource.read();
}