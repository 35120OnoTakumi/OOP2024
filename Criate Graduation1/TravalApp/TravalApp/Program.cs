using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using TravalApp.Services;

var builder = WebApplication.CreateBuilder(args);

// �A�v���P�[�V�����ݒ�̃��[�h
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// �T�[�r�X�̓o�^
builder.Services.AddControllersWithViews(); // MVC�p�^�[���p�̃T�[�r�X
builder.Services.AddHttpClient<RakutenTravelService>(); // HttpClient��RakutenTravelService���g�p
builder.Services.AddRazorPages(); // Razor Pages�p

var app = builder.Build();

// �J�����ł̃f�o�b�O�p�ݒ�
if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
} else {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS���_�C���N�g�ƐÓI�t�@�C���̎g�p
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ���[�e�B���O�̐ݒ�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// �A�v���P�[�V�����̋N��
app.Run();
