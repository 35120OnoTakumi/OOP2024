var builder = WebApplication.CreateBuilder(args);

// �T�[�r�X��o�^
builder.Services.AddControllersWithViews();

// IHttpContextAccessor ��o�^
builder.Services.AddHttpContextAccessor();

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
