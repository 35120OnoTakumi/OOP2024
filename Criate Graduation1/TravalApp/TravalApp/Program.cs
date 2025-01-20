using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using TravalApp.Services;

var builder = WebApplication.CreateBuilder(args);

// アプリケーション設定のロード
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// サービスの登録
builder.Services.AddControllersWithViews(); // MVCパターン用のサービス
builder.Services.AddHttpClient<RakutenTravelService>(); // HttpClientでRakutenTravelServiceを使用
builder.Services.AddRazorPages(); // Razor Pages用

var app = builder.Build();

// 開発環境でのデバッグ用設定
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
} else {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPSリダイレクトと静的ファイルの使用
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ルーティングの設定
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// アプリケーションの起動
app.Run();
