using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Payment.Domain.EntityMigration.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    StatusType = table.Column<int>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    StatusType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ProviderType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankBin",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    StatusType = table.Column<int>(nullable: false),
                    InsertedUser = table.Column<string>(nullable: true),
                    InsertedIp = table.Column<string>(nullable: true),
                    InsertedDate = table.Column<DateTime>(nullable: false),
                    UpdatedUser = table.Column<string>(nullable: true),
                    UpdatedIp = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    BankId = table.Column<long>(nullable: false),
                    BinNumber = table.Column<int>(nullable: false),
                    CardType = table.Column<string>(maxLength: 10, nullable: false),
                    Organization = table.Column<string>(maxLength: 25, nullable: false),
                    IsCommercialCard = table.Column<bool>(nullable: false),
                    IsSupportInstallment = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankBin_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankProvider",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Guid = table.Column<Guid>(nullable: false),
                    StatusType = table.Column<int>(nullable: false),
                    BankId = table.Column<long>(nullable: false),
                    ProviderId = table.Column<long>(nullable: false),
                    Configuration = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankProvider_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankBin_BankId",
                table: "BankBin",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankProvider_BankId",
                table: "BankProvider",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankProvider_ProviderId",
                table: "BankProvider",
                column: "ProviderId");

            migrationBuilder.InsertData("Bank", new string[] { "Guid", "StatusType", "Code", "Name" }, new object[] { Guid.NewGuid(), 1, 62, "T. GARANTİ BANKASI A.Ş." });
            migrationBuilder.InsertData("Bank", new string[] { "Guid", "StatusType", "Code", "Name" }, new object[] { Guid.NewGuid(), 1, 64, "T. İŞ BANKASI A.Ş." });
            migrationBuilder.InsertData("BankBin", new string[] { "Guid", "StatusType", "InsertedUser", "InsertedIp", "InsertedDate", "BankId", "BinNumber", "CardType", "Organization", "IsCommercialCard", "IsSupportInstallment", "IsActive" }, new object[] { Guid.NewGuid(), 1, 1, "127.0.0.1", DateTime.Now, @"(select ""Id"" from public.""Bank"" where ""Code"" = 62)", 979236, "DEBIT CARD", "VISA", false, true, true });
            migrationBuilder.InsertData("BankBin", new string[] { "Guid", "StatusType", "InsertedUser", "InsertedIp", "InsertedDate", "BankId", "BinNumber", "CardType", "Organization", "IsCommercialCard", "IsSupportInstallment", "IsActive" }, new object[] { Guid.NewGuid(), 1, 1, "127.0.0.1", DateTime.Now, @"(select ""Id"" from public.""Bank"" where ""Code"" = 64)", 418342, "DEBIT CARD", "VISA", false, true, true });
            migrationBuilder.InsertData("Provider", new string[] { "Guid", "StatusType", "Name", "ProviderType" }, new object[] { Guid.NewGuid(), 1, "EST", 0 });
            migrationBuilder.InsertData("Provider", new string[] { "Guid", "StatusType", "Name", "ProviderType" }, new object[] { Guid.NewGuid(), 1, "MPI", 1 });
            migrationBuilder.InsertData("Provider", new string[] { "Guid", "StatusType", "Name", "ProviderType" }, new object[] { Guid.NewGuid(), 1, "PAYTEN", 2 });
            migrationBuilder.InsertData("Provider", new string[] { "Guid", "StatusType", "Name", "ProviderType" }, new object[] { Guid.NewGuid(), 1, "IPARA", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankBin");

            migrationBuilder.DropTable(
                name: "BankProvider");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Provider");
        }
    }
}
