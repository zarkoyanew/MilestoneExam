using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MilestoneExam.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<MainDataContext>
    {
        public MainDataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<MainDataContext>();

            optionBuilder.UseSqlServer("Server=RAZIEL-HOME\\SQLSERVER2016;Database=MilestoneExam;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=true");

            return new MainDataContext(optionBuilder.Options);
        }
    }
}
