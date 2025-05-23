﻿using FINAL_PROJECT_Meow.Data;
using FINAL_PROJECT_Meow.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FINAL_PROJECT_Meow.Controllers
{
    public class UsersController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }



        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUser user)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser registereduser = new();
                registereduser.LastName = user.LastName;
                registereduser.FirstName = user.FirstName;
                registereduser.MiddleName = user.MiddleName;
                registereduser.Address = user.Address;
                registereduser.PhoneNumber = user.PhoneNumber;
                registereduser.UserName = user.UserName;
                registereduser.NormalizedUserName = user.UserName;
                registereduser.Email = user.Email;
                registereduser.EmailConfirmed = true;
                registereduser.PasswordHash = user.PasswordHash;
                
                var result = await _userManager.CreateAsync(registereduser, user.PasswordHash);

                if(result.Succeeded)
                {
                    // Log the Audit Trail
                    var activity = new AuditTrail
                    {
                        Action = "Create",
                        TimeStamp = DateTime.Now,
                        IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                        UserId = userId,
                        Module = "Users",
                        AffectedTable = "Users"
                    };


                    _context.AuditTrails.Add(activity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
