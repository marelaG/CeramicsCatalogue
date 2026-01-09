using System.Reflection;
using GancewskaKerebinska.CeramicsCatalogue.BL.Services;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces;
using GancewskaKerebinska.CeramicsCatalogue.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Load DAO assembly via Reflection
var daoAssemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DAOMock.dll");
if (!File.Exists(daoAssemblyPath))
{
   
    
    var devPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\DAO\bin\Debug\net9.0\DAO.dll"));
    if (File.Exists(devPath))
    {
        daoAssemblyPath = devPath;
    }
}

Assembly daoAssembly;
try 
{
    daoAssembly = Assembly.LoadFrom(daoAssemblyPath);
}
catch (Exception ex)
{
    throw new Exception($"Could not load DAO assembly from {daoAssemblyPath}. Make sure the DAO project is built and the DLL is available.", ex);
}

// Helper function to register types
void RegisterType<T>(Assembly assembly, IServiceCollection services)
{
    var type = assembly.GetTypes()
        .FirstOrDefault(t => typeof(T).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
    
    if (type != null)
    {
        services.AddTransient(typeof(T), type);
    }
    else
    {
        // Log warning or throw? For now, let's assume it must exist.
        throw new Exception($"Could not find implementation for {typeof(T).Name} in {assembly.FullName}");
    }
}

RegisterType<ICeramicRepository>(daoAssembly, builder.Services);
RegisterType<IProducerRepository>(daoAssembly, builder.Services);
RegisterType<IDatabaseInitializer>(daoAssembly, builder.Services);

builder.Services.AddTransient<CeramicService>();
builder.Services.AddTransient<ProducerService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try 
    {
        // Use IDatabaseInitializer instead of direct context access
        var initializer = services.GetRequiredService<IDatabaseInitializer>();
        initializer.Initialize();
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
