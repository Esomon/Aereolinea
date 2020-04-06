using Microsoft.EntityFrameworkCore.Migrations;

namespace aereolinia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aviones",
                columns: table => new
                {
                    AvionesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelos = table.Column<string>(nullable: false),
                    Eye = table.Column<string>(nullable: false),
                    Capacity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviones", x => x.AvionesID);
                });

            migrationBuilder.CreateTable(
                name: "TypeEmpleado",
                columns: table => new
                {
                    TypeEmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEmpleado", x => x.TypeEmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    VuelosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cinty = table.Column<string>(nullable: false),
                    Fecha = table.Column<string>(nullable: false),
                    Aerolinea = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.VuelosID);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Last_Name = table.Column<string>(nullable: false),
                    TypeEmpleadoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleado_TypeEmpleado_TypeEmpleadoID",
                        column: x => x.TypeEmpleadoID,
                        principalTable: "TypeEmpleado",
                        principalColumn: "TypeEmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_TypeEmpleadoID",
                table: "Empleado",
                column: "TypeEmpleadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aviones");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "TypeEmpleado");
        }
    }
}
