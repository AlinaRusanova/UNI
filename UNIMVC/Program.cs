using UNI.Persistence;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Staging,
    //WebRootPath = "customwwwroot"
});



// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration;

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddPersistenceServices(config, "UniDbConnectionStrings");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Courses}/{action=List}/{id?}");

app.Run();
