VSS.init({ setupModuleLoader: true });

// Use an IIFE to create an object that satisfies the IContributedMenuSource contract
var menuContributionHandler = (function () {
    "use strict";
    return {
        // This is a callback that gets invoked when a user clicks the newly contributed menu item
        // The actionContext parameter contains context data surrounding the circumstances of this
        // action getting invoked.
        execute: function (actionContext) {

            alert("Hello, world");
        }
    };
}());

// Associate the menuContributionHandler object with the "myAction" menu contribution from the manifest.
VSS.register("Add2WulAction", menuContributionHandler);