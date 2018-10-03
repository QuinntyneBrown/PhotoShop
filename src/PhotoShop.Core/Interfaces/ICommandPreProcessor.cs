﻿using System;
using System.Threading.Tasks;

namespace PhotoShop.Core.Interfaces
{
    public interface ICommandPreProcessor
    {        
        Task<TResponse> Process<TRequest,TResponse>(TRequest request, Func<TRequest, Task<TResponse>> callback) 
            where TRequest : ICommand<TResponse>;
    }
}
