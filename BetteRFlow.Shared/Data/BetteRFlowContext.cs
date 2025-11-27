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
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Fastighet> Fastigheter { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FormSubmission> FormSubmissions { get; set; }
    public DbSet<Invitation> Invitations { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseFastighet> PurchaseFastigheter { get; set; }
    public DbSet<Realtor> Realtors { get; set; }
    public DbSet<User> Users { get; set; }
}