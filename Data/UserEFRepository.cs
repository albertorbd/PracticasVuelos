﻿using Practices.Models;
using Microsoft.EntityFrameworkCore;

namespace Practices.Data
{
    public class UserEFRepository : IUserRepository
    {
        private readonly PracticesContext _context;

        public UserEFRepository(PracticesContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            SaveChanges();
        }

        public IEnumerable<User> GetAllUsers() 
        {
            var users = _context.Users;
            return users;
        }

        public User GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(user => user.Id == userId);
            return user;
        }

        public User GetUserByEmail(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(user => user.Email.Equals(userEmail));
            return user;
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteUser(int userId) {
            var user = GetUserById(userId);
            _context.Users.Remove(user);
            SaveChanges();
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Booking> MyBookings(BookingsQueryParameters bookingsQueryParameters) 
        {
            var query = _context.Bookings.Where(b => b.UserId == bookingsQueryParameters.UserId);

            if (bookingsQueryParameters.DepartureDate.HasValue)
            {
                query = query.Where(t => t.DepartureDate >= bookingsQueryParameters.DepartureDate.Value);
            }

            if (bookingsQueryParameters.ReturnDate.HasValue)
            {
                query = query.Where(t => t.ReturnDate >= bookingsQueryParameters.ReturnDate.Value);
            }

            query = query.OrderBy(t => t.DepartureDate);

            return query.ToList();
        }


    }   
}