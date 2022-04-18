namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMembershiptypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 75),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "DOB", c => c.DateTime());
            AlterColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));

             

            CreateTable(
                "dbo.MembershipTypes",
                c => new
                {
                    MembershipTypeId = c.Byte(nullable: false),
                    SignUpFee = c.Short(nullable: false),
                    DurationInMonths = c.Byte(nullable: false),
                    DiscountRate = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.MembershipTypeId);

          
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "MembershipTypeId", cascadeDelete: true);
        }

        public override void Down()
        {
            
        }
    }
}
