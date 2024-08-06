using ch04_Sportstore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<DataContext>(options =>
{
    //display sql parameters
    options.EnableSensitiveDataLogging(true);
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});

builder.Services.AddTransient<IRepository, DataRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseStaticFiles();

app.UseRouting(); // Enable routing

// Define endpoint routes directly
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();