using Microsoft.EntityFrameworkCore.Migrations;

namespace Micro_Service.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Suburbs",
                columns: table => new
                {
                    SuburbID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburbs", x => x.SuburbID);
                    table.ForeignKey(
                        name: "FK_Suburbs_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CLientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuburbID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CLientID);
                    table.ForeignKey(
                        name: "FK_Client_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Suburbs_SuburbID",
                        column: x => x.SuburbID,
                        principalTable: "Suburbs",
                        principalColumn: "SuburbID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccounNumer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ClientsCLientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Client_ClientsCLientID",
                        column: x => x.ClientsCLientID,
                        principalTable: "Client",
                        principalColumn: "CLientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "AccountID", "AccounNumer", "AccountType", "Balance", "ClientID", "ClientsCLientID", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "29484675683", "Savings", 23000.0, 1, null, "FNB", "Active" },
                    { 2, "75656478", "Cheque", 20000.0, 2, null, "Standard", "Active" },
                    { 3, "348575894", "Savings", 68000.0, 2, null, "Standard", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "Name" },
                values: new object[,]
                {
                    { 1, "Port Elizabeth" },
                    { 2, "Durban" },
                    { 3, "Cape Town" }
                });

            migrationBuilder.InsertData(
                table: "Suburbs",
                columns: new[] { "SuburbID", "CityID", "Name" },
                values: new object[] { 1, 1, "Humewood" });

            migrationBuilder.InsertData(
                table: "Suburbs",
                columns: new[] { "SuburbID", "CityID", "Name" },
                values: new object[] { 2, 1, "Summerstrand" });

            migrationBuilder.InsertData(
                table: "Suburbs",
                columns: new[] { "SuburbID", "CityID", "Name" },
                values: new object[] { 3, 2, "Kwamashu" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "CLientID", "AddressLine1", "AddressLine2", "CityID", "FirtName", "SuburbID", "Surname" },
                values: new object[] { 1, "25 Nelson Mandela", "", 1, "George", 2, "Molala" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "CLientID", "AddressLine1", "AddressLine2", "CityID", "FirtName", "SuburbID", "Surname" },
                values: new object[] { 2, "19 Perkins", "", 2, "Mary", 3, "Nkuna" });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_ClientsCLientID",
                table: "BankAccounts",
                column: "ClientsCLientID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CityID",
                table: "Client",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Client_SuburbID",
                table: "Client",
                column: "SuburbID");

            migrationBuilder.CreateIndex(
                name: "IX_Suburbs_CityID",
                table: "Suburbs",
                column: "CityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Suburbs");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
