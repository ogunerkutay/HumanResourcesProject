using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    WorkShiftID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BreakTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.WorkShiftID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TCNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnualLeave = table.Column<int>(type: "int", nullable: false, computedColumnSql: "IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 15, 26, IIF((DATEDIFF(year, [EmploymentDate], GETDATE())) > 5, 20, 14))"),
                    remainingDayOff = table.Column<int>(type: "int", nullable: false),
                    GrossSalary = table.Column<double>(type: "float", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ManagerApproval = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_Expenses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentAndWorkShift",
                columns: table => new
                {
                    WorkShiftID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    DepartmentAndWorkShiftID = table.Column<int>(type: "int", nullable: false),
                    WorkDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentAndWorkShift", x => new { x.WorkShiftID, x.DepartmentID });
                    table.ForeignKey(
                        name: "FK_DepartmentAndWorkShift_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentAndWorkShift_WorkShifts_WorkShiftID",
                        column: x => x.WorkShiftID,
                        principalTable: "WorkShifts",
                        principalColumn: "WorkShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserAndWorkShift",
                columns: table => new
                {
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    WorkShiftID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAndWorkShift", x => new { x.WorkShiftID, x.AppUserID });
                    table.ForeignKey(
                        name: "FK_AppUserAndWorkShift_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAndWorkShift_WorkShifts_WorkShiftID",
                        column: x => x.WorkShiftID,
                        principalTable: "WorkShifts",
                        principalColumn: "WorkShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayOffs",
                columns: table => new
                {
                    DayOffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DepartmentApproval = table.Column<bool>(type: "bit", nullable: false),
                    ManagerApproval = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOffs", x => x.DayOffID);
                    table.ForeignKey(
                        name: "FK_DayOffs_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debits",
                columns: table => new
                {
                    DebitID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debits", x => x.DebitID);
                    table.ForeignKey(
                        name: "FK_Debits_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentDetails",
                columns: table => new
                {
                    EmploymentDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DismissalDate = table.Column<DateTime>(type: "Date", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentDetails", x => x.EmploymentDetailsID);
                    table.ForeignKey(
                        name: "FK_EmploymentDetails_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Overtimes",
                columns: table => new
                {
                    OvertimeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OvertimeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    ManHour = table.Column<double>(type: "float", nullable: false),
                    ManagerApproval = table.Column<bool>(type: "bit", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overtimes", x => x.OvertimeID);
                    table.ForeignKey(
                        name: "FK_Overtimes_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHours",
                columns: table => new
                {
                    WorkHourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserID = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHours", x => x.WorkHourID);
                    table.ForeignKey(
                        name: "FK_WorkHours_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "fce31a52-67af-4a8d-b592-5e7fc4d097a2", "Yönetici", null },
                    { 2, "6ce33da1-9a60-4ad8-b656-803893851200", "Personel", null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentDescription", "DepartmentName" },
                values: new object[,]
                {
                    { 1, null, "Yönetim" },
                    { 2, null, "Üretim" },
                    { 3, null, "IT" },
                    { 4, null, "İnsan Kaynakları" },
                    { 5, null, "Muhasebe" },
                    { 6, null, "Pazarlama" },
                    { 7, null, "Satın Alma" },
                    { 8, null, "Lojistik" },
                    { 9, null, "Güvenlik" },
                    { 10, null, "Mühendislik" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "BirthDate", "ConcurrencyStamp", "DepartmentID", "Email", "EmailConfirmed", "EmploymentDate", "FirstName", "Gender", "GrossSalary", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecondName", "SecurityStamp", "Status", "TCNO", "Title", "TwoFactorEnabled", "UserName", "remainingDayOff" },
                values: new object[,]
                {
                    { 1, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1978, 9, 28, 22, 6, 25, 868, DateTimeKind.Local).AddTicks(7157), "292eb366-e70e-414d-beb3-65aedb776c15", 1, "jane.doe@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 872, DateTimeKind.Local).AddTicks(8175), "Jane", 1, 10000.0, "face10.jpg", "Doe", false, null, "JANE.DOE@SIRKETADI.COM", "JANE.DOE", "AQAAAAEAACcQAAAAEC1hOVDCTECysOT/3bQJSr2CUJpsfusJMqa66HGAifWuB4LMMsvw/ImcUNHuphjrRQ==", "5325212112", true, "Doe", "65C5E7CD7F053342A01A595BFCD6E8BC", true, "12345678912", "Yönetici", false, "jane.doe", 0 },
                    { 2, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1996, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3729), "0e217fb6-3352-4dfe-9005-75a7b80c648e", 2, "ogun.erkutay@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3752), "Ogün", 2, 10000.0, "pic-1.jpg", "Erkutay", false, null, "OGUN.ERKUTAY@SIRKETADI.COM", "OGUN.ERKUTAY", "AQAAAAEAACcQAAAAEBg+GoCve/4RkXw9Y8RJAQ/hoMTkFXQDd3yDl8rrbV/gZzmWP80QmhzbKlqCyXM+uw==", "5325212112", true, "Erkutay", "7ED842E82E049244B3ECCDC3030EABC8", true, "12345678912", "Memur", false, "ogun.erkutay", 0 },
                    { 3, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1995, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3763), "3e18302a-80b7-481d-a1c1-936590886c8a", 3, "esraezgi.erdogan@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3765), "Esra", 1, 10000.0, "pic-2.jpg", "Erdoğan", false, null, "ESRAEZGI.ERDOGAN@SIRKETADI.COM", "ESRAEZGI.ERDOGAN", "AQAAAAEAACcQAAAAEAKGQ3DYGBgOL6QDbt0m+Iturg9CqIqwyn7C8Z17/dcSkswX2osQXHmsm2iHQS25PQ==", "5325212112", true, "Ezgi", "BF8993B3A53E5749B4A4F5184CF2F1C9", true, "12345678912", "Aşçı", false, "esraezgi.erdogan", 0 },
                    { 4, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1994, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3771), "77b49453-f688-4028-aa25-2ca297a9c62b", 4, "sinem.pamik@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3773), "Sinem", 1, 10000.0, "pic-2.jpg", "Pamık", false, null, "SINEM.PAMIK@SIRKETADI.COM", "SINEM.PAMIK", "AQAAAAEAACcQAAAAEDxYS+dudQnARoCaCOe8azROOsyfYJUIYDoy5KM9bG1TCHGwXDNYVHuPVspTIW7uPw==", "5325212112", true, "", "C36443C1AB5C8D438563464AE23FB6B5", true, "12345678912", "Çayçı", false, "sinem.pamik", 0 },
                    { 5, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1993, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3785), "b1142127-1511-409a-bf5f-d9d84e8c02a3", 5, "cerennur.genlikkara@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3787), "Ceren", 1, 10000.0, "pic-2.jpg", "Genlik Kara", false, null, "CERENNUR.GENLIKKARA@SIRKETADI.COM", "CERENNUR.GENLIK", "AQAAAAEAACcQAAAAENb4IMb6Dx7vyNiE+NcIgS9fU/Hc3EbIzx3005t/ZAaYB7mpGOevYI0O0qpSoTCQfQ==", "5325212112", true, "Nur", "526F881DF1023D4FA1D83FB427E755A8", true, "12345678912", "Reklamcı", false, "cerennur.genlikkara", 0 },
                    { 6, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1992, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3792), "b0362da7-dbd5-40a2-b18a-ec2e57b5570d", 6, "berkayfettah.hacioglu@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3794), "Berkay", 2, 10000.0, "pic-1.jpg", "Hacıoğlu", false, null, "BERKAYFETTAH.HACIOGLU@SIRKETADI.COM", "BERKAYFETTAH.HACIOGLU", "AQAAAAEAACcQAAAAED+BhI3v8QwcGPruEq4sOfrcbukQvXAAZe2WhBNfS1ocqucgswPY2VisnxdcaTfJAg==", "5325212112", true, "Fettah", "3728E22116F5864B8C857C6A81C1893F", true, "12345678912", "Pazarlamacı", false, "berkayfettah.hacioglu", 0 },
                    { 7, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1991, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3800), "75304013-b343-4137-aeb3-4b6dd5445c93", 7, "mahmutmustafa.zekeriyaoglu@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3801), "Mahmut", 2, 10000.0, "pic-1.jpg", "Zekeriyaoğlu", false, null, "MAHMUTMUSTAFA.ZEKERIYAOGLU@SIRKETADI.COM", "MAHMUTMUSTAFA.ZEKERIYEOGLU", "AQAAAAEAACcQAAAAECk3s4g7RfcBa4tJOqJbHsPRl0U1iY/FJBoDsMGMrBSQMIindjr5bZR+Dq9yw0ob8Q==", "5325212112", true, "Mustafa", "1E1C4EB0861F3A4FA521A3117F93D7C1", true, "12345678912", "Satışcı", false, "mahmutmustafa.zekeriyaoglu", 0 },
                    { 8, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1990, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3809), "90b6255b-5e4e-4532-956e-f6bde6b8c78c", 8, "ismaelabraham.mcdoe@sirketadi.com", true, new DateTime(2017, 9, 28, 22, 6, 25, 873, DateTimeKind.Local).AddTicks(3810), "Ismael", 2, 10000.0, "pic-1.jpg", "McDoe", false, null, "ISMAELABRAHAM.MCDOE@SIRKETADI.COM", "ISMAELABRAHAM.MCDOE", "AQAAAAEAACcQAAAAEH50QJ51oS+VW7g5Aef95B4CcJ91qm+0tyrag6NQPggIWHnI4QVjDxlRzVt4WdVpZg==", "5325212112", true, "Abraham", "031121BF604BBF4EB17C3CEA8B0D866B", true, "12345678912", "Gezici", false, "ismaelabraham.mcdoe", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAndWorkShift_AppUserID",
                table: "AppUserAndWorkShift",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DayOffs_AppUserID",
                table: "DayOffs",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Debits_AppUserID",
                table: "Debits",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentAndWorkShift_DepartmentID",
                table: "DepartmentAndWorkShift",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentDetails_AppUserID",
                table: "EmploymentDetails",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_DepartmentID",
                table: "Expenses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Overtimes_AppUserID",
                table: "Overtimes",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHours_AppUserID",
                table: "WorkHours",
                column: "AppUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserAndWorkShift");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DayOffs");

            migrationBuilder.DropTable(
                name: "Debits");

            migrationBuilder.DropTable(
                name: "DepartmentAndWorkShift");

            migrationBuilder.DropTable(
                name: "EmploymentDetails");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Overtimes");

            migrationBuilder.DropTable(
                name: "WorkHours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
