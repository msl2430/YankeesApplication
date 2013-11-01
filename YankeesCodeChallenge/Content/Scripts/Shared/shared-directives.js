YankeesApp.directive('jqueryDatatableAsync', function () {
    return function (scope, element, attrs) {
        // apply DataTable options, use defaults if none specified by user        
        var options = {
                "bJQueryUI": true,
                "bServerSide": true,
                "bProcessing": false,
                "iDisplayLength": 10,
                "bAutoWidth": false,
                "bFilter": true,                
                "sAjaxSource": attrs.tableDataSource,
                "sPaginationType": "full_numbers",
                "fnServerData": function (sSource, aoData, fnCallback) {
                    var request = new Object();
                    request.tableOptions = aoData;
                    request.optionalFilter = scope.$eval(attrs.optionalFilter);
                    $.ajax(
                        {
                            type: 'POST',
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            url: sSource,
                            data: JSON.stringify(request),
                            success: function (data) {
                                fnCallback(JSON.parse(data));
                            }
                        });
                }                
            };
        
        // define columns
        if (attrs.aoColumns) {
            options["aoColumns"] = scope.$eval(attrs.aoColumns);
        }

        // aoColumnDefs is dataTables way of providing fine control over column config
        if (attrs.aoColumnDefs) {
            options["aoColumnDefs"] = scope.$eval(attrs.aoColumnDefs);
        }
        
        if (attrs.oLanguage) {
            options["oLanguage"] = scope.$eval(attrs.oLanguage);
        }

        if (attrs.callbackFunction) {
            options["fnDrawCallback"] = scope.$eval(attrs.callbackFunction);
        }

        // apply the plugin
        var dataTable = element.dataTable(options);
    };
});