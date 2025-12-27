using BetteRFlow.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BetteRFlow.Shared.Data;

public class BetteRFlowContext : DbContext
{
    public BetteRFlowContext(DbContextOptions<BetteRFlowContext> options)
        : base(options)
    {
    }

    public DbSet<Brf> Brfs { get; set; }

    public DbSet<Form> Forms { get; set; }

    public DbSet<FormSubmission> FormSubmissions { get; set; }
    
    public DbSet<Purchase> Purchases { get; set; }    
    
    public DbSet<User> Users { get; set; }
}