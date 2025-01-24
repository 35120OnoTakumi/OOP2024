// �C����: Program.cs
using TravelApp.Services;

var builder = WebApplication.CreateBuilder(args);

// �T�[�r�X�̒ǉ�
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<RakutenTravelService>();
builder.Services.AddHttpClient();

// ������C#�o�[�W�����ƃt���[�����[�N��ݒ�
builder.WebHost.ConfigureKestrel(options => options.AddServerHeader = false);

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
