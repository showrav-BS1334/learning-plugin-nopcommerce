using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.MyPlugin.Components
{
    public class WidgetsMyPluginViewComponent : NopViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string widget, object additionalData)
        {
            return View("~/Plugins/Widgets.MyPlugin/Views/PublicInfo.cshtml");

        }
    }
}
