using FINAL_PROJECT_Meow.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINAL_PROJECT_Meow.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoleViewModels = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoleViewModels.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Roles = roles.ToList(),
                    AllRoles = SystemRoles.AllRoles.ToList()
                });
            }

            return View(userRoleViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(string userId, string role, bool isSelected)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var currentUserRoles = await _userManager.GetRolesAsync(user);

            if (isSelected)
            {
                if (!currentUserRoles.Contains(role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }
            else
            {
                if (currentUserRoles.Contains(role))
                {
                    // Prevent removing the last admin
                    if (role == SystemRoles.Admin)
                    {
                        var adminUsers = await _userManager.GetUsersInRoleAsync(SystemRoles.Admin);
                        if (adminUsers.Count <= 1)
                        {
                            return Json(new { success = false, message = "Cannot remove the last admin user." });
                        }
                    }
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            return Json(new { success = true });
        }
    }

    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public List<string> Roles { get; set; }
        public List<string> AllRoles { get; set; }
    }
}