﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SponsorResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    A1 = table.Column<string>(nullable: true),
                    B1 = table.Column<string>(nullable: true),
                    B2 = table.Column<string>(nullable: true),
                    B3 = table.Column<string>(nullable: true),
                    C1 = table.Column<string>(nullable: true),
                    C2 = table.Column<string>(nullable: true),
                    C3 = table.Column<string>(nullable: true),
                    C4 = table.Column<string>(nullable: true),
                    C5 = table.Column<string>(nullable: true),
                    C6 = table.Column<string>(nullable: true),
                    C7 = table.Column<string>(nullable: true),
                    D1 = table.Column<string>(nullable: true),
                    D2 = table.Column<string>(nullable: true),
                    D3 = table.Column<string>(nullable: true),
                    E1 = table.Column<string>(nullable: true),
                    E2 = table.Column<string>(nullable: true),
                    E3 = table.Column<string>(nullable: true),
                    F1 = table.Column<string>(nullable: true),
                    F2 = table.Column<string>(nullable: true),
                    F3 = table.Column<string>(nullable: true),
                    G1 = table.Column<string>(nullable: true),
                    G2 = table.Column<string>(nullable: true),
                    G3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThirdPartyResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocumentAId = table.Column<int>(nullable: true),
                    DocumentBId = table.Column<int>(nullable: true),
                    DocumentCId = table.Column<int>(nullable: true),
                    DocumentDId = table.Column<int>(nullable: true),
                    DocumentEId = table.Column<int>(nullable: true),
                    A1 = table.Column<string>(nullable: true),
                    A2A = table.Column<string>(nullable: true),
                    A2B = table.Column<string>(nullable: true),
                    A2C1 = table.Column<string>(nullable: true),
                    A2C2 = table.Column<string>(nullable: true),
                    B1 = table.Column<string>(nullable: true),
                    B2A = table.Column<string>(nullable: true),
                    B2B = table.Column<string>(nullable: true),
                    B2C = table.Column<string>(nullable: true),
                    B2D1 = table.Column<string>(nullable: true),
                    B2D2 = table.Column<string>(nullable: true),
                    B2E = table.Column<string>(nullable: true),
                    B2F = table.Column<string>(nullable: true),
                    B2Oa = table.Column<string>(nullable: true),
                    B2Ob = table.Column<string>(nullable: true),
                    B2Oc = table.Column<string>(nullable: true),
                    B2Od = table.Column<string>(nullable: true),
                    B3A = table.Column<string>(nullable: true),
                    B3B1 = table.Column<string>(nullable: true),
                    B3B2 = table.Column<string>(nullable: true),
                    B3C = table.Column<string>(nullable: true),
                    B3D1A = table.Column<string>(nullable: true),
                    B3D1B = table.Column<string>(nullable: true),
                    B3D2 = table.Column<string>(nullable: true),
                    B4A = table.Column<string>(nullable: true),
                    B4B = table.Column<string>(nullable: true),
                    B4C = table.Column<string>(nullable: true),
                    B5 = table.Column<string>(nullable: true),
                    C1A = table.Column<string>(nullable: true),
                    C1B = table.Column<string>(nullable: true),
                    C1C = table.Column<string>(nullable: true),
                    C1D = table.Column<string>(nullable: true),
                    C1E = table.Column<string>(nullable: true),
                    C1F1 = table.Column<string>(nullable: true),
                    C1F2 = table.Column<string>(nullable: true),
                    C2A = table.Column<string>(nullable: true),
                    C2B = table.Column<string>(nullable: true),
                    C2C = table.Column<string>(nullable: true),
                    C2D = table.Column<string>(nullable: true),
                    C2E = table.Column<string>(nullable: true),
                    C2F1 = table.Column<string>(nullable: true),
                    C2F2 = table.Column<string>(nullable: true),
                    C3A = table.Column<string>(nullable: true),
                    C3B = table.Column<string>(nullable: true),
                    C3C = table.Column<string>(nullable: true),
                    C3D = table.Column<string>(nullable: true),
                    C3E = table.Column<string>(nullable: true),
                    C3F1 = table.Column<string>(nullable: true),
                    C3F2 = table.Column<string>(nullable: true),
                    D1 = table.Column<string>(nullable: true),
                    D2 = table.Column<string>(nullable: true),
                    D3 = table.Column<string>(nullable: true),
                    D4 = table.Column<string>(nullable: true),
                    D4A = table.Column<string>(nullable: true),
                    D4B = table.Column<string>(nullable: true),
                    D4C = table.Column<string>(nullable: true),
                    D4D = table.Column<string>(nullable: true),
                    D5 = table.Column<string>(nullable: true),
                    D6 = table.Column<string>(nullable: true),
                    D6A = table.Column<string>(nullable: true),
                    E1A = table.Column<string>(nullable: true),
                    E1B = table.Column<string>(nullable: true),
                    E2A = table.Column<string>(nullable: true),
                    E2B = table.Column<string>(nullable: true),
                    E3 = table.Column<string>(nullable: true),
                    F1 = table.Column<string>(nullable: true),
                    F2 = table.Column<string>(nullable: true),
                    F3 = table.Column<string>(nullable: true),
                    F4 = table.Column<string>(nullable: true),
                    F5 = table.Column<string>(nullable: true),
                    F6 = table.Column<string>(nullable: true),
                    F7 = table.Column<string>(nullable: true),
                    F8 = table.Column<string>(nullable: true),
                    F9 = table.Column<string>(nullable: true),
                    F10 = table.Column<string>(nullable: true),
                    F11 = table.Column<string>(nullable: true),
                    F12 = table.Column<string>(nullable: true),
                    F13A = table.Column<string>(nullable: true),
                    F13B = table.Column<string>(nullable: true),
                    F13C = table.Column<string>(nullable: true),
                    F13D = table.Column<string>(nullable: true),
                    G1 = table.Column<string>(nullable: true),
                    G2A = table.Column<string>(nullable: true),
                    G2B = table.Column<string>(nullable: true),
                    G2C = table.Column<string>(nullable: true),
                    G2D = table.Column<string>(nullable: true),
                    H1 = table.Column<string>(nullable: true),
                    H2 = table.Column<string>(nullable: true),
                    H3 = table.Column<string>(nullable: true),
                    H4 = table.Column<string>(nullable: true),
                    H5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdPartyResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdPartyResponses_Files_DocumentAId",
                        column: x => x.DocumentAId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyResponses_Files_DocumentBId",
                        column: x => x.DocumentBId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyResponses_Files_DocumentCId",
                        column: x => x.DocumentCId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyResponses_Files_DocumentDId",
                        column: x => x.DocumentDId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThirdPartyResponses_Files_DocumentEId",
                        column: x => x.DocumentEId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponseSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponsorResponseId = table.Column<int>(nullable: true),
                    ThirdPartyResponseId = table.Column<int>(nullable: true),
                    D = table.Column<string>(nullable: true),
                    G4A = table.Column<string>(nullable: true),
                    G4B = table.Column<string>(nullable: true),
                    I1 = table.Column<string>(nullable: true),
                    I2 = table.Column<string>(nullable: true),
                    I3 = table.Column<string>(nullable: true),
                    I4 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponseSummaries_SponsorResponses_SponsorResponseId",
                        column: x => x.SponsorResponseId,
                        principalTable: "SponsorResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponseSummaries_ThirdPartyResponses_ThirdPartyResponseId",
                        column: x => x.ThirdPartyResponseId,
                        principalTable: "ThirdPartyResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThirdParties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UniqueIdentifier = table.Column<Guid>(nullable: false),
                    HasResponded = table.Column<bool>(nullable: false),
                    ResponseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdParties_ThirdPartyResponses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "ThirdPartyResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UniqueIdentifier = table.Column<Guid>(nullable: false),
                    HasResponded = table.Column<bool>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    ResponseId = table.Column<int>(nullable: true),
                    ThirdPartyId = table.Column<int>(nullable: false),
                    SummaryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sponsors_SponsorResponses_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "SponsorResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sponsors_ResponseSummaries_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "ResponseSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sponsors_ThirdParties_ThirdPartyId",
                        column: x => x.ThirdPartyId,
                        principalTable: "ThirdParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseSummaries_SponsorResponseId",
                table: "ResponseSummaries",
                column: "SponsorResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseSummaries_ThirdPartyResponseId",
                table: "ResponseSummaries",
                column: "ThirdPartyResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_ResponseId",
                table: "Sponsors",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_SummaryId",
                table: "Sponsors",
                column: "SummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_ThirdPartyId",
                table: "Sponsors",
                column: "ThirdPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_UniqueIdentifier",
                table: "Sponsors",
                column: "UniqueIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdParties_ResponseId",
                table: "ThirdParties",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdParties_UniqueIdentifier",
                table: "ThirdParties",
                column: "UniqueIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyResponses_DocumentAId",
                table: "ThirdPartyResponses",
                column: "DocumentAId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyResponses_DocumentBId",
                table: "ThirdPartyResponses",
                column: "DocumentBId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyResponses_DocumentCId",
                table: "ThirdPartyResponses",
                column: "DocumentCId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyResponses_DocumentDId",
                table: "ThirdPartyResponses",
                column: "DocumentDId");

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyResponses_DocumentEId",
                table: "ThirdPartyResponses",
                column: "DocumentEId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ResponseSummaries");

            migrationBuilder.DropTable(
                name: "ThirdParties");

            migrationBuilder.DropTable(
                name: "SponsorResponses");

            migrationBuilder.DropTable(
                name: "ThirdPartyResponses");

            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
