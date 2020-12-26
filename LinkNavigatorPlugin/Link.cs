using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNavigator
{
    #region Link classes
    public class Link
    {
        public DataProperty Name { get; set; }
        public DataProperty URL { get; set; }
        public DataProperty Category { get; set; }

        public Link(DataProperty name, DataProperty url, DataProperty category)
        {
            this.Name = name;
            this.URL = url;
            this.Category = category;
        }
    }
    public class stringedLink
    {
        public string Link_Name { get; set; }
        public string Link_URL { get; set; }
        public string Link_Category { get; set; }

        private static string GetPropertyValue(DataProperty prop)
        {
            return prop.Value.IsDisplayString ? prop.Value.ToDisplayString() : prop.Value.ToString().Split(':')[1];
        }
        public stringedLink(Link link)
        {
            this.Link_Name = GetPropertyValue(link.Name);
            this.Link_URL = GetPropertyValue(link.URL);
            this.Link_Category = GetPropertyValue(link.Category).Split('(')[1].Split(')')[0];

        }
    }
    #endregion

}
