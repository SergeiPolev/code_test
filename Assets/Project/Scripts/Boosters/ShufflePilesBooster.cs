using System;
using Infrastructure;
using Services;
using UnityEngine;

public class ShufflePilesBooster : IBooster
{
    private HexPilesService _pilesService;
    private float _timer;
    
    public event Action<BoosterProgressEvent> OnProgressChanged;

    public event Action OnActivated;
    public event Action OnDeactivated;
    
    public bool IsActive { get; private set; }

    public BoosterId BoosterId => BoosterId.ShufflePiles;
    
    public ShufflePilesBooster(AllServices services)
    {
        _pilesService = services.Single<HexPilesService>();
    }
    
    public void Activate()
    {
        IsActive = true;

        _timer = 0;
        _pilesService.ShufflePiles();
        OnActivated?.Invoke();
    }

    public void Tick()
    {
        if (IsActive == false)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            IsActive = false;
        }
        
        OnProgressChanged?.Invoke(new BoosterProgressEvent(_timer, 1, 1 - _timer));
    }

    public void Deactivate()
    {
        IsActive = false;
        
        OnDeactivated?.Invoke();
    }
}