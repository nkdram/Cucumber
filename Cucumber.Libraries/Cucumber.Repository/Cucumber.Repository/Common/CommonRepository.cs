using System;
using Cucumber.Data.Models.Common;
using Cucumber.Data.Models.Pages;
using Newtonsoft.Json;
using System.IO;
using Cucumber.Core.Infrastructure;

namespace Cucumber.Repository.Common
{
    public class CommonRepository : ICommonRepository
    {
        public AboutItem GetAboutItem()
        {
            return JsonConvert.DeserializeObject<AboutItem>(File.ReadAllText(CucumberContext.Current.DataPath + "About.json"));
        }

        public FooterItem GetFooter()
        {
            return JsonConvert.DeserializeObject<FooterItem>(File.ReadAllText(CucumberContext.Current.DataPath + "Footer.json"));
        }

        public HeaderItem GetHeader()
        {
            return JsonConvert.DeserializeObject<HeaderItem>(File.ReadAllText(CucumberContext.Current.DataPath + "Header.json"));
        }
    }
}
