using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdutPlatform.Migrations
{
    /// <inheritdoc />
    public partial class student_fullname_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "FullName",
               table: "Students",
               type: "nvarchar(150)",
               maxLength: 150,
               nullable: false,
               defaultValue: "");

            migrationBuilder.Sql("update Students set FullName = FirstName + ' ' + LastName");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("update Students set FirstName = LEFT(FullName,CHARINDEX(' ',FullName) -1), " + "LastName=Substring(FullName,CHARINDEX(' ',FullName) + 1,LEN(FullName))");

            migrationBuilder.DropColumn(
              name: "FullName",
              table: "Students");
        }
    }
}
