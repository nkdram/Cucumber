using Cucumber.Data.Models.Common;
using Cucumber.Data.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cucumber.Repository.Common
{
    public interface ICommonRepository
    {
        HeaderItem GetHeader();

        FooterItem GetFooter();

        AboutItem GetAboutItem();
    }
}
