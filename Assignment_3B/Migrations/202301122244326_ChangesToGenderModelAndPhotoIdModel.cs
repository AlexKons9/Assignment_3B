namespace Assignment_3B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToGenderModelAndPhotoIdModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genders", "GenderType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genders", "GenderType", c => c.String(nullable: false));
        }
    }
}
