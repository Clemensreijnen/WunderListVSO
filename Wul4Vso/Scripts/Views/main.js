VSS.init({
    explicitNotifyLoaded: true,
    setupModuleLoader: true
});


var showPropertiesMenuProvider = (function () {
    "use strict";
    return {
        showPropertiesInDialog: function (properties, title) {

            VSS.ready(function () {
                require(["VSS/Service", "TFS/WorkItemTracking/RestClient"], function (VSS_Service, TFS_Wit_RestClient) {

                    var witClient = VSS_Service.getCollectionClient(TFS_Wit_RestClient.WorkItemTrackingHttpClient);
                    
                    witClient.getWorkItem(properties.workItemId, ["System.Title"]).then(function (workItem) {
                        var workItemTitle = workItem.fields["System.Title"];

                        $.ajax({
                            url: '/Home/AddToWunderlist?workItemTitle=' + workItemTitle,
                            type: 'GET',
                            datatype: 'json',
                            async: false
                        }).done(function (data) {
                            if (data == undefined || data == null) {
                                $('#errormsg').text('No data found');
                                return;
                            }
                            $('#grid-container').html(data);
                        });
                    });
                       
                });
            });
            
            var vsoContext = VSS.getWebContext();

           

        },
        execute: function (actionContext) {

            this.showPropertiesInDialog(actionContext);
        }
    };
}());

VSS.register("showProperties", function (context) {
    return showPropertiesMenuProvider;
});

