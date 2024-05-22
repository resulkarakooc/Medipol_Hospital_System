namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "Password");
        }
    }
}
