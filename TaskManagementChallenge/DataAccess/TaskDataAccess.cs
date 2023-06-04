using TaskManagementChallenge.Data;
using TaskManagementChallenge.Data.Entities;
using TaskManagementChallenge.Models;

namespace TaskManagementChallenge.DataAccess
{
    public class TaskDataAccess
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



    }

}
