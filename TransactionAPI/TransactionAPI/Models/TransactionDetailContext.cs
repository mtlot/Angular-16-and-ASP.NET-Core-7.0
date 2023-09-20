using Microsoft.EntityFrameworkCore;

namespace TransactionAPI.Models
{
    public class TransactionDetailContext:DbContext
    {
        public TransactionDetailContext(DbContextOptions<TransactionDetailContext> options)
            : base(options)
        {
        }
        public DbSet<TransactionDetail> TransactionDetail { get; set; }
    }
}
