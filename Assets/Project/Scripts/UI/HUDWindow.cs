using Infrastructure;
using Services;
using TMPro;
using UnityEngine;

public class HUDWindow : WindowBase
{
    public override WindowId WindowID => WindowId.HUD;
    
    private LevelProgressService _levelProgressService;
    
    [SerializeField] private TMP_Text _level;
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private BoosterButton[] _boosterButtons;

    protected override void _Initialize(AllServices services)
    {
        _levelProgressService = services.Single<LevelProgressService>();
        services.Single<ClearStackService>().OnClearCompleted += UpdateProgressBar;
        
        foreach (var boosterButton in _boosterButtons)
        {
            boosterButton.Initialize(services.Single<BoosterService>());
        }
    }

    private void UpdateProgressBar()
    {
        _progressBar.UpdateValue(_levelProgressService.HexesCurrent, _levelProgressService.HexesGoal);
    }

    protected override void _Open()
    {
        base._Open();

        var lvl = _levelProgressService.CurrentLevelNumber;
        _level.SetText($"Level {lvl}");
        _progressBar.Initialize();
        UpdateProgressBar();
    }
}
