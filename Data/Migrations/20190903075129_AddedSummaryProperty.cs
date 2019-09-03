using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddedSummaryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseSummary_SponsorResponses_SponsorResponseId",
                table: "ResponseSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseSummary_ThirdPartyResponses_ThirdPartyResponseId",
                table: "ResponseSummary");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_ResponseSummary_SummaryId",
                table: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseSummary",
                table: "ResponseSummary");

            migrationBuilder.RenameTable(
                name: "ResponseSummary",
                newName: "ResponseSummaries");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseSummary_ThirdPartyResponseId",
                table: "ResponseSummaries",
                newName: "IX_ResponseSummaries_ThirdPartyResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseSummary_SponsorResponseId",
                table: "ResponseSummaries",
                newName: "IX_ResponseSummaries_SponsorResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseSummaries",
                table: "ResponseSummaries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseSummaries_SponsorResponses_SponsorResponseId",
                table: "ResponseSummaries",
                column: "SponsorResponseId",
                principalTable: "SponsorResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseSummaries_ThirdPartyResponses_ThirdPartyResponseId",
                table: "ResponseSummaries",
                column: "ThirdPartyResponseId",
                principalTable: "ThirdPartyResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_ResponseSummaries_SummaryId",
                table: "Sponsors",
                column: "SummaryId",
                principalTable: "ResponseSummaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseSummaries_SponsorResponses_SponsorResponseId",
                table: "ResponseSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseSummaries_ThirdPartyResponses_ThirdPartyResponseId",
                table: "ResponseSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_ResponseSummaries_SummaryId",
                table: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseSummaries",
                table: "ResponseSummaries");

            migrationBuilder.RenameTable(
                name: "ResponseSummaries",
                newName: "ResponseSummary");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseSummaries_ThirdPartyResponseId",
                table: "ResponseSummary",
                newName: "IX_ResponseSummary_ThirdPartyResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseSummaries_SponsorResponseId",
                table: "ResponseSummary",
                newName: "IX_ResponseSummary_SponsorResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseSummary",
                table: "ResponseSummary",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseSummary_SponsorResponses_SponsorResponseId",
                table: "ResponseSummary",
                column: "SponsorResponseId",
                principalTable: "SponsorResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseSummary_ThirdPartyResponses_ThirdPartyResponseId",
                table: "ResponseSummary",
                column: "ThirdPartyResponseId",
                principalTable: "ThirdPartyResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_ResponseSummary_SummaryId",
                table: "Sponsors",
                column: "SummaryId",
                principalTable: "ResponseSummary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
