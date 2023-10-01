using LinkedIn.Data;
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
    public class RolesController : Controller
    {

        private readonly AppDb _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, AppDb db)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        [HttpGet]

        public IActionResult Upsert(string id)
        {
            if(id == null)
            {
                //create
                return View();
            }
            else
            {
                var objDb = _db.Roles.FirstOrDefault(i => i.Id == id);
                return View(objDb);
            }
        }

        public async Task<IActionResult> Upsert(IdentityRole role)
        {
            if(await _roleManager.RoleExistsAsync(role.Name))
            {
                TempData[SD.Error] = "Role Already Exist!";
                return RedirectToAction(nameof(Index));
            }

            if (string.IsNullOrEmpty(role.Id))
            {
                //create
                await _roleManager.CreateAsync(new IdentityRole { Name = role.Name });
                TempData[SD.Success] = "Role Created success";

            }
            else
            {
                var objFromDb = _db.Roles.FirstOrDefault(u => u.Id == role.Id);

                if (objFromDb == null)
                {
                    TempData[SD.Error] = "Role Not Found!";
                    return RedirectToAction("Index");
                }

                objFromDb.Name = role.Name;
                objFromDb.NormalizedName = role.Name.ToUpper();


                var result = await _roleManager.UpdateAsync(objFromDb);
                TempData[SD.Success] = "Role Updated success";

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var obj = _db.Roles.FirstOrDefault(d => d.Id == id);
            if (obj == null)
            {
                TempData[SD.Error] = "Role Not Found!";
                return RedirectToAction("Index");
            }

            var assignRole = _db.UserRoles.Where(e => e.RoleId == id).Count();

            if (assignRole > 0)
            {
                TempData[SD.Error] = "Can not delete because already assign role!";
                return RedirectToAction("Index");
            }

            await _roleManager.DeleteAsync(obj);
            TempData[SD.Success] = "Role Deleted success";
            return RedirectToAction("Index");
        }


    }
}
