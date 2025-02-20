using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelApp.Services;

var builder = WebApplication.CreateBuilder(args);

// �Z�b�V�������g�p����T�[�r�X�ǉ�
builder.Services.AddDistributedMemoryCache();  // �������L���b�V���ݒ�
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // �Z�b�V�����̗L������
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

// �Z�b�V�����~�h���E�F�A�ǉ�
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();