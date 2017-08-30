
using Cucumber.Data.Models.Common;
using Cucumber.Data.Models.Pages;

namespace Cucumber.Service.Common
{
    public class CommonService : ICommonService
    {
        private Cucumber.Repository.Common.ICommonRepository _commonRepository;

        public CommonService(Cucumber.Repository.Common.ICommonRepository commonRepository)
        {
            this._commonRepository = commonRepository;
        }

        public AboutItem GetAboutItem()
        {
            return _commonRepository.GetAboutItem();
        }

        public FooterItem GetFooter()
        {
            return _commonRepository.GetFooter();
        }

        public HeaderItem GetHeader()
        {
            return _commonRepository.GetHeader();
        }
    }
}
