using FPTBook.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FPTBook.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;

namespace FPTBook.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("[Controller]/[Action]")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        public AdminController(ApplicationDbContext dbContext)
        {
            context = dbContext;

        }
        
        public async Task<IActionResult> Index()
        {
            var categories1 = await context.RequestCates.ToListAsync();
            ViewBag.Checks = categories1.Count;
            var categories = await context.Categories.ToListAsync();
            ViewBag.Categories = categories;
            return View(categories1);
        }

        public async Task<IActionResult> Approve(int? id)
        {
            var categories = await context.RequestCates.ToListAsync();
            var item = categories.Find(p => p.Id == id);


            var categories2 = await context.Categories.ToListAsync();
            var item2 = categories2.Find(p => p.CategoryName == item.Name);

            item2.Status = "Approve";

            context.Categories.Update(item2);

            context.RequestCates.Remove(item);

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(int? id)
        {
            var categories = await context.RequestCates.ToListAsync();
            var item = categories.Find(p => p.Id == id);

            var categories2 = await context.Categories.ToListAsync();
            var item2 = categories2.Find(p => p.CategoryName == item.Name);

            item2.Status = "Reject";

            context.Categories.Update(item2);

            context.RequestCates.Remove(item);

            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Reset()
        {
            // select user by roles
            var users = await context.Users.ToListAsync();
            var roles = await context.Roles.ToListAsync();
            ViewBag.Roles = roles;
            return View(users);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            var users = await context.Users.ToListAsync();
            var user = users.Find(p => p.Id == id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update()
        {
            string id = Request.Form["id"];
            string new_pass = Request.Form["newpass"];
            string confirm_pass = Request.Form["confirmpass"];

            ViewData["NewPass"] = new_pass;
            ViewData["ConfirmPass"] = confirm_pass;

            var list_users = context.Users.ToList();
            var user = list_users.Find(p => p.Id == id);

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            var temp_user = new ApplicationUser
            {
                Id = id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };
            
            if (new_pass == confirm_pass)
            {
                var new_hash = passwordHasher.HashPassword(temp_user, new_pass);
                user.PasswordHash = new_hash;
                context.Users.Update(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Reset));
            }
            else
            {
                ViewBag.Error1 = "Confirm password is not match";
                return View("Edit", user);
            }

        }
    }
}
