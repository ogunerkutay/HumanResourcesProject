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
                    { 1, "f947b190-e670-4319-8539-f776e0b53090", "Yönetici", null },
                    { 2, "45e451d6-7bb9-424b-b877-e8f6ffbe354a", "Personel", null }
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
                    { 1, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1978, 9, 28, 13, 33, 43, 663, DateTimeKind.Local).AddTicks(6277), "ac9d07e8-eac6-4efa-876a-a3efb0883e51", 1, "jane.doe@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 665, DateTimeKind.Local).AddTicks(1558), "Jane", 1, 10000.0, "face10.jpg", "Doe", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Doe", "65C5E7CD7F053342A01A595BFCD6E8BC", true, "12345678912", "Yönetici", false, null, 0 },
                    { 2, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1996, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4334), "7b0487ed-137d-4d61-8c9f-052ba400d708", 2, "ogun.erkutay@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4361), "Ogün", 2, 10000.0, "pic-1.jpg", "Erkutay", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Erkutay", "7ED842E82E049244B3ECCDC3030EABC8", true, "12345678912", "Memur", false, null, 0 },
                    { 3, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1995, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4572), "d28c3cef-fb2a-4c36-bde9-da90050caf88", 3, "esraezgi.erdogan@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4579), "Esra", 1, 10000.0, "pic-2.jpg", "Erdoğan", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Ezgi", "BF8993B3A53E5749B4A4F5184CF2F1C9", true, "12345678912", "Aşçı", false, null, 0 },
                    { 4, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1994, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4605), "c937305f-8d37-4c6c-8db7-5f8cd237b68c", 4, "sinem.pamik@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4607), "Sinem", 1, 10000.0, "pic-2.jpg", "Pamık", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "", "C36443C1AB5C8D438563464AE23FB6B5", true, "12345678912", "Çayçı", false, null, 0 },
                    { 5, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1993, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4623), "ca92ced0-04ee-48d3-82f7-bf632c477cfa", 5, "cerennur.genlikkara@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4624), "Ceren", 1, 10000.0, "pic-2.jpg", "Genlik Kara", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Nur", "526F881DF1023D4FA1D83FB427E755A8", true, "12345678912", "Reklamcı", false, null, 0 },
                    { 6, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1992, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4637), "07c47b98-2ad3-4911-bd90-eee6035fcfe5", 6, "berkayfettah.hacioglu@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4639), "Berkay", 2, 10000.0, "pic-1.jpg", "Hacıoğlu", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Fettah", "3728E22116F5864B8C857C6A81C1893F", true, "12345678912", "Pazarlamacı", false, null, 0 },
                    { 7, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1991, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4659), "770b348a-4549-464d-b515-a1dd54c86f67", 7, "mahmutmustafa.zekeriyaoglu@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4660), "Mahmut", 2, 10000.0, "pic-1.jpg", "Zekeriyaoğlu", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Mustafa", "1E1C4EB0861F3A4FA521A3117F93D7C1", true, "12345678912", "Satışcı", false, null, 0 },
                    { 8, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1990, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4672), "9a476f0e-aa97-4d61-9a98-a6397ff8c168", 8, "ismaelabraham.mcdoe@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4674), "Ismael", 2, 10000.0, "pic-1.jpg", "McDoe", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Abraham", "031121BF604BBF4EB17C3CEA8B0D866B", true, "12345678912", "Gezici", false, null, 0 },
                    { 9, 0, "Atatürk, Fatih Sultan Mehmet Cd. No:63, 34764 Ümraniye/İstanbul", new DateTime(1989, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4744), "513e33f8-56b8-42f4-855b-db615c353b69", 9, "azazelchristian.mcdonald@sirketadi.com", false, new DateTime(2017, 9, 28, 13, 33, 43, 666, DateTimeKind.Local).AddTicks(4746), "Azazel", 2, 10000.0, "pic-1.jpg", "MCDonald", false, null, null, null, "c873586a09e16d54ef49b9ae978cd98db8edc49aaebdb4dcf460d83514321c38", "5325212112", true, "Christian", "9C277BE24E1CCD4EABB6F2C2708F661B", false, "12345678912", "Yiyici", false, null, 0 }
                });

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
