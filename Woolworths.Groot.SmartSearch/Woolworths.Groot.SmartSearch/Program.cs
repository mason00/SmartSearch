using Duende.IdentityServer;
using IdentityServerHost;
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

var identityBuilder = builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;

    // see https://docs.duendesoftware.com/identityserver/v5/basics/resources
    options.EmitStaticAudienceClaim = true;
})
                .AddTestUsers(TestUsers.Users)
                ;

identityBuilder.AddInMemoryIdentityResources(Resources.Identity);
identityBuilder.AddInMemoryApiScopes(Resources.ApiScopes);
identityBuilder.AddInMemoryApiResources(Resources.ApiResources);
identityBuilder.AddInMemoryClients(Clients.List);

//// this is only needed for the JAR and JWT samples and adds supports for JWT-based client authentication
//identityBuilder.AddJwtBearerClientAuthentication();

builder.Services.AddAuthentication()
    .AddOpenIdConnect("Google", "Sign-in with Google", options =>
    {
        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.ForwardSignOut = IdentityServerConstants.DefaultCookieAuthenticationScheme;

        options.Authority = "https://accounts.google.com/";
        options.ClientId = "535648816304-3euqfipgu7tbje7re64j9iqmskalsit3.apps.googleusercontent.com";
        options.ClientSecret = "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";

        options.CallbackPath = "/signin-google";
        options.Scope.Add("email");
    });
//.AddGoogle("Google", options =>
//{
//    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

//    options.ClientId = "535648816304-3euqfipgu7tbje7re64j9iqmskalsit3.apps.googleusercontent.com";
//    options.ClientSecret = "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";
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
