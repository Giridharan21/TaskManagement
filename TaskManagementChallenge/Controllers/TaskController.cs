using Microsoft.AspNetCore.Mvc;
using TaskManagementChallenge.DataAccess;
using TaskManagementChallenge.Helper;
using TaskManagementChallenge.Models;

namespace TaskManagementChallenge.Controllers
{
    public class TaskController : Controller
    {
        private ITaskDataAccess _taskDataAccess;
        //create constructor with ITaskDataAccess parameter
        public TaskController(ITaskDataAccess taskDataAccess)
        {
            _taskDataAccess = taskDataAccess;
        }
        

        //create a method that returns a list of tasks based on username and
        public IActionResult Index()
        {
            //get the username from the logged in user
            var username = User.Identity.Name;
            //get the tasks for the logged in user
            var tasks = _taskDataAccess.GetTasks(username);
            //return the view with the tasks
            return View(tasks);
        }

       
        public IActionResult AddTask(TaskCreationViewModel model)
        {
            //check if the model is valid
            if (ModelState.IsValid)
            {
                //get the username from the logged in user
                var username = User.Identity.Name;
                //set the createdby property of the model to the username
                model.CreatedBy = username;
                model.Status = CustomTaskStatus.Created;
                //add the task
                _taskDataAccess.AddTask(model);
                //redirect to the index action
                return RedirectToAction("Index");
            }
            //if the model is not valid, return the view with the model
            return View(model);
        }
        ////method to update task from TaskUpdateViewModel
        [HttpPost]
        public IActionResult UpdateTask(TaskUpdateViewModel model)
        {
            //check if the model is valid
            if (ModelState.IsValid)
            {
                //update the task
                _taskDataAccess.UpdateTask(model);
                //redirect to the index action
                return RedirectToAction("Index");
            }
            //if the model is not valid, return the view with the model
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            
            //get task from id
            var taskDetails =  _taskDataAccess.GetTask(id);
            //Convert TaskDetails to TaskUpdateViewModel
            var model = new TaskUpdateViewModel
            {
                Id = taskDetails.Id,
                Name = taskDetails.Name,
                Description = taskDetails.Description,
                Status = taskDetails.Status,
                Statuses = Helper.Helper.GetAllStatuses()
            };
            return View(model);
        }



        //get method to delete task
        public IActionResult DeleteTask(int id)
        {
            //get the task from the Tasks DbSet where the task's id matches the id passed in
            var model = new TaskDeleteViewModel
            {
                Id = id
            };
            _taskDataAccess.DeleteTask(model);
            //return the view with the task
            return RedirectToAction("Index");
        }

        //method to update task status from TaskUpdateStatusViewModel
        public IActionResult UpdateTaskStatus(TaskUpdateStatusViewModel model)
        {
            //check if the model is valid
            if (ModelState.IsValid)
            {
                //update the task's status
                _taskDataAccess.UpdateTaskStatus(model);
                //redirect to the index action
                return RedirectToAction("Index");
            }
            //if the model is not valid, return the view with the model
            return View(model);
        }

    }
}
