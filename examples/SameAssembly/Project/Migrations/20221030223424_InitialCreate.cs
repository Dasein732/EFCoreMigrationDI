using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        private IColumnNameProvider columnNameProvider { get; }

        public InitialCreate(IColumnNameProvider columnNameProvider)
        {
            this.columnNameProvider = columnNameProvider;
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var columnName = columnNameProvider.ProvideName();

            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Test1 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Test2 = table.Column<short>(type: "smallint", name: columnName, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable");
        }
    }
}
