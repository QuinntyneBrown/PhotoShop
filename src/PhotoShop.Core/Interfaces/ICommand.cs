using System.Collections.Generic;

namespace PhotoShop.Core.Interfaces
{
    public interface ICommand<TResponse> 
    {
        string Key { get; }        
        IEnumerable<string> SideEffects { get; }
    }
}
