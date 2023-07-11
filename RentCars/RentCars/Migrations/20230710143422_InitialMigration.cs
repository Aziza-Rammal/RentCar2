using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCars.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Car",
                schema: "dbo",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(30)", nullable: false),
                    EngCapacity = table.Column<string>(type: "varchar(20)", nullable: false),
                    Color = table.Column<string>(type: "varchar(10)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DriveStatus = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "dbo",
                columns: table => new
                {
                    Phone = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(40)", nullable: false),
                    Addrees = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Phone);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                schema: "dbo",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rent_Car_CarId",
                        column: x => x.CarId,
                        principalSchema: "dbo",
                        principalTable: "Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rent_Client_Phone",
                        column: x => x.Phone,
                        principalSchema: "dbo",
                        principalTable: "Client",
                        principalColumn: "Phone",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rent_CarId",
                schema: "dbo",
                table: "Rent",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_Phone",
                schema: "dbo",
                table: "Rent",
                column: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rent",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Car",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "dbo");
        }
    }
}
