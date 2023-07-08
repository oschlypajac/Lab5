using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lab5.Controllers
{
    public class TaskController : ApiController
    {
        private static List<Task> tasks = new List<Task>();
        public IHttpActionResult CreateTask(Task task)
        {
            if (task == null)
            {
                return BadRequest("Nie podano zadania");
            }
            tasks.Add(task);

            return Ok("Dodano zadanie");
        }
        public IHttpActionResult GetAllTasks()
        {
            return Ok(tasks);
        }
        public IHttpActionResult GetTaskById(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
        public IHttpActionResult UpdateTask(int id, Task updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;

            return Ok("Zaktualizowano zadanie");
        }
        public IHttpActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);

            return Ok("Usunięto zadanie");
        }
    }
}
