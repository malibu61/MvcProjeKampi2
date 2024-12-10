namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorTitle", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "AuthorTitle");
        }
    }
}
