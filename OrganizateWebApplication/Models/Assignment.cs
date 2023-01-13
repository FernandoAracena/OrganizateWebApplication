using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganizateWebApplication.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }

        public Assignment()
        {

        }
    }
}
