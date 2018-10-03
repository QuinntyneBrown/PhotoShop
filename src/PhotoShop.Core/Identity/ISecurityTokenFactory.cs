using System;
using System.Collections.Generic;

namespace PhotoShop.Core.Identity
{
    public interface ISecurityTokenFactory
    {
        string Create(Guid userId, string uniqueName, IEnumerable<string> roles = null);
    }
}
