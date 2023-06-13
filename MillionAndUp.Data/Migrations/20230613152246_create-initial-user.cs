using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MillionAndUp.Data.Migrations
{
    /// <inheritdoc />
    public partial class createinitialuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"
				if not exists(select * from Users where login = 'cjunior90@gmail.com')
					begin 

						INSERT INTO [dbo].[Users]
									([Id]
									,[Name]
									,[Login]
									,[Password]
									,[Email]
									,[InsertedDate]
									,[UpdatedDate])
								VALUES
									( NEWID()
									,'Carlos Junior Diaz Serna'
									,'cjunior90@gmail.com'
									,'HksfVyavGSjdtWtCByBdmazmIJ5eh+P/PVEeBeTwLNDAcSdLmdjH9BwKa/3RJnvF'
									,'cjunior90@gmail.com'
									,GETDATE()
									,GETDATE())
					end";
            migrationBuilder.Sql(createProcSql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "if exists(select * from Users where login = 'cjunior90@gmail.com')\r\n\tbegin \r\n\t\tdelete from \tUsers where login = 'cjunior90@gmail.com'\r\n\tend";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
