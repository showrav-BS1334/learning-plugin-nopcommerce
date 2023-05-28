using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.MyPlugin.Components
{
    public class WidgetsMyPluginViewComponent : NopViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string widget, object extraData)
        {
            return View("~/Plugins/Widgets.NivoSliderCustom/Views/PublicInfo.cshtml");

        }   
    }
}
