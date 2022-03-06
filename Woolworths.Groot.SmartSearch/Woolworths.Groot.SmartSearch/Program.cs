using Woolworths.Groot.SmartSearch.MongoDb;
using Woolworths.Groot.SmartSearch.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IMongoClientProvider, MongoClientProvider>();
builder.Services.AddScoped<IRentSearch, RentSearch>();
builder.Services.AddScoped<IProductSearch, ProductSearch>();
builder.Services.AddScoped<IFuzzySearchOnProduct, FuzzySearchOnProduct>();
builder.Services.AddScoped<ISaveSearchTermService, SaveSearchTermService>();
builder.Services.AddScoped<IAutocompleteOnBrandService, AutocompleteOnBrandService>();
builder.Services.AddScoped<ILinkService, LinkService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.SetIsOriginAllowed(org => true)
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
