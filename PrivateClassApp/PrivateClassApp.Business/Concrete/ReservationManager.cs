using PrivateClassApp.Business.Abstract;
using PrivateClassApp.Data.Abstract;
using PrivateClassApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateClassApp.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationRepository _reservationRepository;

        public ReservationManager(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await _reservationRepository.CreateAsync(reservation);
        }

        public void Delete(Reservation reservation)
        {
            _reservationRepository.Delete(reservation);
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _reservationRepository.GetAllAsync();
        }

        public async Task<List<Reservation>> GetAllReservationsAsync(string userId = null, bool dateSort = false)
        {
            return await _reservationRepository.GetAllReservationsAsync(userId, dateSort);
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _reservationRepository.GetByIdAsync(id);
        }

        public void Update(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }
    }
}
