using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RoleDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(CreateRoleDto createRoleDto)
        {
            AppRole appRole = new AppRole()
            {
                Name = createRoleDto.Name
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public async Task<IActionResult> DeleteRole(int id)
        {

            var reslut = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(reslut);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleDto updateRoleDto = new UpdateRoleDto()
            {
                Id = values.Id,
                Name = values.Name
            };
            return View(updateRoleDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var values = _roleManager.Roles.FirstOrDefault(x=>x.Id == updateRoleDto.Id);
            values.Name = updateRoleDto.Name;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }
    }
}
