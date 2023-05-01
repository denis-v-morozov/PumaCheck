using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

//------------------------------------------------------------
//Denis note: DI container =>  registering all services with Ioc

// Mocked data to run app without Entity Framwork/DB support
//builder.Services.AddScoped<ICustomerRepository, MockCustomerRepository>(); //Denis note: scoped so that it is singleton per service request
//builder.Services.AddScoped<IOrderRepository, MockOrderRepository>();
//builder.Services.AddScoped<IOrderDetailedTaskRepository, MockOrderDetailedTaskRepository>();

// Uncomment 3 lines above and uncomment 3 abov to run without DB support
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailedTaskRepository, OrderDetailedTaskRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();


//------------------------------------------------------------
//Denis note: register Entity Framework => PantherDbContextConnection that I added in appsettings.json
builder.Services.AddDbContext<PantherDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:PantherDbContextConnection"]);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Denis note: added for debugging - but not quite working with the good output with info
    app.UseDeveloperExceptionPage();

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//denis note: "{controller=Home}/{action=Index}/{id?}"

//Denis note: putting initial data into DB if it doesn't have any
DbInitializer.Seed(app);

app.Run();
