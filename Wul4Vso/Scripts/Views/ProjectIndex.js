     VSS.init({
         explicitNotifyLoaded: true,
         setupModuleLoader: true
     });

//VSS.require(["VSS/Controls", "VSS/Controls/Grids", "VSS/Service", "TFS/WorkItemTracking/RestClient"],
//    function (Controls, Grids, VSS_Service, TFS_Wit_WebApi) {
//        var witClient = VSS_Service.getCollectionClient(TFS_Wit_WebApi.WorkItemTrackingHttpClient);

//        // Call the "queryById" REST endpoint, giving a query ID
//        witClient.getWorkItems(/* some work item IDs */ [1,2,3,4], ["System.Title"]).then(function(workItems) {

//            // Create a Grid control to display the Work Items
//            Controls.create(Grids.Grid, $("#grid-container"), {
//                height: "1000px", // Explicit height is required for a Grid control
//                columns: [
//                    // text is the column header text.
//                    // index is the key into the source object to find the data for this column
//                    // width is the width of the column, in pixels
//                    { text: "Work Item ID", index: "id", width: 150 },

//                    // getColumnValue provides a mechanism for the grid to get the data for a cell
//                    // (at the given row number) if it is not directly keyed off the source object.
//                    { text: "Title", width: 150, getColumnValue: function(dataIndex) {
//                        // The Work Item's Title is at source[row].fields["System.Title"].
//                        // this.getRowData(n) returns the nth item from the source object, so we
//                        // can return the "System.Title" property under fields.
//                        return this.getRowData(dataIndex).fields["System.Title"];
//                    } },
//                    { text: "URL", index: "url", width: 600 }
//                ],
//                // This data source is rendered into the Grid columns defined above
//                source: workItems
//            });
//        });

//    })

function refresh (data) {

    $.ajax({
        url: '/Home/Tasks?workspaceid=' + data.value,
        type: 'GET',
        datatype: 'json',
        async: false
        }).done(function (data) {
        if (data == undefined || data == null) {
            $('#errormsg').text('No data found');
            return;
        }
        $('#grid-container').html(data);
            /* little fade in effect */
        $('#grid-container').fadeIn('fast');
        }
    )}

