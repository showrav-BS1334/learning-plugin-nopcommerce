using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.ImageViewer.Models
{
    public record PublicInfoModel : BaseNopModel
    {
        public string Picture1Url { get; set; }
        public string Text1 { get; set; }
        public string Link1 { get; set; }
        public string AltText1 { get; set; }
    }
}