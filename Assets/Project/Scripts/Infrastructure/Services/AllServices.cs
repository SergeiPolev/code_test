using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ??= new AllServices();

        public List<IDisposable> Disposables { get; } = new();

        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.ServiceInstance = implementation;

            if (Implementation<TService>.ServiceInstance is IDisposable disposable)
            {
                Disposables.Add(disposable);
            }
        }

        public TService Single<TService>() where TService : IService
        {
            return Implementation<TService>.ServiceInstance;
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}