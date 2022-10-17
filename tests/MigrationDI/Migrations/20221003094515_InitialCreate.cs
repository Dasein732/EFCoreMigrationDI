using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationDI.Migrations
{
    public partial class InitialCreate : Migration
    {
        public IColumnNameProvider Serv { get; }

        public InitialCreate(IColumnNameProvider serv)
        {
            Serv = serv;
        }


        protected override void Up(MigrationBuilder migrationBuilder)
        {


            var zz = Serv.ProvideName();
            migrationBuilder.CreateTable(
                name: Serv.ProvideName(),
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Test1 = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    Test2 = table.Column<short>(type: "smallint", nullable: true)
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
