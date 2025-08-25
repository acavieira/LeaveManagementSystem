using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Web.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "9d46f036-5080-4ead-8613-94321d6aa8f3",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole
            {
                Id = "5e6bab09-049c-4c6a-ba1f-df94de5362af",
                Name = "Supervisor",
                NormalizedName = "SUPERVISOR"
            },
            new IdentityRole
            {
                Id = "00f16303-fe25-4984-98cd-166fe0bb7dd1",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
        }
    }
}
