using Baker.DataAccessLayer.Repository.Abstract;
using Baker.DataAccessLayer.Repository.Concrete;
using Baker.DataAccessLayer.Settings;
using Baker.WebUI.CQRS.Handlers.AboutHandlers;
using Baker.WebUI.CQRS.Handlers.AboutItemHandlers;
using Baker.WebUI.CQRS.Handlers.ContactHandlers;
using Baker.WebUI.CQRS.Handlers.OfferHandlers;
using Baker.WebUI.CQRS.Handlers.ServiceHandlers;
using Baker.WebUI.Mediator.Handlers.CategoryHandlers;
using Baker.WebUI.Mediator.Handlers.ProductHandlers;
using Baker.WebUI.Mediator.Handlers.TeamHandlers;
using Baker.WebUI.Mediator.Handlers.TestimonialHandlers;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.
builder.Services.AddScoped(typeof(IMongoGenericRepository<>),typeof(MongoGenericRepository<>));
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

builder.Services.AddScoped<GetAboutItemQueryHandler>();
builder.Services.AddScoped<CreateAboutItemCommandHandler>();
builder.Services.AddScoped<GetAboutItemByIdQueryHandler>();
builder.Services.AddScoped<UpdateAboutItemCommandHandler>();
builder.Services.AddScoped<RemoveAboutItemCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

builder.Services.AddScoped<GetOfferQueryHandler>();
builder.Services.AddScoped<CreateOfferCommandHandler>();
builder.Services.AddScoped<GetOfferByIdQueryHandler>();
builder.Services.AddScoped<UpdateOfferCommandHandler>();

builder.Services.AddScoped<GetServiceQueryHandler>();
builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<GetServiceByIdQueryHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();
builder.Services.AddScoped<RemoveServiceCommandHandler>();

builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();
builder.Services.AddScoped<GetTeamByIdQueryHandler>();
builder.Services.AddScoped<GetTestimonialByIdQueryHandler>();

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