using KuyumHesap.Persistence.Common.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuyumHesap.Persistence.Migrations
{
    /// <inheritdoc />
    [DbContext(typeof(AppDbContext))]
    [Migration("20260417010000_FixPermissionForeignKeys")]
    public partial class FixPermissionForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_RolePermissions_Roles_RolesId')
    ALTER TABLE [RolePermissions] DROP CONSTRAINT [FK_RolePermissions_Roles_RolesId];

IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_RolePermissions_RolesId' AND object_id = OBJECT_ID(N'[RolePermissions]'))
    DROP INDEX [IX_RolePermissions_RolesId] ON [RolePermissions];

IF COL_LENGTH('RolePermissions', 'RolesId') IS NOT NULL
    ALTER TABLE [RolePermissions] DROP COLUMN [RolesId];

IF EXISTS (SELECT 1 FROM sys.foreign_keys WHERE name = 'FK_UserPermissions_Users_UsersId')
    ALTER TABLE [UserPermissions] DROP CONSTRAINT [FK_UserPermissions_Users_UsersId];

IF EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_UserPermissions_UsersId' AND object_id = OBJECT_ID(N'[UserPermissions]'))
    DROP INDEX [IX_UserPermissions_UsersId] ON [UserPermissions];

IF COL_LENGTH('UserPermissions', 'UsersId') IS NOT NULL
    ALTER TABLE [UserPermissions] DROP COLUMN [UsersId];

DELETE rp
FROM [RolePermissions] rp
WHERE NOT EXISTS (SELECT 1 FROM [Roles] r WHERE r.[Id] = rp.[RoleId]);

DELETE up
FROM [UserPermissions] up
WHERE NOT EXISTS (SELECT 1 FROM [Users] u WHERE u.[Id] = up.[UserId]);
");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId_PermissionId",
                table: "RolePermissions",
                columns: new[] { "RoleId", "PermissionId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Permissions_PermissionId",
                table: "UserPermissions");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Permissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_UserId",
                table: "UserPermissions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Roles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Users_UserId",
                table: "UserPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPermissions_Permissions_PermissionId",
                table: "UserPermissions");

            migrationBuilder.DropIndex(
                name: "IX_RolePermissions_RoleId_PermissionId",
                table: "RolePermissions");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "RolePermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UserPermissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
UPDATE [RolePermissions] SET [RolesId] = [RoleId];
UPDATE [UserPermissions] SET [UsersId] = [UserId];
");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RolesId",
                table: "RolePermissions",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UsersId",
                table: "UserPermissions",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Permissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_Roles_RolesId",
                table: "RolePermissions",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Permissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_UsersId",
                table: "UserPermissions",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
