using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

namespace Services
{
    public class GlobalBlackboard : IService
    {
        public Dictionary<ColorID, Color> ColorsByID = new Dictionary<ColorID, Color>();
        public Dictionary<ColorID, Material> MaterialsByColorID = new Dictionary<ColorID, Material>();
        
        public void Initialize()
        {
            
        }
    }
}