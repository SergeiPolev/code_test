using System.Collections.Generic;
using Factories.UIFactory;
using UI;
using UI.Base;

namespace Infrastructure.Services.Core
{
    public class WindowService : IService
    {
        private UIFactory _uiFactory;

        private readonly Dictionary<WindowId, WindowBase> _windows = new();

        public void Initialize(UIFactory factory)
        {
            _uiFactory = factory;
            //_uiFactory.CreateMainCanvas();
        }

        public bool Open(WindowId windowID)
        {
            return Open<WindowBase>(windowID, out var window);
        }

        public bool Open<T>(WindowId windowId, out T window) where T : WindowBase
        {
            window = null;
            if (IsOpen(windowId))
                return false;

            window = GetOrCreateWindow<T>(windowId);
            window.Open();
            return true;
        }


        public T GetOrCreateWindow<T>(WindowId windowId) where T : WindowBase
        {
            if (!_windows.ContainsKey(windowId))
            {
                _windows.Add(windowId, _uiFactory.CreateWindow<T>(windowId));
            }
            
            return _windows[windowId] as T;
        }

        public void Close(WindowId windowId)
        {
            if (IsOpen(windowId) == false)
            {
                return;
            }

            if (_windows.TryGetValue(windowId, out WindowBase window))
            {
                window.Close();
            }
        }

        private bool IsOpen(WindowId windowId)
        {
            if (_windows.TryGetValue(windowId, out WindowBase window))
            {
                return window.IsOpen;
            }

            return false;
        }
    }
}

