using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(projectPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    //serverOptions.ListenLocalhost(8225);
});

builder.WebHost.UseIIS();
builder.WebHost.UseUrls("http://*:8225");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
