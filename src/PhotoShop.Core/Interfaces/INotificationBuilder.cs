using System.Collections.Generic;

namespace PhotoShop.Core.Interfaces
{
    public interface INotificationBuilder
    {
        (List<string> emailToDistributionList, List<string> emailCcDistributionList, string subject, string body) Build(string notificationName);
    }
}
