namespace TaskManagementChallenge.Models
{
    //create a viewmodel for TaskUpdate
    public class TaskUpdateViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public string Name { get; set; }
    }


    //create a viewmodel for deleting a task
    public class TaskDeleteViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //create a viewmodel to update task status
    public class TaskUpdateStatusViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }



}