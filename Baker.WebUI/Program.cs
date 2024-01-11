using Baker.DataAccessLayer.Settings;
using Baker.WebUI.CQRS.Handlers.AboutHandlers;
using Baker.WebUI.CQRS.Handlers.AboutItemHandlers;
using Baker.WebUI.CQRS.Handlers.OfferHandlers;
using Baker.WebUI.CQRS.Handlers.ServiceHandlers;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetAboutItemQueryHandler>();
builder.Services.AddScoped<CreateAboutItemCommandHandler>();
builder.Services.AddScoped<GetAboutItemByIdQueryHandler>();
builder.Services.AddScoped<UpdateAboutItemCommandHandler>();
builder.Services.AddScoped<RemoveAboutItemCommandHandler>();

builder.Services.AddScoped<GetOfferQueryHandler>();
builder.Services.AddScoped<CreateOfferCommandHandler>();
builder.Services.AddScoped<GetOfferByIdQueryHandler>();
builder.Services.AddScoped<UpdateOfferCommandHandler>();
builder.Services.AddScoped<RemoveOfferCommandHandler>();

builder.Services.AddScoped<GetServiceQueryHandler>();
builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();
builder.Services.AddScoped<RemoveServiceCommandHandler>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();