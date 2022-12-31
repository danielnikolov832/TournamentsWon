using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentsRegister.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TournamentDAOs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentDAOs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TeamDAOs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TournamentDAOID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDAOs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeamDAOs_TournamentDAOs_TournamentDAOID",
                        column: x => x.TournamentDAOID,
                        principalTable: "TournamentDAOs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerDAOs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TeamDAOID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDAOs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlayerDAOs_TeamDAOs_TeamDAOID",
                        column: x => x.TeamDAOID,
                        principalTable: "TeamDAOs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDAOs_TeamDAOID",
                table: "PlayerDAOs",
                column: "TeamDAOID");

            migrationBuilder.CreateIndex(
                name: "IX_TeamDAOs_TournamentDAOID",
                table: "TeamDAOs",
                column: "TournamentDAOID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDAOs");

            migrationBuilder.DropTable(
                name: "TeamDAOs");

            migrationBuilder.DropTable(
                name: "TournamentDAOs");
        }
    }
}
