
using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(
        ApplicationDbContext _context, 
            IHttpContextAccessor _httpContextAccessor, 
                UserManager<ApplicationUser> _userManager, 
                IMapper _mapper) : ILeaveAllocationsService 
    {
        public async Task AllocateLeave(string employeeId)
        {
            var leaveTypes = await _context.LeaveTypes.Where(x=> !x.LeaveAllocations.Any(x => x.EmployeeId==employeeId)).ToListAsync();



            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(x => x.EndDate.Year == currentDate.Year);
            var monthsRemaining = period.EndDate.Month - currentDate.Month;



            foreach (var leaveType in leaveTypes)
            {
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining),
                };

                _context.Add(leaveAllocation);
            }
            await _context.SaveChangesAsync();
        }



        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId) 
                ? await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User) 
                : await _userManager.FindByIdAsync(userId);
            var allocations = await GetAllocations(userId);
            var allocationVMList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();
            var employeeVM = new EmployeeAllocationVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DataOfBirth = user.DataOfBirth,
                Email = user.Email,
                Id = user.Id,
                LeaveAllocations = allocationVMList,
                IsCompletedAllocation = leaveTypesCount == allocationVMList.Count
            };

            return employeeVM;
        }

        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var users = await _userManager.GetUsersInRoleAsync(Roles.Employee);
            var employees = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(users.ToList());

            return employees;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationEditVM>(allocation);
            return model;

        }

        public async Task EditAllocation(LeaveAllocationEditVM model)
        {
            var leaveAllocation = await GetEmployeeAllocation(model.Id) ?? throw new Exception("Error getting leave allocation not exists");

            leaveAllocation.Days = model.Days;
            //opcao1(scafolding) _context.Update(leaveAllocation);
            //opcao2 _context.Entry(leaveAllocation).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            await _context.LeaveAllocations.Where(x => x.Id == model.Id).ExecuteUpdateAsync(s => s.SetProperty(p => p.Days, model.Days));
        }

        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {
            var currentDate = DateTime.Now;
            var leaveAllocations = await _context.LeaveAllocations
                .Include(x => x.LeaveType)
                .Include(x => x.Period)
                .Where(x => x.EmployeeId == userId && x.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocations;
        }


        private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(x => 
                                    x.EmployeeId == userId 
                                    && x.PeriodId == periodId 
                                    && x.LeaveTypeId == leaveTypeId);
            return exists;

        }


    }
}
