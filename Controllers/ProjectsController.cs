using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Data;
using ProjectTracker.DTO.Task;
using ProjectTracker.DTO;
using ProjectTracker.DTO.Project;
using ProjectTracker.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectTracker.Services;

namespace ProjectTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService iProjectService;
        public ProjectsController(IProjectService projectService)
        {
            iProjectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(await iProjectService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var getProject = await iProjectService.GetByIdAsync(id);
            if (getProject == null)
                return NotFound();
            return Ok(getProject);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await iProjectService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetProject), new {id = created.Id}, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProjectUpdateDto uppdateProject)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var rez = await iProjectService.UpdateAsync(id, uppdateProject);
            if(rez==true)
                return NoContent(); // 204 Сообщает, что запрос успешно обработан, но сервер не должен возвращать клиенту какое-либо тело ответа.
            else
                return NotFound();//404
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rez = await iProjectService.DeleteAsync(id);
            if (rez == false)
                return NotFound();//404
            else
                return NoContent();
        }
    }
}
