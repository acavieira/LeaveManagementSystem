
namespace LeaveManagementSystem.Web.Models.LeaveAllocations
{
    public class EmployeeAllocationVM : EmployeeListVM
    {

        [Display(Name = "Date Joined")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateOnly DataOfBirth { get; set; }

        public bool IsCompletedAllocation { get; set; }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    
    
    }
}
