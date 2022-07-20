using HolaMundo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//EntityFramework -->MEMORIA
/*builder.Services.AddDbContext<EscuelaContext>(
    options => options.UseInMemoryDatabase(databaseName:"test")
);*/

//EntityFramework --> SQL Server
/*builder.Services.AddDbContext<EscuelaContext>(
    string connfigString = ConfigurationExtensions.GetConnectionString(this.,"DefaultConnection");
    options => options.UseSqlServer(connfigString);
);*/
string connString = ConfigurationExtensions.GetConnectionString(builder.Configuration, "DefaultConnectionString");
builder.Services.AddDbContext<EscuelaContext>(
    options => options.UseSqlServer(connString)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*ENTITY FRAMEWORK*/
using(var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    try{
        var context = services.GetRequiredService<EscuelaContext>();
        context.Database.EnsureCreated();
    }catch(Exception ex){
        var logger =  services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex,"An error creating db");
    }
}

/*ENTITY FRAMEWORK*/

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Escuela}/{action=Index}/{id?}");

app.Run();

