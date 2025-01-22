// Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelApp.Services;

var builder = WebApplication.CreateBuilder(args);

// �T�[�r�X�̓o�^
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<RakutenTravelService>();

var app = builder.Build();

// �~�h���E�F�A�̐ݒ�
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
