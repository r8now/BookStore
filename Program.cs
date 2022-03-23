using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddRazorPages();

builder.Services.AddDbContext<BookStoreContext>(options => {
options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreContext"));
});

builder.Services.AddDefaultIdentity<DefaultUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BookStoreContext>();


builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseSqlServer("BookStoreContext"));


//binder dessa två tillsammans 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//lägga till services för sessions ska fungera i Cart
builder.Services.AddScoped<Cart>(sp => Cart.GetCart(sp));

// Add services to the container.
builder.Services.AddControllersWithViews();

//-- tillägg
builder.Services.AddDistributedMemoryCache();

//Deafult värde för sessions 20 min
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    //options.IdleTimeout= TimeSpan.FromSeconds(10);
});

var app = builder.Build();

//Inställningar för att seeda data till databasen
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {

       var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error from seedData");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
//Lägga till usesession.
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Store}/{action=Index}/{id?}");
app.MapRazorPages();

//Seed database
//app.Seed(app);

app.Run();
