using PSF.WebApp.Helper;
using System.Web.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
 //void ConfigureServices(IServiceCollection services)
//{
   // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    //services.AddScoped<ISessao, Sessao>();

    //services.AddSession(o =>
    //{
      //  o.Cookie.HttpOnly = true;
        //o.Cookie.IsEssential = true;
    //});
//}
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Autenticacao}/{action=Index}/{id?}");

app.Run();
