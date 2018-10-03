using PhotoShop.Core.Common;
using PhotoShop.Core.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoShop.Core.Models
{
    public class User: Entity
    {
        public User(string username, byte[] salt, string password) 
            => Apply(new UserCreated(UserId, username,salt,password));

        protected override void When(object @event)
        {
            switch (@event)
            {
                case UserCreated data:
                    UserId = data.UserId;
                    Username = data.Username;
                    Salt = data.Salt;
                    Password = data.Password;
                    RoleIds = new HashSet<Guid>();
                    break;

                case UserRoleAdded userRoleAdded:
                    RoleIds = RoleIds.Concat(new Guid[] { userRoleAdded.RoleId }).ToList();
                    Version++;
                    break;
            }            
        }

        protected override void EnsureValidState()
        {
            if (Password == default(string))
                throw new Exception();
        }

        public void AddRole(Guid roleId)
            => Apply(new UserRoleAdded(roleId));

        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; private set; }
        public ICollection<Guid> RoleIds { get; private set; }
        public UserStatus Status { get; private set; }
        public int Version { get; private set; }
    }

    public enum UserStatus {
        Active,
        InActive
    }
}
