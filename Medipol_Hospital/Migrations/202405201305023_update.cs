namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "Surname", c => c.String());
            DropColumn("dbo.Doctors", "Nurname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Nurname", c => c.String());
            DropColumn("dbo.Doctors", "Surname");
        }
    }
}
