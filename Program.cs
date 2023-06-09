using Clinica.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

 builder.Services.AddDbContext<ClinicaDB>(opts =>
 {
     opts.UseNpgsql(builder.Configuration.GetConnectionString("Local"));
 });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ADD CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;

//try
//{
//    var context = services.GetRequiredService<LuxonDB>();
//    // var userManager = services.GetRequiredService<UserManager<AppUser>>();
//    await context.Database.MigrateAsync();
//    await Seed.SeedData(context);
//}
//catch (Exception ex)
//{
//    var logger = services.GetRequiredService<ILogger<Program>>();
//    logger.LogError(ex, "An error ocurred during migration");
//}

app.Run();
