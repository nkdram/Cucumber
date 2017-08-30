using Cucumber.Data.Models.Common;
using Cucumber.Data.Models.Pages;

namespace Cucumber.Service.Common
{
    public interface ICommonService
    {
        HeaderItem GetHeader();

        FooterItem GetFooter();

        AboutItem GetAboutItem();
    }
}
