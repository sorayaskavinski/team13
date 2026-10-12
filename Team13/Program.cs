using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Team13.Components;
using Team13.Components.Account;
using Team13.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Project Data (Team13Context) - Use a factory to create the DbContext for each request.
builder.Services.AddDbContextFactory<Team13Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Team13Database")));

// Authentication state for Blazor components.
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();
builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<
    AuthenticationStateProvider,
    IdentityRevalidatingAuthenticationStateProvider>();

// Configure authentication cookies.
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

// Database connection para o Identity (ApplicationDbContext)
var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// ASP.NET Core Identity.
builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddSignInManager()
.AddDefaultTokenProviders();

// No real email service is required for the current MVP.
builder.Services.AddSingleton<
    IEmailSender<ApplicationUser>,
    IdentityNoOpEmailSender>();

var app = builder.Build();


// Apply database migrations at startup.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Database for user accounts and authentication.
    var identityDb =
        services.GetRequiredService<ApplicationDbContext>();

    identityDb.Database.Migrate();

    // Database for projects and tasks.
    var projectDbFactory =
        services.GetRequiredService<IDbContextFactory<Team13Context>>();

    using var projectDb = projectDbFactory.CreateDbContext();
    projectDb.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute(
    "/not-found",
    createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Identity endpoints used by the /Account components.
app.MapAdditionalIdentityEndpoints();

app.Run();