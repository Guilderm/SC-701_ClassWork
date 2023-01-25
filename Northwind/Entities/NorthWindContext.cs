using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public partial class NorthWindContext : DbContext
    {
        public NorthWindContext()
        {
        }

        public NorthWindContext(DbContextOptions<NorthWindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlphabeticalListOfProduct> AlphabeticalListOfProducts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategorySalesFor1997> CategorySalesFor1997s { get; set; } = null!;
        public virtual DbSet<CurrentProductList> CurrentProductLists { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerAndSuppliersByCity> CustomerAndSuppliersByCities { get; set; } = null!;
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderDetailsExtended> OrderDetailsExtendeds { get; set; } = null!;
        public virtual DbSet<OrderSubtotal> OrderSubtotals { get; set; } = null!;
        public virtual DbSet<OrdersQry> OrdersQries { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductSalesFor1997> ProductSalesFor1997s { get; set; } = null!;
        public virtual DbSet<ProductsAboveAveragePrice> ProductsAboveAveragePrices { get; set; } = null!;
        public virtual DbSet<ProductsByCategory> ProductsByCategories { get; set; } = null!;
        public virtual DbSet<QuarterlyOrder> QuarterlyOrders { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<SalesByCategory> SalesByCategories { get; set; } = null!;
        public virtual DbSet<SalesTotalsByAmount> SalesTotalsByAmounts { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;
        public virtual DbSet<SummaryOfSalesByQuarter> SummaryOfSalesByQuarters { get; set; } = null!;
        public virtual DbSet<SummaryOfSalesByYear> SummaryOfSalesByYears { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<Territory> Territories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                _ = optionsBuilder.UseSqlServer("Server=.;Database=NorthWind;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<AlphabeticalListOfProduct>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Alphabetical list of products");

                _ = entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                _ = entity.Property(e => e.CategoryName).HasMaxLength(15);

                _ = entity.Property(e => e.ProductId).HasColumnName("ProductID");

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                _ = entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                _ = entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            _ = modelBuilder.Entity<Category>(entity =>
            {
                _ = entity.HasIndex(e => e.CategoryName, "CategoryName");

                _ = entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                _ = entity.Property(e => e.CategoryName).HasMaxLength(15);

                _ = entity.Property(e => e.Description).HasColumnType("ntext");

                _ = entity.Property(e => e.Picture).HasColumnType("image");
            });

            _ = modelBuilder.Entity<CategorySalesFor1997>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Category Sales for 1997");

                _ = entity.Property(e => e.CategoryName).HasMaxLength(15);

                _ = entity.Property(e => e.CategorySales).HasColumnType("money");
            });

            _ = modelBuilder.Entity<CurrentProductList>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Current Product List");

                _ = entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);
            });

            _ = modelBuilder.Entity<Customer>(entity =>
            {
                _ = entity.HasIndex(e => e.City, "City");

                _ = entity.HasIndex(e => e.CompanyName, "CompanyName");

                _ = entity.HasIndex(e => e.PostalCode, "PostalCode");

                _ = entity.HasIndex(e => e.Region, "Region");

                _ = entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                _ = entity.Property(e => e.Address).HasMaxLength(60);

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.ContactName).HasMaxLength(30);

                _ = entity.Property(e => e.ContactTitle).HasMaxLength(30);

                _ = entity.Property(e => e.Country).HasMaxLength(15);

                _ = entity.Property(e => e.Fax).HasMaxLength(24);

                _ = entity.Property(e => e.Phone).HasMaxLength(24);

                _ = entity.Property(e => e.PostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.Region).HasMaxLength(15);

                _ = entity.HasMany(d => d.CustomerTypes)
                    .WithMany(p => p.Customers)
                    .UsingEntity<Dictionary<string, object>>(
                        "CustomerCustomerDemo",
                        l => l.HasOne<CustomerDemographic>().WithMany().HasForeignKey("CustomerTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo"),
                        r => r.HasOne<Customer>().WithMany().HasForeignKey("CustomerId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerCustomerDemo_Customers"),
                        j =>
                        {
                            _ = j.HasKey("CustomerId", "CustomerTypeId").IsClustered(false);

                            _ = j.ToTable("CustomerCustomerDemo");

                            _ = j.IndexerProperty<string>("CustomerId").HasMaxLength(5).HasColumnName("CustomerID").IsFixedLength();

                            _ = j.IndexerProperty<string>("CustomerTypeId").HasMaxLength(10).HasColumnName("CustomerTypeID").IsFixedLength();
                        });
            });

            _ = modelBuilder.Entity<CustomerAndSuppliersByCity>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Customer and Suppliers by City");

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.ContactName).HasMaxLength(30);

                _ = entity.Property(e => e.Relationship)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            _ = modelBuilder.Entity<CustomerDemographic>(entity =>
            {
                _ = entity.HasKey(e => e.CustomerTypeId)
                    .IsClustered(false);

                _ = entity.Property(e => e.CustomerTypeId)
                    .HasMaxLength(10)
                    .HasColumnName("CustomerTypeID")
                    .IsFixedLength();

                _ = entity.Property(e => e.CustomerDesc).HasColumnType("ntext");
            });

            _ = modelBuilder.Entity<Employee>(entity =>
            {
                _ = entity.HasIndex(e => e.LastName, "LastName");

                _ = entity.HasIndex(e => e.PostalCode, "PostalCode");

                _ = entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                _ = entity.Property(e => e.Address).HasMaxLength(60);

                _ = entity.Property(e => e.BirthDate).HasColumnType("datetime");

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.Country).HasMaxLength(15);

                _ = entity.Property(e => e.Extension).HasMaxLength(4);

                _ = entity.Property(e => e.FirstName).HasMaxLength(10);

                _ = entity.Property(e => e.HireDate).HasColumnType("datetime");

                _ = entity.Property(e => e.HomePhone).HasMaxLength(24);

                _ = entity.Property(e => e.LastName).HasMaxLength(20);

                _ = entity.Property(e => e.Notes).HasColumnType("ntext");

                _ = entity.Property(e => e.Photo).HasColumnType("image");

                _ = entity.Property(e => e.PhotoPath).HasMaxLength(255);

                _ = entity.Property(e => e.PostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.Region).HasMaxLength(15);

                _ = entity.Property(e => e.Title).HasMaxLength(30);

                _ = entity.Property(e => e.TitleOfCourtesy).HasMaxLength(25);

                _ = entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("FK_Employees_Employees");

                _ = entity.HasMany(d => d.Territories)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeTerritory",
                        l => l.HasOne<Territory>().WithMany().HasForeignKey("TerritoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Territories"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeeTerritories_Employees"),
                        j =>
                        {
                            _ = j.HasKey("EmployeeId", "TerritoryId").IsClustered(false);

                            _ = j.ToTable("EmployeeTerritories");

                            _ = j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");

                            _ = j.IndexerProperty<string>("TerritoryId").HasMaxLength(20).HasColumnName("TerritoryID");
                        });
            });

            _ = modelBuilder.Entity<Invoice>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Invoices");

                _ = entity.Property(e => e.Address).HasMaxLength(60);

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.Country).HasMaxLength(15);

                _ = entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                _ = entity.Property(e => e.CustomerName).HasMaxLength(40);

                _ = entity.Property(e => e.ExtendedPrice).HasColumnType("money");

                _ = entity.Property(e => e.Freight).HasColumnType("money");

                _ = entity.Property(e => e.OrderDate).HasColumnType("datetime");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.PostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.ProductId).HasColumnName("ProductID");

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.Region).HasMaxLength(15);

                _ = entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                _ = entity.Property(e => e.Salesperson).HasMaxLength(31);

                _ = entity.Property(e => e.ShipAddress).HasMaxLength(60);

                _ = entity.Property(e => e.ShipCity).HasMaxLength(15);

                _ = entity.Property(e => e.ShipCountry).HasMaxLength(15);

                _ = entity.Property(e => e.ShipName).HasMaxLength(40);

                _ = entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.ShipRegion).HasMaxLength(15);

                _ = entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                _ = entity.Property(e => e.ShipperName).HasMaxLength(40);

                _ = entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            _ = modelBuilder.Entity<Order>(entity =>
            {
                _ = entity.HasIndex(e => e.CustomerId, "CustomerID");

                _ = entity.HasIndex(e => e.CustomerId, "CustomersOrders");

                _ = entity.HasIndex(e => e.EmployeeId, "EmployeeID");

                _ = entity.HasIndex(e => e.EmployeeId, "EmployeesOrders");

                _ = entity.HasIndex(e => e.OrderDate, "OrderDate");

                _ = entity.HasIndex(e => e.ShipPostalCode, "ShipPostalCode");

                _ = entity.HasIndex(e => e.ShippedDate, "ShippedDate");

                _ = entity.HasIndex(e => e.ShipVia, "ShippersOrders");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                _ = entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                _ = entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                _ = entity.Property(e => e.OrderDate).HasColumnType("datetime");

                _ = entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                _ = entity.Property(e => e.ShipAddress).HasMaxLength(60);

                _ = entity.Property(e => e.ShipCity).HasMaxLength(15);

                _ = entity.Property(e => e.ShipCountry).HasMaxLength(15);

                _ = entity.Property(e => e.ShipName).HasMaxLength(40);

                _ = entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.ShipRegion).HasMaxLength(15);

                _ = entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                _ = entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");

                _ = entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Orders_Employees");

                _ = entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("FK_Orders_Shippers");
            });

            _ = modelBuilder.Entity<OrderDetail>(entity =>
            {
                _ = entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_Order_Details");

                _ = entity.ToTable("Order Details");

                _ = entity.HasIndex(e => e.OrderId, "OrderID");

                _ = entity.HasIndex(e => e.OrderId, "OrdersOrder_Details");

                _ = entity.HasIndex(e => e.ProductId, "ProductID");

                _ = entity.HasIndex(e => e.ProductId, "ProductsOrder_Details");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.ProductId).HasColumnName("ProductID");

                _ = entity.Property(e => e.Quantity).HasDefaultValueSql("(1)");

                _ = entity.Property(e => e.UnitPrice).HasColumnType("money");

                _ = entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Orders");

                _ = entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Details_Products");
            });

            _ = modelBuilder.Entity<OrderDetailsExtended>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Order Details Extended");

                _ = entity.Property(e => e.ExtendedPrice).HasColumnType("money");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.ProductId).HasColumnName("ProductID");

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            _ = modelBuilder.Entity<OrderSubtotal>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Order Subtotals");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            _ = modelBuilder.Entity<OrdersQry>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Orders Qry");

                _ = entity.Property(e => e.Address).HasMaxLength(60);

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.Country).HasMaxLength(15);

                _ = entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();

                _ = entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                _ = entity.Property(e => e.Freight).HasColumnType("money");

                _ = entity.Property(e => e.OrderDate).HasColumnType("datetime");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.PostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.Region).HasMaxLength(15);

                _ = entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                _ = entity.Property(e => e.ShipAddress).HasMaxLength(60);

                _ = entity.Property(e => e.ShipCity).HasMaxLength(15);

                _ = entity.Property(e => e.ShipCountry).HasMaxLength(15);

                _ = entity.Property(e => e.ShipName).HasMaxLength(40);

                _ = entity.Property(e => e.ShipPostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.ShipRegion).HasMaxLength(15);

                _ = entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });

            _ = modelBuilder.Entity<Product>(entity =>
            {
                _ = entity.HasIndex(e => e.CategoryId, "CategoriesProducts");

                _ = entity.HasIndex(e => e.CategoryId, "CategoryID");

                _ = entity.HasIndex(e => e.ProductName, "ProductName");

                _ = entity.HasIndex(e => e.SupplierId, "SupplierID");

                _ = entity.HasIndex(e => e.SupplierId, "SuppliersProducts");

                _ = entity.Property(e => e.ProductId).HasColumnName("ProductID");

                _ = entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

                _ = entity.Property(e => e.ReorderLevel).HasDefaultValueSql("(0)");

                _ = entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                _ = entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                _ = entity.Property(e => e.UnitsInStock).HasDefaultValueSql("(0)");

                _ = entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("(0)");

                _ = entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                _ = entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            _ = modelBuilder.Entity<ProductSalesFor1997>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Product Sales for 1997");

                _ = entity.Property(e => e.CategoryName).HasMaxLength(15);

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            _ = modelBuilder.Entity<ProductsAboveAveragePrice>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Products Above Average Price");

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            _ = modelBuilder.Entity<ProductsByCategory>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Products by Category");

                _ = entity.Property(e => e.CategoryName).HasMaxLength(15);

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            });

            _ = modelBuilder.Entity<QuarterlyOrder>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Quarterly Orders");

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.Country).HasMaxLength(15);

                _ = entity.Property(e => e.CustomerId)
                    .HasMaxLength(5)
                    .HasColumnName("CustomerID")
                    .IsFixedLength();
            });

            _ = modelBuilder.Entity<Region>(entity =>
            {
                _ = entity.HasKey(e => e.RegionId)
                    .IsClustered(false);

                _ = entity.ToTable("Region");

                _ = entity.Property(e => e.RegionId)
                    .ValueGeneratedNever()
                    .HasColumnName("RegionID");

                _ = entity.Property(e => e.RegionDescription)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            _ = modelBuilder.Entity<SalesByCategory>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Sales by Category");

                _ = entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                _ = entity.Property(e => e.CategoryName).HasMaxLength(15);

                _ = entity.Property(e => e.ProductName).HasMaxLength(40);

                _ = entity.Property(e => e.ProductSales).HasColumnType("money");
            });

            _ = modelBuilder.Entity<SalesTotalsByAmount>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Sales Totals by Amount");

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.SaleAmount).HasColumnType("money");

                _ = entity.Property(e => e.ShippedDate).HasColumnType("datetime");
            });

            _ = modelBuilder.Entity<Shipper>(entity =>
            {
                _ = entity.Property(e => e.ShipperId).HasColumnName("ShipperID");

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.Phone).HasMaxLength(24);
            });

            _ = modelBuilder.Entity<SummaryOfSalesByQuarter>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Summary of Sales by Quarter");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                _ = entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            _ = modelBuilder.Entity<SummaryOfSalesByYear>(entity =>
            {
                _ = entity.HasNoKey();

                _ = entity.ToView("Summary of Sales by Year");

                _ = entity.Property(e => e.OrderId).HasColumnName("OrderID");

                _ = entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                _ = entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            _ = modelBuilder.Entity<Supplier>(entity =>
            {
                _ = entity.HasIndex(e => e.CompanyName, "CompanyName");

                _ = entity.HasIndex(e => e.PostalCode, "PostalCode");

                _ = entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                _ = entity.Property(e => e.Address).HasMaxLength(60);

                _ = entity.Property(e => e.City).HasMaxLength(15);

                _ = entity.Property(e => e.CompanyName).HasMaxLength(40);

                _ = entity.Property(e => e.ContactName).HasMaxLength(30);

                _ = entity.Property(e => e.ContactTitle).HasMaxLength(30);

                _ = entity.Property(e => e.Country).HasMaxLength(15);

                _ = entity.Property(e => e.Fax).HasMaxLength(24);

                _ = entity.Property(e => e.HomePage).HasColumnType("ntext");

                _ = entity.Property(e => e.Phone).HasMaxLength(24);

                _ = entity.Property(e => e.PostalCode).HasMaxLength(10);

                _ = entity.Property(e => e.Region).HasMaxLength(15);
            });

            _ = modelBuilder.Entity<Territory>(entity =>
            {
                _ = entity.HasKey(e => e.TerritoryId)
                    .IsClustered(false);

                _ = entity.Property(e => e.TerritoryId)
                    .HasMaxLength(20)
                    .HasColumnName("TerritoryID");

                _ = entity.Property(e => e.RegionId).HasColumnName("RegionID");

                _ = entity.Property(e => e.TerritoryDescription)
                    .HasMaxLength(50)
                    .IsFixedLength();

                _ = entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Territories_Region");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
