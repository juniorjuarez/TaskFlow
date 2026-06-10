using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByIdAsync(Guid id);

        Task UpdateAsync(User user);

        Task DeleteAsync(Guid id);
    }
}
