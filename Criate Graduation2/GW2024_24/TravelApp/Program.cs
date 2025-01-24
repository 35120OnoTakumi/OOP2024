// 修正版: Program.cs
using TravelApp.Services;

var builder = WebApplication.CreateBuilder(args);

// サービスの追加
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<RakutenTravelService>();
builder.Services.AddHttpClient();

// 正しいC#バージョンとフレームワークを設定
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

var app = builder.Build();

// ミドルウェアの設定
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
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
