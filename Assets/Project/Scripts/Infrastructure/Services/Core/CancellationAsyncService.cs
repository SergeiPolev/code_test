using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Core
{
    public class CancellationAsyncService : IService
    {
        private CancellationToken _token;
        
        public CancellationToken Token => _token;
        
        public void Initialize(MonoBehaviour monoBehaviour)
        {
            _token = monoBehaviour.GetCancellationTokenOnDestroy();
        }
    }
}