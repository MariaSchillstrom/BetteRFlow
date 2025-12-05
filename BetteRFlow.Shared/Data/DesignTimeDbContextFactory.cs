using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BetteRFlow.Shared.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BetteRFlowContext>
{
    public BetteRFlowContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BetteRFlowContext>();
        optionsBuilder.UseSqlite("Data Source=betterflow.db");

        return new BetteRFlowContext(optionsBuilder.Options);
    }
}
