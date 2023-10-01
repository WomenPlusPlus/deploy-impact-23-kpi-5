using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI5.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KpisDB",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Circle = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    Kpi = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    Periodicity = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    Range = table.Column<string>(type: "VARCHAR", maxLength: 60, nullable: true),
                    PeriodYear = table.Column<int>(type: "INT", maxLength: 4, nullable: true),
                    PeriodMonth = table.Column<int>(type: "INT", maxLength: 2, nullable: true),
                    Value = table.Column<float>(type: "DECIMAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpisDB", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KpisDB");
        }
    }
}
