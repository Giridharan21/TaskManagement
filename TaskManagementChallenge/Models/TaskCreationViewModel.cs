using System.ComponentModel.DataAnnotations;

namespace TaskManagementChallenge.Models
{
    //Create a viewmode for TAskCreation
    public class TaskCreationViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }





}