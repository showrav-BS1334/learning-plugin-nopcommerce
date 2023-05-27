using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.ImageViewer
{
    public class ImageViewerSettings : ISettings
    {
        public int Picture1Id { get; set; }
        public string Text1 { get; set; }
        public string Link1 { get; set; }
        public string AltText1 { get; set; }
    }
}