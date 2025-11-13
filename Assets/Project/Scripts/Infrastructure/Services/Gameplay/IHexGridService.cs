using System.Collections.Generic;
using Hexes;
using UnityEngine;

namespace Infrastructure.Services.Gameplay
{
    public interface IHexGridService : IService
    {
        public void Initialize(AllServices services);
        public void CreateGrid();
        public void CleanUpGrid();
        public HexGrid GetGrid();
        public List<HexCell> GetNeighbors(int x, int y);
        public HexCell GetCellByIndex(int index);
        public HexCell GetClosestCell(Vector3 worldPos);
        public Vector3 GetGridCenterPos();
    }
}