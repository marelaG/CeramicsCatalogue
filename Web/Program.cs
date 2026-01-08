using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Context;
using GancewskaKerebinska.CeramicsCatalogue.DAO.Repositories;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICeramicRepository, CeramicRepositoryEf>();
builder.Services.AddTransient<IProducerRepository, ProducerRepositoryEf>();
/*builder.Services.AddTransient<ICeramicRepository, CeramicRepositoryMock>();
builder.Services.AddTransient<IProducerRepository, ProducerRepositoryMock>();*/

builder.Services.AddTransient<CeramicService>();
builder.Services.AddTransient<ProducerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try 
    {
        using var context = new CeramicsDbContext();
        //context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run("http://localhost:5001");
