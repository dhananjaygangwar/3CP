using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CyberCrimeComplaintPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToComplaint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Complaints",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Complaints",
                newName: "status");
        }
    }
}
