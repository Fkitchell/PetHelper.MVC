namespace PetHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "ServiceProviderId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "ServiceProviderId" });
            AddColumn("dbo.Appointments", "DateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "ServiceProviderId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Appointments", "ServiceProviderId");
            AddForeignKey("dbo.Appointments", "ServiceProviderId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Appointments", "DateTimeOffSet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DateTimeOffSet", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropForeignKey("dbo.Appointments", "ServiceProviderId", "dbo.AspNetUsers");
            DropIndex("dbo.Appointments", new[] { "ServiceProviderId" });
            AlterColumn("dbo.Appointments", "ServiceProviderId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Appointments", "DateTime");
            CreateIndex("dbo.Appointments", "ServiceProviderId");
            AddForeignKey("dbo.Appointments", "ServiceProviderId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
