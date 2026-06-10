using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TaskFlow.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public ICollection<TodoItem> TodoItems { get; private set; }


        public User(string name, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome do usuário não pode ser vazio.");
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new ArgumentException("Um e-mail válido é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("O hash da senha é obrigatório.");
            }

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            TodoItems = new List<TodoItem>();
        }

        public IEnumerable<TodoItem> GetPendingTask()
        {
            return TodoItems.Where(i => !i.IsCompleted);

        }
    }


}
