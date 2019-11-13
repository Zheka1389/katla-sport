namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.client",
                c => new
                    {
                        client_id = c.Int(nullable: false, identity: true),
                        client_firstName = c.String(),
                        client_lastName = c.String(),
                        client_address = c.String(),
                        client_telephoneNumber = c.String(),
                        client_order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.client_id)
                .ForeignKey("dbo.order", t => t.client_order_id, cascadeDelete: true)
                .Index(t => t.client_order_id);

            CreateTable(
                "dbo.employee",
                c => new
                    {
                        employee_id = c.Int(nullable: false, identity: true),
                        employee_firstName = c.String(),
                        employee_lastName = c.String(),
                        employee_position = c.String(),
                        employee_departament = c.String(),
                        employee_client_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.employee_id)
                .ForeignKey("dbo.client", t => t.employee_client_id, cascadeDelete: true)
                .Index(t => t.employee_client_id);

            CreateTable(
                "dbo.order",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        order_Name = c.String(),
                        order_dateAccommodation = c.DateTime(nullable: false),
                        order_dateDestination = c.DateTime(nullable: false),
                        order_dateExecution = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.order_id);

            CreateTable(
                "dbo.delivery",
                c => new
                    {
                        delivery_id = c.Int(nullable: false, identity: true),
                        delivery_address = c.String(),
                        delivery_telephoneNumber = c.String(),
                        delivery_order_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.delivery_id)
                .ForeignKey("dbo.order", t => t.delivery_order_id, cascadeDelete: true)
                .Index(t => t.delivery_order_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.client", "client_order_id", "dbo.order");
            DropForeignKey("dbo.delivery", "delivery_order_id", "dbo.order");
            DropForeignKey("dbo.employee", "employee_client_id", "dbo.client");
            DropIndex("dbo.delivery", new[] { "delivery_order_id" });
            DropIndex("dbo.employee", new[] { "employee_client_id" });
            DropIndex("dbo.client", new[] { "client_order_id" });
            DropTable("dbo.delivery");
            DropTable("dbo.order");
            DropTable("dbo.employee");
            DropTable("dbo.client");
        }
    }
}
