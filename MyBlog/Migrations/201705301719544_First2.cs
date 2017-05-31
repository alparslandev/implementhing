namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Summary", c => c.String());
            AddColumn("dbo.Blogs", "SummaryEnglish", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "SummaryEnglish");
            DropColumn("dbo.Blogs", "Summary");
        }
    }
}
