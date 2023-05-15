using Microsoft.EntityFrameworkCore;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Data.Context;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Data.Concrete.EfCore
{
    public class EfCoreReservationRepository : EfCoreGenericRepository<Reservation>, IReservationRepository
    {
        public EfCoreReservationRepository(PrivateClassAppContext _appContext) : base(_appContext)
        {
        }
        PrivateClassAppContext AppContext
        {
            get { return _dbContext as PrivateClassAppContext; }
        }
        public async Task<List<Reservation>> GetAllReservationsAsync(string userId = null, bool dateSort = false)
        {
            var reservations = AppContext
                .Reservations
                .Include(r => r.Lesson)
                .ThenInclude(r => r.Teacher)
                .AsQueryable();
            if (dateSort)
            {
                reservations = reservations.OrderByDescending(r => r.ReservationDate);
            }
            else
            {
                reservations = reservations.OrderBy(r => r.ReservationDate);

            }
            if (userId != null)
            {
                reservations = reservations.Where(r => r.UserId == userId);
            }
            return await reservations.ToListAsync();
        }

    }
}
