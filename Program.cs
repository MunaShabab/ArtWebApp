using ArtWebApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
	// Password settings.
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 6;
	options.Password.RequiredUniqueChars = 1;

	// Lockout settings.
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.AllowedForNewUsers = true;

	// User settings.
	options.User.AllowedUserNameCharacters =
	"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
	// Cookie settings
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

	options.LoginPath = "/Identity/Account/Login";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.SlidingExpiration = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
using (var scope= app.Services.CreateScope())
{
	var roleManager= scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	var roles = new[] { "Admin", "Manager", "Member" };
	foreach (var role in roles)
	{
		if(!await roleManager.RoleExistsAsync(role))
		{
			await roleManager.CreateAsync(new IdentityRole(role));
		}

	}
}
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
	string email = "admin@admin.com";
	string password = "Passw0rd!";
	if (await userManager.FindByEmailAsync(email) == null)
	{
		//create a user
		var user = new IdentityUser();
		user.UserName = email;
		user.Email = email;
		
		await userManager.CreateAsync (user, password);
		//assign the user a role
		await userManager.AddToRoleAsync(user, "Admin");

	}
	string munaEmail = "muna.shabab@gmail.com";
	string munaPassword = "Pa$$w0rd";
	if(await userManager.FindByEmailAsync(munaEmail) == null)
	{
		var userMuna = new IdentityUser();
		userMuna.UserName = munaEmail;
		userMuna.Email = munaPassword;

		await userManager.CreateAsync(userMuna, munaPassword);

		await userManager.AddToRoleAsync(userMuna, "Manager");

	}
	
}

app.Run();
