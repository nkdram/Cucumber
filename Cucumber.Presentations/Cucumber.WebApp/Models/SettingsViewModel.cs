using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cucumber.WebApp.Models
{
    public class SettingsViewModel
    {
        public List<string> Cultures
        {
            get
            {
                return Cucumber.Core.Helper.GetCountryList();
            }
        }

        public string ButtonText
        {
            get
            {
                return "Save Settings";
            }
        }

        public string HeadingText
        {
            get
            {
                return "Please Select a Country";
            }
        }

        public string Placeholder
        {
            get
            {
                return "Select a Country";
            }
        }
        [Display(Name = "Provide Main Curreny Name")]
        public string MainCurreny { get; set; }

        [Display(Name = "Fractional currency")]
        public string FractionalCurrency { get; set; }
    }
}