using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationJobId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f71129d-b39c-4281-b322-fd74fcd7e333");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8421b985-6069-4498-84ed-e218b1ee55a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9c17724-2e57-4693-8e85-a92acd17d4e5");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4853815c-8309-4c85-ad56-97fb98823307", null, "Employee", "EMPLOYEE" },
                    { "7fb2ea1f-4b0f-4e6f-ac5e-069410fba3c5", null, "Admin", "ADMIN" },
                    { "90ba4293-0e9b-49fe-a5bd-c3cefa8b6b97", null, "Employer", "EMPLOYER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobId",
                table: "Applications",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_JobId",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4853815c-8309-4c85-ad56-97fb98823307");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb2ea1f-4b0f-4e6f-ac5e-069410fba3c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90ba4293-0e9b-49fe-a5bd-c3cefa8b6b97");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Applications");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f71129d-b39c-4281-b322-fd74fcd7e333", null, "Employer", "EMPLOYER" },
                    { "8421b985-6069-4498-84ed-e218b1ee55a4", null, "Admin", "ADMIN" },
                    { "d9c17724-2e57-4693-8e85-a92acd17d4e5", null, "Employee", "EMPLOYEE" }
                });
        }
    }
}
