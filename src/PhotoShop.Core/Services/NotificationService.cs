﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoShop.Core.Interfaces;

namespace PhotoShop.Core.Services
{
    public class NotificationService : INotificationService
    {
        public async Task Send(List<string> emailToDistributionList, List<string> emailCcDistributionList, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}
