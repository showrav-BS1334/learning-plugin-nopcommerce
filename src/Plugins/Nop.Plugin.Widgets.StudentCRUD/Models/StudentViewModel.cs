using System;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.StudentCRUD.Models
{
    public record StudentViewModel : BaseNopModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
    }
}
