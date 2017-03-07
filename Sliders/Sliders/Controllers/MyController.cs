using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iFactr.Core;
using iFactr.Core.Utilities;
using MonoCross.Navigation;

namespace Sliders.Controllers
{
    public class MyController : MXController<string>
    {
        public override string Load(string uri, Dictionary<string, string> parameters)
        {
            //TODO: Populate the Controller's model
            Model = string.Empty;

            // return ViewPerpective based on the state of the Model
            return ViewPerspective.Default;
        }

        public const string Uri = "MyControllerUri";
    }
}