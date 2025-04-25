using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniConsoleAppManager.Apps.Attributes
{
    // Multiuse attribute.
    [AttributeUsage(AttributeTargets.Class |
                           AttributeTargets.Struct,
                           AllowMultiple = true)  // Multiuse attribute.
    ]
    public class AppInfoAttribute : Attribute
    {
        public string AuthorName;
        string Title;
        string Description;
        double Version;


        public AppInfoAttribute(string title, string description, double version = 1.0)
        {
            Title = title;
            Description = description;

            AuthorName = "Yekopie";
            Version = version;
        }

        public string GetTitle() => Title;
        public string GetDescription() => Description;
        public double GetVersion() => Version;
    }
}
