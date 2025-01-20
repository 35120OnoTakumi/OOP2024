var builder = WebApplication.CreateBuilder(args);

// サービスを登録
builder.Services.AddControllersWithViews();

// IHttpContextAccessor を登録
builder.Services.AddHttpContextAccessor();

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
