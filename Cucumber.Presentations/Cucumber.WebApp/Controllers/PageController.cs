using Cucumber.Core.Base;
using Cucumber.Service.Common;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cucumber.WebApp.Controllers
{
    /// <summary>
    /// Controller for pages
    /// </summary>
    public class PageController : Controller
    {

        #region Fields
        private ILogger _loggingService;
        private ICommonService _commonService;
        #endregion

        #region Ctor
        public PageController(ILogger logger, ICommonService commonService)
        {
            _loggingService = logger;
            _commonService = commonService;
        }
        #endregion

        #region Actions
        public ActionResult Home()
        {
            return View();
        }


        public ActionResult ConvertData()
        {
            var model = new Cucumber.WebApp.Models.ServerSideViewModel();
            return View(model);
        }

        public ActionResult Settings()
        {
            var model = new Cucumber.WebApp.Models.SettingsViewModel();
            return View(model);
        }       

        #endregion
    }
}