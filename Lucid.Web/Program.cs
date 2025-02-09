using Lucid.Database;
using Lucid.Repositories.Abstractions;
using Lucid.Repositories.CustomerRepositories;
using Lucid.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lucid.Services.CustomerServices;
using Lucid.Repositories.VanRepositories;
using Lucid.Services.VanServices;
using Lucid.Web.Services;
using Lucid.Services.CustomerTypeServices;
using Lucid.Services.ProductServices;
using Lucid.Repositories.ProductRepositories;
using Lucid.Repositories.SaleRepositories;
using Lucid.Services.SaleServices;
using Lucid.Services.PaymentServices;
using Lucid.Repositories.PaymentRepositories;
using Lucid.Services;
using Lucid.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddTransient<IVanRepository, VanRepository>();
builder.Services.AddTransient<IVanService, VanService>();

builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();

builder.Services.AddTransient<ICustomerTypeService, CustomerTypeService>();
builder.Services.AddTransient<ICustomerTypeRepository, CustomerTypeRepository>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddTransient<ISaleService, SaleService>();
builder.Services.AddTransient<ISaleRepository, SaleRepository>();

builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();

builder.Services.AddTransient<IExpenseTypeService, ExpenseTypeService>();
builder.Services.AddTransient<IExpenseTypeRepository, ExpenseTypeRepository>();

builder.Services.AddTransient<IExpenseService, ExpenseService>();
builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
