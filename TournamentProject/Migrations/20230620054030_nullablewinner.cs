using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentProject.Migrations
{
    /// <inheritdoc />
    public partial class nullablewinner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(2407),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(3362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(1843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(2831));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(1205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(1912));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Reports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(3362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(2831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(2287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(1205));

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 22, 23, 31, 27, 182, DateTimeKind.Utc).AddTicks(1912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 6, 20, 5, 40, 30, 412, DateTimeKind.Utc).AddTicks(778));
        }
    }
}
