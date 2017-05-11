namespace PoP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FIlesInProjectModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fileID = c.String(),
                        projectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FIlesInProjectModels");
        }
    }
}
