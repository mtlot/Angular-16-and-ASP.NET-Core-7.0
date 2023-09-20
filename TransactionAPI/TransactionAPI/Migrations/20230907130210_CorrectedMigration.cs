using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionDetail",
                columns: table => new
                {
                    TransactionDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALLOC_TXN_ID = table.Column<long>(type: "bigint", nullable: false),
                    DEED_INO = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    LOG_CREATED_TS = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CONV_DEED_ABBREVIATION = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SOURCE_REF_ABBREVIATION = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CONV_STATUS = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    LOT_NO = table.Column<int>(type: "int", nullable: false),
                    DEED_STATUS = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    DEED_TYPE = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DEED_OWNER_NAME = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PRINT_STATUS = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDetail", x => x.TransactionDetailId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionDetail");
        }
    }
}
