using Cucumber.Core.Base;
using Cucumber.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cucumber.WebApp.Controllers
{
    /// <summary>
    /// Used to render common components
    /// </summary>
    public class ComponentController : Controller
    {
        #region Fields
        private ILogger _loggingService;
        private ICommonService _commonService;
        #endregion

        #region Ctor
        public ComponentController(ILogger logger, ICommonService commonService)
        {
            _loggingService = logger;
            _commonService = commonService;
        }
        #endregion

        #region Actions
        // Header Component
        public PartialViewResult Header()
        {
            var headerItem = _commonService.GetHeader();
            return PartialView("~/Views/Shared/_Header.cshtml", headerItem);
        }
        /// <summary>
        /// Footer Component
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Footer()
        {
            var footerItem = _commonService.GetFooter();
            return PartialView("~/Views/Shared/_Footer.cshtml", footerItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> ConvertNumberAsync(Models.ServerSideViewModel form)
        {
            var wholeNumber = form.Number.Split('.');
            var mainCurrency = await Task.FromResult(Cucumber.Core.Helper.changeNumericToWords(wholeNumber[0]) + " " + form.MainCurrency);
            var fracCurrency = string.Empty;
            if (form.Number.Contains("."))
                fracCurrency = await Task.FromResult(Cucumber.Core.Helper.changeNumericToWords(wholeNumber[1]) + " " + form.FractionalCurrency);
            return mainCurrency + " And " + fracCurrency;
        }
        #endregion
    }
}