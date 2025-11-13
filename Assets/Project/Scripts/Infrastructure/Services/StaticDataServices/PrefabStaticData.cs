using Infrastructure;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabStaticData", menuName = "ScriptableObjects/StaticData/Prefabs")]
public class PrefabStaticData : ScriptableObject
{
    public HexModelView HexModelView;
    public HexCellView HexCellView;
    public HexPile HexPile;
    public BrushView BrushView;
    public HammerView HammerView;
}