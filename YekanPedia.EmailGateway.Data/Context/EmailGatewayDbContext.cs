namespace YekanPedia.EmailGateway.Data.Context
{
    using System.Data.Entity;
    using Domain.Entity;

    public class EmailGatewayDbContext : DbContext , IUnitOfWork
    {
        public EmailGatewayDbContext()
            : base("name=EmailGatewayDbContext")
        {
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public virtual DbSet<AboutUs> AboutUs { get; set; }
    }
}
