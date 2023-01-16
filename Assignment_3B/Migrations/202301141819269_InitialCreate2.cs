namespace Assignment_3B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Candidates", "Gender_GenderId", "dbo.Genders");
            DropForeignKey("dbo.Candidates", "PhotoIdType_Id", "dbo.PhotoIdTypes");
            DropIndex("dbo.Candidates", new[] { "Gender_GenderId" });
            DropIndex("dbo.Candidates", new[] { "PhotoIdType_Id" });
            AlterColumn("dbo.Candidates", "Gender_GenderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Candidates", "PhotoIdType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Candidates", "Gender_GenderId");
            CreateIndex("dbo.Candidates", "PhotoIdType_Id");
            AddForeignKey("dbo.Candidates", "Gender_GenderId", "dbo.Genders", "GenderId", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "PhotoIdType_Id", "dbo.PhotoIdTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "PhotoIdType_Id", "dbo.PhotoIdTypes");
            DropForeignKey("dbo.Candidates", "Gender_GenderId", "dbo.Genders");
            DropIndex("dbo.Candidates", new[] { "PhotoIdType_Id" });
            DropIndex("dbo.Candidates", new[] { "Gender_GenderId" });
            AlterColumn("dbo.Candidates", "PhotoIdType_Id", c => c.Int());
            AlterColumn("dbo.Candidates", "Gender_GenderId", c => c.Int());
            CreateIndex("dbo.Candidates", "PhotoIdType_Id");
            CreateIndex("dbo.Candidates", "Gender_GenderId");
            AddForeignKey("dbo.Candidates", "PhotoIdType_Id", "dbo.PhotoIdTypes", "Id");
            AddForeignKey("dbo.Candidates", "Gender_GenderId", "dbo.Genders", "GenderId");
        }
    }
}
