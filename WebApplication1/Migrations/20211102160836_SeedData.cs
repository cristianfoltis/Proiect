using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    UserLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DeviceOS = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DeviceProcessor = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DeviceRAM = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "UserId", "UserLocation", "UserName", "UserRole" },
               values: new object[,]
               {
                    { 1, "Cluj-Napoca", "Mihai Stefanescu", "Web Developer" },
                    { 2, "Cluj-Napoca", "Ioana Maria", ".NET Developer" },
                    { 3, "Brasov", "Mos Bogdan", "Java Developer" }
               });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "DeviceId", "DeviceName", "DeviceOS", "DeviceProcessor", "DeviceRAM", "DeviceType", "Manufacturer", "UserId" },
                values: new object[,]
                {
                    { 1, "Smart001", "Android", "Exynos", "6GB", "Smartphone", "Samsung", 3 },
                    { 2, "Smart002", "Android", "Snapdragon", "12GB", "Smartphone", "Samsung", 1 },
                    { 3, "Smart003", "iOS", "A13 Bionic", "4GB", "Smartphone", "Apple", 2 }
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
