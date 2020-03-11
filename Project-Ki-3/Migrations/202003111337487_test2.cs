namespace Project_Ki_3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.HealthInsurances", "ProgrammeId", c => c.Int(nullable: false));
            CreateIndex("dbo.HealthInsurances", "ProgrammeId");
            AddForeignKey("dbo.HealthInsurances", "ProgrammeId", "dbo.Programmes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HealthInsurances", "ProgrammeId", "dbo.Programmes");
            DropIndex("dbo.HealthInsurances", new[] { "ProgrammeId" });
            DropColumn("dbo.HealthInsurances", "ProgrammeId");
            DropTable("dbo.Programmes");
        }
    }
}
