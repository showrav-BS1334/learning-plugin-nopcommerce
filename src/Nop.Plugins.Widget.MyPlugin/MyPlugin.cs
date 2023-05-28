using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.MyPlugin.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugins.Widget.MyPlugin
{
    public class MyPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;

        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(WidgetsMyPluginViewComponent);
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop, PublicWidgetZones.HomepageBeforeCategories, PublicWidgetZones.HomepageBeforeProducts });
        }
    }
}