function reloadGridCheckList() {
    return new Promise((resolve) => {
        var grid = $("#GridCheckList").data("kendoGrid");
        grid.dataSource.read();
        grid.refresh();
        resolve();
    });
}