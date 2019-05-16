using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Buttons.WebUI.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Buttons.WebUI.Controllers
{
    public class RoleController : Controller
    {
        
            ApplicationDbContext context;

            public RoleController()
            {
                context = new ApplicationDbContext();
            }



            /// <summary>
            /// Get All Roles
            /// </summary>
            /// <returns></returns>
            public ActionResult Index()
            {
                var Roles = context.Roles.ToList();
                return View(Roles);
            }

            /// <summary>
            /// Create  a New role
            /// </summary>
            /// <returns></returns>
            public ActionResult Create()
            {
                var Role = new IdentityRole();
                return View(Role);
            }

            /// <summary>
            /// Create a New Role
            /// </summary>
            /// <param name="Role"></param>
            /// <returns></returns>
            [HttpPost]
            public ActionResult Create(IdentityRole Role)
            {
                context.Roles.Add(Role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


        
        /*
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> list = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
                list.Add(new RoleViewModel(role));
            return View(list);


        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }
        [HttpPost]
        public async Task<ActionResult> Edit(RoleViewModel model)
        {
            var role = new ApplicationRole() { Id = model.Id, Name = model.Name };
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }
        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));

        }
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");

        }
    }*/
    }
}