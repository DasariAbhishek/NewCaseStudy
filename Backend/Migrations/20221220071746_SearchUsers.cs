using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class SearchUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "candidateSkills",
                columns: table => new
                {
                    SkillSetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    SkillId = table.Column<int>(nullable: true),
                    Rating = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidateSkills", x => x.SkillSetId);
                    table.ForeignKey(
                        name: "FK_candidateSkills_skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_candidateSkills_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidateSkills_SkillId",
                table: "candidateSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_candidateSkills_UserId",
                table: "candidateSkills",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidateSkills");

            migrationBuilder.DropTable(
                name: "skills");
        }
    }
}
