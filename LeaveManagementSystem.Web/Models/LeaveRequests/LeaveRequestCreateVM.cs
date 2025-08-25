using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace LeaveManagementSystem.Web.Models.LeaveRequests
{
    public class LeaveRequestCreateVM
    {
        [DisplayName("Start Date")]
        [Required]
        public DateOnly StartDate { get; set; }

        [DisplayName("End Date")]
        [Required]
        public DateOnly EndDate { get; set; }

        [DisplayName("Desired Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }

        [DisplayName("Addicional Information")]
        [StringLength(250)]
        public string? RequestComments { get; set; }


        public SelectList? LeaveTypes { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return new ValidationResult("End Date cannot be before Start Date",
                new[] { nameof(StartDate), nameof(EndDate) });
        }*/
    }
}