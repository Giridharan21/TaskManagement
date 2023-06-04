using Microsoft.AspNetCore.Identity;

namespace TaskManagementChallenge.Data.Entities
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }

    }
   
}
