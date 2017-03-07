using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iFactr.Core;
using iFactr.Core.Utilities;
using iFactr.UI;
using MonoCross.Navigation;

using Sliders.Controllers;
using Sliders.Views;

namespace Sliders
{
    public class MyApp : iApp
    {
        // Add code to initialize your application here.  For more information, see http://support.ifactr.com/
        public override void OnAppLoad()
        {
            // Set the application title
            Title = "My App";

            iApp.Log.LoggingLevel = iFactr.Core.Utilities.Logging.LoggingLevel.Platform;

            // Add navigation mappings
            NavigationMap.Add(MyController.Uri, new MyController());

            // Add Views to ViewMap
            MXContainer.AddView<string>(typeof(MyGridView));

            // Set default navigation URI
            NavigateOnLoad = MyController.Uri;

        }
    }
}
