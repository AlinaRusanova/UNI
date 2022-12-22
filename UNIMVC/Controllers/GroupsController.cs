using Microsoft.AspNetCore.Mvc;
using UNI.Domain.Contracts;
using UNI.Domain.Entities;
using UNI.Persistence.Models;
using UNI.Tests.Common.Exceptions;
using UNI.WebApi.Models;

namespace UNI.WebApi.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupService<GroupModel> _groupService;
        public GroupsController(IGroupService<GroupModel> groupService)
        {
            _groupService = groupService;
        }


        [Route("Groups/List/{id?}")]
        public async Task<ActionResult<List<GroupModel>>> List(int id, CancellationToken ct, int pg=1)
        {

            if( id < 0)
                throw new NotFoundException(nameof(GroupModel), id);

            var groupsWithCourse = await _groupService.ListAllAsync(id, ct);

            const int pageSize = 10;
            if (pg < 1)
            { pg = 1; }

            int recsCount = groupsWithCourse.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = groupsWithCourse.Skip(recSkip).Take(pageSize).ToList();

            //  var data = Pager.IEnumerable<GroupModel>(groupsWithCourse);

            this.ViewBag.Pager = pager;

            if (groupsWithCourse.Count() == 0)
                return View("NoGroups");

             return View(data); 
        }

        public async Task<ActionResult<Group>> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<GroupModel>> Create(GroupModel group, CancellationToken ct)
        {
            if (group == null || group.Id < 0)
                throw new NotFoundException(nameof(GroupModel), group);

            if (!ModelState.IsValid)
            {
                return View(group);
            }

            await _groupService.AddAsync(group, ct);
            return RedirectToAction("List");
        }


            public async Task<ActionResult<GroupModel>> Edit(int id, CancellationToken ct)
            {
            if (id < 1)
                throw new NotFoundException(nameof(GroupModel), id);

            var group = await _groupService.GetByIdAsync(id, ct);
                if (group == null)
                { return View("NotFound"); }
                return View(group);
            }

            [HttpPost]
            public async Task<ActionResult<GroupModel>> Edit(GroupModel group, CancellationToken ct)
            {
                await _groupService.UpdateAsync(group, ct);

                if (!ModelState.IsValid)
                {
                    return View(group);
                }

                return RedirectToAction("List");
            }

            public async Task<ActionResult<GroupModel>> Delete(int id, CancellationToken ct)
            {
                if (id < 1)
                    throw new NotFoundException(nameof(GroupModel), id);

                var group = await _groupService.GetByIdAsync(id, ct);

                    if (group == null)
                    { return View("NotFound"); }

                    if (group.ListOfStudents.Count() > 0)
                    { return View("CouldNotDelete"); }

                    return View(group);
            }

            [HttpPost, ActionName("Delete")]
            public async Task<ActionResult<GroupModel>> DeleteConfirmed(GroupModel group, CancellationToken ct)
            {
                await _groupService.DeleteAsync(group, ct);

                return RedirectToAction("List");
            }

    }
}
