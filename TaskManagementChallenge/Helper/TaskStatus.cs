namespace TaskManagementChallenge.Helper
{
    //create a static for task status
    public static class CustomTaskStatus
    {
        public const string Created = "Created";
        public const string InProgress = "In Progress";
        public const string Completed = "Completed";
        public const string InComplete = "Incomplete";
    }

    //static method to return all statuses
    public static class Helper
    {
        public static List<string> GetAllStatuses()
        {
            return new List<string>
            {
                CustomTaskStatus.Created,
                CustomTaskStatus.InProgress,
                CustomTaskStatus.Completed,
                CustomTaskStatus.InComplete
            };
        }
    }
}
