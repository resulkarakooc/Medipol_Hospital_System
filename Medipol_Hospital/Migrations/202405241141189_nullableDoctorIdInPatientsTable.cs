namespace Medipol_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDoctorIdInPatientsTable : DbMigration
    {
        public override void Up()
        {
            
            AlterColumn("dbo.Patinets", "doctorID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patinets", "doctorID", c => c.Int(nullable: false));
            
        }
    }
}
