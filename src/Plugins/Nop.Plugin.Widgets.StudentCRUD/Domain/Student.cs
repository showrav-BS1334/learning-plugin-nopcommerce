using Nop.Core;

namespace Nop.Plugin.Widgets.StudentCRUD.Domain
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
