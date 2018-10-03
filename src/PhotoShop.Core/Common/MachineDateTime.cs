using PhotoShop.Core.Interfaces;
using System;

namespace PhotoShop.Core.Common
{
    public class MachineDateTime : IDateTime
    {
        public DateTime UtcNow { get { return System.DateTime.UtcNow; } }
    }
}
