using TaskManagementChallenge.Data;
using TaskManagementChallenge.Data.Entities;
using TaskManagementChallenge.Models;

namespace TaskManagementChallenge.DataAccess
{
    public class TaskDataAccess : ITaskDataAccess
    {
        private readonly ApplicationDbContext _context;
        //create a constructor that takes in an ApplicationDbContext object
        public TaskDataAccess(ApplicationDbContext context)
        {
            _context = context;
        }

        //create a method that returns a list of tasks based on username and 



        //public List<Tasks> GetTasks(string username)
        //{
        //    //return a list of tasks where the task's createdby property matches the username passed in
        //    return _context.Tasks.Where(t => t.CreatedBy == username).ToList();
        //}
        //update above method and return as ListTaskViewModel
        public List<ListTaskViewModel> GetTasks(string username)
        {
            //return a list of tasks where the task's createdby property matches the username passed in
            return _context.Tasks.Where(t => t.CreatedBy == username).Select(t => new ListTaskViewModel
            {
                Id = t.Id,
                Description = t.Description,
                Name = t.Name,
                Status = t.Status
            }).ToList();
        }


        //method to add task from TaskCreationViewModel
        public void AddTask(TaskCreationViewModel model)
        {
            //create a new Tasks object
            var task = new Tasks
            {
                Name = model.Name,
                Description = model.Description,
                Status = model.Status,
                CreatedBy = model.CreatedBy
            };
            //add the task to the Tasks DbSet
            _context.Tasks.Add(task);
            //save changes
            _context.SaveChanges();
        }


        //method to update task from TaskUpdateViewModel
        public void UpdateTask(TaskUpdateViewModel model)
        {
            //get the task from the Tasks DbSet where the task's id matches the id passed in
            var task = _context.Tasks.Find(model.Id);
            //update the task's name, description, and status properties
            task.Name = model.Name;
            task.Description = model.Description;
            task.Status = model.Status;
            //save changes
            _context.SaveChanges();
        }


        //method to delete task from TaskDeleteViewModel
        public void DeleteTask(TaskDeleteViewModel model)
        {
            //get the task from the Tasks DbSet where the task's id matches the id passed in
            var task = _context.Tasks.Find(model.Id);
            //remove the task from the Tasks DbSet
            _context.Tasks.Remove(task);
            //save changes
            _context.SaveChanges();
        }


        //method to update task status from TaskUpdateStatusViewModel
        public void UpdateTaskStatus(TaskUpdateStatusViewModel model)
        {
            //get the task from the Tasks DbSet where the task's id matches the id passed in
            var task = _context.Tasks.Find(model.Id);
            //update the task's status property
            task.Status = model.Status;
            //save changes
            _context.SaveChanges();
        }


        //method to get task from task id and return as TaskDetailsViewModel
        public TaskDetailsViewModel GetTask(int id)
        {
            //get the task from the Tasks DbSet where the task's id matches the id passed in
            var task = _context.Tasks.Where(i=>i.Id == id).FirstOrDefault();
            //add null check
            if (task == null)
            {
                return new TaskDetailsViewModel();
            }
            //create a new TaskDetailsViewModel object
            var model = new TaskDetailsViewModel
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatedBy = task.CreatedBy
            };
            //return the model
            return model;
        }
       
    }

}
