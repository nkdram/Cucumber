using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cucumber.Data.Models.Common
{
    /// <summary>
    /// Stores Header Info
    /// </summary>
    public class HeaderItem
    {
        public string HeaderText { get; set; }

        public string MobileMenu { get; set; }

        public IEnumerable<MenuLinks> MenuLinks { get; set; }
    }

    /// <summary>
    /// Header Menu Links
    /// </summary>
    public class MenuLinks
    {
        public string MenuText { get; set; }
        public string MenuUrl { get; set; }
    }
}
