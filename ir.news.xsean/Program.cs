using ir.news.xsean;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
IConfigurationRoot configuration = new ConfigurationBuilder()
	.SetBasePath(projectPath)
	.AddJsonFile("appsettings.json")
	.Build();
builder.Services.AddDbContext<dbcontext>(
	options => options.UseSqlServer(configuration.GetConnectionString("DBConnection"), sqlServerOptionsAction: sqloptions =>
	{
		sqloptions.EnableRetryOnFailure();
	}));
builder.Services.AddRazorPages();
builder.Services.AddResponseCompression(options =>
{
	options.EnableForHttps = true;
});
builder.WebHost.ConfigureKestrel((context, options) =>
{

});

builder.WebHost.UseUrls("http://*:8625");

var app = builder.Build();
if (app.Environment.IsDevelopment())
	app.UseDeveloperExceptionPage();
else
	app.UseExceptionHandler("/Home/Error");
app.UseResponseCompression();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(name: "default",
			   pattern: "{controller=Home}/{action=Index}/{id?}", defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(name: "api",
			   pattern: "api/{controller=newsses}/{action=newss}/{id?}");
app.Run();