using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "SettingsStaticData", menuName = "ScriptableObjects/StaticData/Settings")]
    public class SettingsStaticData : ScriptableObject
    {
        public bool UseJSONAsConfig = false;
        public string MasterURL;
    }
}