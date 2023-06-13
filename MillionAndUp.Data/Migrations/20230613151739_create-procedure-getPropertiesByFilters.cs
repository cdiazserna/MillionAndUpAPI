using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillionAndUp.Data.Migrations
{
    /// <inheritdoc />
    public partial class createproceduregetPropertiesByFilters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"
					create or alter procedure getPropertiesByFilter
						@CodeInternal varchar(max) ,
						@Address varchar(max) ,
						@MinPrice decimal(18,2),
						@MaxPrice decimal(18,2)
					as
					begin 

						select p.[Name] ,
								p.[Address],
								p.[Price],
								p.[CodeInternal],
								p.[Year],
								O.[Name] Owner,
								O.Address OwnerAddress,
								t.[Name] PropertyTracesName,
								t.Value,
								t.Tax
						from [dbo].[Properties] P
								LEFT JOIN [dbo].[Owners] O ON P.OwnerId = O.Id
								LEFT JOIN [dbo].[PropertyTraces] t on p.id = t.PropertyId

						Where (isnull(@CodeInternal,'') = '' OR [CodeInternal] = @CodeInternal)
							and (isnull(@Address,'') = '' or P.[Address] like '%'+@Address+'%')
							and (@MinPrice = 0 or P.[Price] >=  @MinPrice)
							and (@MaxPrice = 0 or P.[Price] <= @MaxPrice)

					end		 ";
            migrationBuilder.Sql(createProcSql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC getPropertiesByFilter";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
