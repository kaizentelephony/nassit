using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;

namespace nassit.Models
{
    public class EnrollContext : DbContext
    {
        public EnrollContext(DbContextOptions<EnrollContext> options) : base(options) { }

        public DbSet<TBL_ENROLLMENT> TBL_ENROLLMENT { get; set; }
        public DbSet<TBL_VERIFICATION> TBL_VERIFICATION { get; set; }

        public DbSet<TBL_BLACKLIST> TBL_BLACKLIST { get; set; }
        public DbSet<TBL_Registration> TBL_Registration { get; set; }
        public DbSet<TBL_CALL_TRANSFER> TBL_CALL_TRANSFER { get; set; }
        public DbSet<TBL_CALLDETAILS> TBL_CALLDETAILS { get; set; }
        //public DbSet<TBL_CALL_TRANSFER> TBL_CALL_TRANSFER { get; set; }

        public IQueryable<TBL_ENROLLMENT> GetDataByDateRange(DateTime fromDate, DateTime toDate)
        {
            return TBL_ENROLLMENT.Where(e => e.VAR_CALLED_DATE >= fromDate && e.VAR_CALLED_DATE <= toDate);
        }
    }
}

//namespace nassit.Models
//{
//    public class EnrollContext : DbContext
//    {
//        public EnrollContext(DbContextOptions<EnrollContext> options) : base(options) { }

//        public DbSet<TBL_REGISTERED_DETAILS> TBL_REGISTERED_DETAILS { get; set; }

//        public DbSet<TBL_VERIFICATION_DETAILS> TBL_VERIFICATION_DETAILS { get; set; }

//        public DbSet<TBL_Registration> TBL_Registration { get; set; }


//        public IQueryable<TBL_REGISTERED_DETAILS> GetDataByDateRange(DateTime fromDate, DateTime toDate)
//        {
//            return Models.TBL_REGISTERED_DETAILS.Where(e => e.VAR_CALLED_DATE >= fromDate && e.VAR_CALLED_DATE <= toDate);
//        }

//        //public IQueryable<TBL_REGISTERED_DETAILS> GetDataByDateRange(DateTime fromDate, DateTime toDate)
//        //{
//        //    return Models.TBL_REGISTERED_DETAILS.Where((object e) => e.VAR_CALLED_DATE >= fromDate && e.VAR_CALLED_DATE <= toDate);
//        //}
//    }
//}
