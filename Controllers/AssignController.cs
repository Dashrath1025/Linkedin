using LinkedIn.Data;
using LinkedIn.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedIn.Controllers
{

    [Authorize(Roles = "Administration")]
    public class AssignController : Controller
    {
        private readonly AppDb _db;
        private readonly UserManager<IdentityUser> _userManager;

        public AssignController(UserManager<IdentityUser> userManager, AppDb db)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var userList = _db.AppUsers.ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach(var user in userList)
            {
                var role = userRole.FirstOrDefault(e => e.UserId == user.Id);
                if(role == null)
                {
                    user.Role = "null";
                }
                else
                {
                    user.Role = roles.FirstOrDefault(o => o.Id == role.RoleId).Name;

                }
            }

            return View(userList);
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            var objFromDb = _db.AppUsers.FirstOrDefault(u => u.Id == userId);
            if (objFromDb == null)
            {
                return NotFound();
            }
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            var role = userRole.FirstOrDefault(u => u.UserId == objFromDb.Id);
            if (role != null)
            {
                objFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Id;
            }
            objFromDb.RoleList = _db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = u.Name,
                Value = u.Id
            });
            return View(objFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppUser user)
        {
            if (ModelState.IsValid)
            {
                var objFromDb = _db.AppUsers.FirstOrDefault(u => u.Id == user.Id);
                if (objFromDb == null)
                {
                    return NotFound();
                }

                var userRole = _db.UserRoles.FirstOrDefault(e => e.UserId == objFromDb.Id);
                if (userRole != null)
                {
                    var previuousRole = _db.Roles.Where(u => u.Id == userRole.RoleId).Select(e => e.Name).FirstOrDefault();

                    await _userManager.RemoveFromRoleAsync(objFromDb, previuousRole);

                }
                await _userManager.AddToRoleAsync(objFromDb, _db.Roles.FirstOrDefault(u => u.Id == user.RoleId).Name);
                objFromDb.Name = user.Name;
                _db.SaveChanges();
                TempData[SD.Success] = "User has been created Successfully!";
                return RedirectToAction(nameof(Index));
            }

            user.RoleList = _db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Text = u.Name,
                Value = u.Id
            });
            return View(user);
        }


        public IActionResult Delete(string userId)
        {
            var objFromDb = _db.AppUsers.FirstOrDefault(e => e.Id == userId);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _db.AppUsers.Remove(objFromDb);
            _db.SaveChanges();
            TempData[SD.Success] = "User Deleted Successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
