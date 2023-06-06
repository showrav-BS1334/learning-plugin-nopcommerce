using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.StudentCRUD.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Services.Plugins;
using Nop.Web.Framework;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.StudentCRUD
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class StudentCRUD : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPictureService _pictureService;
        private readonly ISettingService _settingService;
        private readonly IWebHelper _webHelper;
        private readonly INopFileProvider _fileProvider;

        public StudentCRUD(ILocalizationService localizationService,
            IPictureService pictureService,
            ISettingService settingService,
            IWebHelper webHelper,
            INopFileProvider fileProvider)
        {
            _localizationService = localizationService;
            _pictureService = pictureService;
            _settingService = settingService;
            _webHelper = webHelper;
            _fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the widget zones
        /// </returns>
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public Type GetWidgetViewComponent(string widgetZone)
        {
            return typeof(WidgetsStudentCRUDViewComponent);
        }

        // admin panel e baam er dike ekta button er jnno
        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {
            var configurationItem = rootNode.ChildNodes.FirstOrDefault(node => node.SystemName.Equals("Configuration"));
            if (configurationItem is null)
                return;

            var widgetsItem = configurationItem.ChildNodes.FirstOrDefault(node => node.SystemName.Equals("Widgets"));
            var index = configurationItem is not null ? configurationItem.ChildNodes.IndexOf(widgetsItem) : -1;

            configurationItem.ChildNodes.Insert(index + 1, new SiteMapNode
            {
                Visible = true,
                SystemName = PluginDescriptor.SystemName,
                Title = PluginDescriptor.FriendlyName,
                ControllerName = "Student",
                ActionName = "Index",
                IconClass = "far fa-dot-circle",
                RouteValues = new RouteValueDictionary { { "area", AreaNames.Admin } }
            });
        }

        //public override async Task InstallAsync()
        //{
        //    await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        //    {
        //        ["Plugins.Widgets.Crud.SaveButton"] = "Save",
        //        ["Plugins.Widgets.Crud.DeleteButton"] = "Delete",
        //        ["Plugins.Widgets.Crud.EditButton"] = "Edit",
        //        ["Plugins.Widgets.Crud.AddUserButton"] = "Add User",
        //        ["Plugins.Widgets.Crud.IndexPageTitle"] = "User Info Page",
        //        ["Plugins.Widgets.Crud.EditPageTitle"] = "Edit User Info"

        //    });
        //    await base.InstallAsync();
        //}

        //public override async Task UninstallAsync()
        //{
        //    await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.Crud");
        //    await base.UninstallAsync();
        //}

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;
    }
}