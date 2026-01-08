using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Repositories;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Repositories
// Note: In a real scenario, we might want to use Dependency Injection for the DbContext as well,
// but since the current DAO implementation instantiates DbContext internally (using new CeramicsDbContext()),
// we can just register the repositories as Transient or Scoped.
builder.Services.AddTransient<ICeramicRepository, CeramicRepositoryEf>();
builder.Services.AddTransient<IProducerRepository, ProducerRepositoryEf>();

// Register Services
builder.Services.AddTransient<CeramicService>();
builder.Services.AddTransient<ProducerService>();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
