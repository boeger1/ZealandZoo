using ZealandZooAPP.Services;
using ZealandZooLIB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication("MyCookie").AddCookie("MyCookie", options => { options.Cookie.Name = "MyCookie"; });


builder.Services
    .AddSingleton<EventRepoService>()
    .AddSingleton<CalendarService>()
    .AddSingleton<StorageItemRepoService>()
    .AddSingleton<ImageRepoService>()
    .AddSingleton<StudentRepoService>()
    .AddSingleton<ParticipantRepoServices>()
    .AddSingleton<IFileService, LocalFileService>()
    .AddSingleton<BulletRepoService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();

app.Run();