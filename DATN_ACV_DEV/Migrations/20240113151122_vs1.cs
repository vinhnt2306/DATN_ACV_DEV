using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATN_ACV_DEV.Migrations
{
    /// <inheritdoc />
    public partial class vs1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_Cart",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartAdmin = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Color",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Color", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Funtions",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortIndex = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Funtions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_GroupCustomer",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MinPoint = table.Column<int>(type: "int", nullable: false),
                    MaxPoint = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_GroupCustomer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Image",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    InAcitve = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Image", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Material",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Material", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_PaymentMethod",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_PaymentMethod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Permission",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SortIndex = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Policy",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Policy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Properties",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Properties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Supplier",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProvideProducst = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    InActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_Voucher",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupCustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Voucher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tb_Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceNet = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ImageID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VAT = table.Column<bool>(type: "bit", nullable: true),
                    Warranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    weight = table.Column<int>(type: "int", nullable: true),
                    length = table.Column<int>(type: "int", nullable: true),
                    width = table.Column<int>(type: "int", nullable: true),
                    height = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Produst", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Produst_tb_Category",
                        column: x => x.CategoryID,
                        principalTable: "tb_Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Customer",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    YearOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    Point = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupCustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Customer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Customer_tb_GroupCustomer",
                        column: x => x.GroupCustomerID,
                        principalTable: "tb_GroupCustomer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_FuntionForPermission",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuntionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuntionForPermission", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_FuntionForPermission_tb_Funtions",
                        column: x => x.FuntionID,
                        principalTable: "tb_Funtions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_FuntionForPermission_tb_Permission",
                        column: x => x.PermissionID,
                        principalTable: "tb_Permission",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Promotion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecentDiscount = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PolicyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Promotion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Promotion_tb_Policy",
                        column: x => x.PolicyID,
                        principalTable: "tb_Policy",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Invoice",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    QuantityProduct = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    InputDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Invoice_tb_Supplier",
                        column: x => x.SupplierID,
                        principalTable: "tb_Supplier",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_User_tb_UserGroup",
                        column: x => x.UserGroupId,
                        principalTable: "tb_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_CartDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CartID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CartDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_CartDetail_tb_Cart",
                        column: x => x.CartID,
                        principalTable: "tb_Cart",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_CartDetail_tb_Produst",
                        column: x => x.ProductID,
                        principalTable: "tb_Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Account",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Account", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Account_tb_Customer",
                        column: x => x.CustomerID,
                        principalTable: "tb_Customer",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_CustomerVoucher",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_CustomerVoucher", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_tb_CustomerVoucher_tb_Customer",
                        column: x => x.CustomerID,
                        principalTable: "tb_Customer",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_CustomerVoucher_tb_Voucher",
                        column: x => x.VoucherID,
                        principalTable: "tb_Voucher",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_UserFuntion",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuntionForPermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_UserFuntion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_UserFuntion_tb_FuntionForPermission",
                        column: x => x.FuntionForPermissionID,
                        principalTable: "tb_FuntionForPermission",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_InvoiceDetail",
                columns: table => new
                {
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_InvoiceDetail", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_tb_InvoiceDetail_tb_Invoice",
                        column: x => x.InvoiceID,
                        principalTable: "tb_Invoice",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_InvoiceDetail_tb_Produst",
                        column: x => x.ProductID,
                        principalTable: "tb_Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_AddressDelivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    provinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proviceId = table.Column<int>(type: "int", nullable: false),
                    districtName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    districtId = table.Column<int>(type: "int", nullable: false),
                    wardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wardId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: true),
                    isDelete = table.Column<bool>(type: "bit", nullable: true),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    receiverName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    receiverPhone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_AddressDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_AddressDelivery_tb_Account",
                        column: x => x.accountId,
                        principalTable: "tb_Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Order",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PaymentMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AmountShip = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TotalAmountDiscount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    OrderCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderCodeGHN = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    AddressDeliveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderCounter = table.Column<bool>(type: "bit", nullable: true),
                    ReasionCancel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberCustomer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Order_tb_Account",
                        column: x => x.AccountID,
                        principalTable: "tb_Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_Wallet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surplus = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    CreateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Wallet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_Wallet_tb_Account",
                        column: x => x.AccountID,
                        principalTable: "tb_Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tb_OrderDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Order",
                        column: x => x.OrderID,
                        principalTable: "tb_Order",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tb_OrderDetail_tb_Produst",
                        column: x => x.ProductID,
                        principalTable: "tb_Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TbOrderHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKhachHang = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdBoss = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOrderHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbOrderHistories_tb_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "tb_Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Account_CustomerID",
                table: "tb_Account",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_AddressDelivery_accountId",
                table: "tb_AddressDelivery",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_CartDetail_CartID",
                table: "tb_CartDetail",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_CartDetail_ProductID",
                table: "tb_CartDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Customer_GroupCustomerID",
                table: "tb_Customer",
                column: "GroupCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_CustomerVoucher_VoucherID",
                table: "tb_CustomerVoucher",
                column: "VoucherID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_FuntionForPermission_FuntionID",
                table: "tb_FuntionForPermission",
                column: "FuntionID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_FuntionForPermission_PermissionID",
                table: "tb_FuntionForPermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Invoice_SupplierID",
                table: "tb_Invoice",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_InvoiceDetail_ProductID",
                table: "tb_InvoiceDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Order_AccountID",
                table: "tb_Order",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OrderDetail_OrderID",
                table: "tb_OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_OrderDetail_ProductID",
                table: "tb_OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Products_CategoryID",
                table: "tb_Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Promotion_PolicyID",
                table: "tb_Promotion",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_User_UserGroupId",
                table: "tb_User",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_UserFuntion_FuntionForPermissionID",
                table: "tb_UserFuntion",
                column: "FuntionForPermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Wallet_AccountID",
                table: "tb_Wallet",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TbOrderHistories_OrderId",
                table: "TbOrderHistories",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_AddressDelivery");

            migrationBuilder.DropTable(
                name: "tb_CartDetail");

            migrationBuilder.DropTable(
                name: "tb_Color");

            migrationBuilder.DropTable(
                name: "tb_CustomerVoucher");

            migrationBuilder.DropTable(
                name: "tb_Image");

            migrationBuilder.DropTable(
                name: "tb_InvoiceDetail");

            migrationBuilder.DropTable(
                name: "tb_Material");

            migrationBuilder.DropTable(
                name: "tb_OrderDetail");

            migrationBuilder.DropTable(
                name: "tb_PaymentMethod");

            migrationBuilder.DropTable(
                name: "tb_Promotion");

            migrationBuilder.DropTable(
                name: "tb_Properties");

            migrationBuilder.DropTable(
                name: "tb_User");

            migrationBuilder.DropTable(
                name: "tb_UserFuntion");

            migrationBuilder.DropTable(
                name: "tb_Wallet");

            migrationBuilder.DropTable(
                name: "TbOrderHistories");

            migrationBuilder.DropTable(
                name: "tb_Cart");

            migrationBuilder.DropTable(
                name: "tb_Voucher");

            migrationBuilder.DropTable(
                name: "tb_Invoice");

            migrationBuilder.DropTable(
                name: "tb_Products");

            migrationBuilder.DropTable(
                name: "tb_Policy");

            migrationBuilder.DropTable(
                name: "tb_UserGroup");

            migrationBuilder.DropTable(
                name: "tb_FuntionForPermission");

            migrationBuilder.DropTable(
                name: "tb_Order");

            migrationBuilder.DropTable(
                name: "tb_Supplier");

            migrationBuilder.DropTable(
                name: "tb_Category");

            migrationBuilder.DropTable(
                name: "tb_Funtions");

            migrationBuilder.DropTable(
                name: "tb_Permission");

            migrationBuilder.DropTable(
                name: "tb_Account");

            migrationBuilder.DropTable(
                name: "tb_Customer");

            migrationBuilder.DropTable(
                name: "tb_GroupCustomer");
        }
    }
}
