using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using ToDoList.BLL.DAL;
using ToDoList.BLL.Manager;

namespace ToDoList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetToDoList()
        {
            try
            {
                var lst = ToDoManager.GetList();
                if (lst.Count > 0)
                {
                    var retLst = JsonConvert.SerializeObject(lst, Formatting.Indented,
                     new JsonSerializerSettings()
                     {
                         ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                     });
                    return Ok(retLst);
                }
                return Ok(null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> GetById(int id)
        {
            try
            {
                return Ok(ToDoManager.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDo(int id)
        {
            try
            {
                ToDoManager.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult SaveToDo(ToDo toDo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ToDoManager.Save(toDo);
                    return Ok();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}