using ELearning.DAL.Context.Identity;
using ELearning.Helper;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.DataSeeding
{
	public class UserRoleInitializer
	{
		public static async Task Initialize(WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
					var usreManager = services.GetRequiredService<UserManager<ApplicationUser>>();
					if (!roleManager.Roles.Any())
					{
						await roleManager.CreateAsync(new IdentityRole(Roles.Instructor));
						await roleManager.CreateAsync(new IdentityRole(Roles.Student));
						await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
					}
					if (!usreManager.Users.Any())
					{
						ApplicationUser Admin = new()
						{
							Email = "Admin@gmail.com",
							UserName = "Admin",

						};
						await usreManager.CreateAsync(Admin, "Em@il.123");
						await usreManager.AddToRoleAsync(Admin, Roles.Admin);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}
	}
}
