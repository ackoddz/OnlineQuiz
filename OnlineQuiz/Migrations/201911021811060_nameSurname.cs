namespace OnlineQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameSurname : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 40));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(maxLength: 50));
            DropTable("dbo.Questions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        subject = c.String(),
                        question = c.String(),
                        possibleAnswers = c.String(),
                        correctAnswer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
