using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Cucumber.WebApp.Models
{
    /// <summary>
    /// Conversion Model
    /// </summary>
    public class ServerSideViewModel
    {
        public string ButtonText
        {
            get
            {
                return "Convert to Words";
            }
        }

        public string HeadingText
        {
            get
            {
                return "Please Enter Name and Number";
            }
        }

        public string ConvertedNumber { get; set; }

        public string MainCurrency { get; set; }

        public string FractionalCurrency { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Fill-in a Number")]
        public string Number { get; set; }

    }
}