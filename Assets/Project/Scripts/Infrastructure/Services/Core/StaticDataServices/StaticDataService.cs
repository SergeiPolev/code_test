using System;
using System.Collections.Generic;
using System.Linq;
using Levels;
using Settings;
using UI;
using UI.Base;
using UnityEngine;

namespace Infrastructure.Services.Core
{
    public class StaticDataService : IService
    {
        private const string StaticDataWindowsPath = "StaticData/Window/WindowStaticData";
        private const string SettingsPath = "StaticData/Settings/SettingsStaticData";
        private const string _prefabStaticDataPath = "StaticData/Prefabs/PrefabStaticData";
        private const string _colorsStaticData = "StaticData/Colors/ColorsStaticData";
        private const string _levelsStaticPath = "StaticData/Levels";

        private Dictionary<WindowId, WindowBase> _windowConfigs;
        public SettingsStaticData Settings { get; set; }
        public PrefabStaticData Prefabs { get; set; }
        public List<LevelAsset> Levels { get; set; }
        public ColorsStaticData ColorsStaticData { get; set; }

        public void Initialize()
        {
            LoadWindows();
            LoadSettings();
            LoadPrefabs();
            LoadLevels();
            LoadColors();
        }

        private void LoadColors()
        {
            ColorsStaticData = Resources.Load<ColorsStaticData>(_colorsStaticData);
        }

        private void LoadPrefabs()
        {
            Prefabs = Resources.Load<PrefabStaticData>(_prefabStaticDataPath);
        }

        private void LoadSettings()
        {
            Settings = Resources.Load<SettingsStaticData>(SettingsPath);
        }

        private void LoadWindows()
        {
            _windowConfigs = Resources.Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowID, x => x);
        }

        private void LoadLevels()
        {
            Levels = Resources.LoadAll<LevelAsset>(_levelsStaticPath).ToList();
        }

        public WindowBase ForWindow(WindowId windowId)
        {
            if (_windowConfigs.TryGetValue(windowId, out var windowConfig))
            {
                return windowConfig;
            }

            throw new Exception($"Error! Can't find static data of type {windowId}");
        }
    }
}