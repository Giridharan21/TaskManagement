using TaskManagementChallenge.Models;

namespace TaskManagementChallenge.DataAccess
{
    public interface ITaskDataAccess
    {
        void AddTask(TaskCreationViewModel model);
        void DeleteTask(TaskDeleteViewModel model);
        List<ListTaskViewModel> GetTasks(string username);
        void UpdateTask(TaskUpdateViewModel model);
        void UpdateTaskStatus(TaskUpdateStatusViewModel model);
        TaskDetailsViewModel GetTask(int id);
    }
}