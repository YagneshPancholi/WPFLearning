﻿using Microsoft.EntityFrameworkCore;
using Reservoom.DbContexts;
using Reservoom.DTOs;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationProviders
{
    public class DatabaseReservationProvider : IReservationProvider
    {
     private readonly ReservoomDbContextFactory _dbContextFactory;

        public DatabaseReservationProvider(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (ReservoomDbContext context = _dbContextFactory.CreateDbContext())
            {
               IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();
                await Task.Delay(2000);
               return reservationDTOs.Select(r => ToReservation(r));
            }
        }
        private static Reservation ToReservation(ReservationDTO reservationDTO)
        {
            return new Reservation(new RoomID(reservationDTO.FloorNumber, reservationDTO.RoomNumber),
                reservationDTO.StartTime,
                reservationDTO.EndTime,
                reservationDTO.Username);
        }

    }
}
