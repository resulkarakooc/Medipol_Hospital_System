namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTimePickerUpdateInEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "hourAndSecond", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "hourAndSecond");
        }
    }
}
