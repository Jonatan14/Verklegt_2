namespace PoP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FIlesInProjectModels", "fileID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FIlesInProjectModels", "fileID", c => c.String());
        }
    }
}
