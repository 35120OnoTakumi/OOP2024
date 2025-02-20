using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelApp.Services;

var builder = WebApplication.CreateBuilder(args);

// セッションを使用するサービス追加
builder.Services.AddDistributedMemoryCache();  // メモリキャッシュ設定
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // セッションの有効期限
});

builder.Services.AddHttpClient<RakutenTravelApiClient>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// セッションミドルウェア追加
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();