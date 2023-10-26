
using Microsoft.EntityFrameworkCore;

//using System.Data.Entity;

namespace ir.news.xsean
{
    public class dbcontext : DbContext
    {
        public readonly IConfiguration _configuration;
        public dbcontext(DbContextOptions<dbcontext> options) : base(options)
        {
            Console.WriteLine(base.Database.GetConnectionString);
        }





        public DbSet<urlscro> urlscros { get; set; }
        public DbSet<catgory> catgories { get; set; }
        public DbSet<newss> newss { get; set; }
        public DbSet<newsfi> newsfi { get; set; }
        public DbSet<coment> coment { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // اعمال ایندکس بر روی فیلد ایمیل
            // اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<newss>().HasIndex(u => u.url).IsUnique();
            //-- عدم نمایش اطلاعات حذف شده
            ApplyQueryFilter(modelBuilder);
        }
        private void ApplyQueryFilter(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<newss>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<coment>().HasQueryFilter(p => !p.IsRemoved);
        }

    }
}
