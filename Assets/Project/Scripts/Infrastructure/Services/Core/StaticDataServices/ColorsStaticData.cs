using System;
using Infrastructure.Services.Gameplay;
using UnityEngine;

namespace Infrastructure.Services.Core
{
    [CreateAssetMenu(fileName = "Colors Static Data", menuName = "Game/Colors/Data")]
    public class ColorsStaticData : ScriptableObject
    {
        public ColorTuple[] Colors;
    }

    [Serializable]
    public struct ColorTuple
    {
        public ColorID ColorID;
        public Color Color;
        public Material Material;
    }
}