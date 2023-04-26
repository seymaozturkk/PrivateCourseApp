using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Abstract
{
    public interface IReservationService
    {
        public Task CreateAsync(Reservation reservation);
        public Task<Reservation> GetByIdAsync(int id);
        public Task<List<Reservation>> GetAllAsync();
        public void Update(Reservation reservation);
        public void Delete(Reservation reservation);
        public Task<List<Reservation>> GetAllReservationsAsync(string userId = null, bool dateSort = false);
    }
}
