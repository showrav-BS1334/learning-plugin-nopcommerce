using FluentMigrator;
using Nop.Core.Domain.Catalog;

namespace Nop.Data.Migrations
{
    [NopMigration("2023/06/01 12:00:00:8521770", "Category. Add some new property", UpdateMigrationType.Data, MigrationProcessType.Update)]
    public class AddMyProp : AutoReversingMigration
    {
        /// <summary>Collect the UP migration expressions</summary>
        public override void Up()
        {
            Create.Column(nameof(Category.MyProperty))
            .OnTable(nameof(Category))
            .AsString(255)
            .Nullable();
        }
    }
}