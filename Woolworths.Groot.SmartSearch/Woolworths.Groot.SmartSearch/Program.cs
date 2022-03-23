using Duende.IdentityServer;
using IdentityServerHost;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
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
builder.Services.AddSingleton<IAuthorizationHandler, MyApiHandler>();

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

// Identity server
//var identityBuilder = builder.Services.AddIdentityServer(options =>
//{
//    options.Events.RaiseErrorEvents = true;
//    options.Events.RaiseInformationEvents = true;
//    options.Events.RaiseFailureEvents = true;
//    options.Events.RaiseSuccessEvents = true;

//    // see https://docs.duendesoftware.com/identityserver/v5/basics/resources
//    options.EmitStaticAudienceClaim = true;
//})
//                .AddTestUsers(TestUsers.Users)
//                ;

//identityBuilder.AddInMemoryIdentityResources(Resources.Identity);
//identityBuilder.AddInMemoryApiScopes(Resources.ApiScopes);
//identityBuilder.AddInMemoryApiResources(Resources.ApiResources);
//identityBuilder.AddInMemoryClients(Clients.List);

//// this is only needed for the JAR and JWT samples and adds supports for JWT-based client authentication
//identityBuilder.AddJwtBearerClientAuthentication();

// google token
//builder.Services.AddAuthentication(
//    o =>
//        {
//            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//            o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//        }
//    )
//    .AddJwtBearer(o =>
//    {
//        o.SecurityTokenValidators.Clear();
//        o.SecurityTokenValidators.Add(new GoogleTokenValidator());
//    });

// Auth0
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-5cv7cv5t.us.auth0.com/";
    options.Audience = "https://woolworthsgrootsmartsearch20220220094337.azurewebsites.net/";
});

// openid
//builder.Services.AddAuthentication(
//.AddOpenIdConnect(GoogleDefaults.AuthenticationScheme, GoogleDefaults.DisplayName, options =>
//{
//options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
//options.ForwardSignOut = IdentityServerConstants.DefaultCookieAuthenticationScheme;

//options.Authority = "https://accounts.google.com/";
//options.ClientId = "535648816304-dqqvv9tnv9e38vdo0debrov4ps63jdgg.apps.googleusercontent.com";
//options.ClientSecret = "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";

//options.CallbackPath = "/signin-google";
//options.Scope.Add("email");
//})
//.AddJwtBearer(o =>
//{
//    o.SecurityTokenValidators.Clear();
//    o.SecurityTokenValidators.Add(new GoogleTokenValidator());
//    o.Audience = "535648816304-dqqvv9tnv9e38vdo0debrov4ps63jdgg.apps.googleusercontent.com";
//});


builder.Services.AddAuthorization(o => { 
    o.AddPolicy("MyPolicy", policy =>
    {
        policy.AddRequirements(new MyApiRequirement());
    });
});

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

//app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
