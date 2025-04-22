using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAppManager
{
    // Multiuse attribute.
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct,
                           AllowMultiple = true)  // Multiuse attribute.
    ]
    public class AppInfoAttribute : System.Attribute
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
