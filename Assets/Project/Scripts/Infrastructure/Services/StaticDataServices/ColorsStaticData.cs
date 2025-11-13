using System;
using Infrastructure;
using UnityEngine;

namespace Services
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