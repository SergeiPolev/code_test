using UnityEngine;
using UnityEngine.UI;
using Services;

public class BoosterButton : MonoBehaviour
{
    [SerializeField] private BoosterId _boosterId;
    
    private BoosterService _boosterService;
    
    private Button _button;
    
    public BoosterId BoosterId => _boosterId;

    public void Initialize(BoosterService boosterService)
    {
        _boosterService = boosterService;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
    }

    private void Click()
    {
        _boosterService.ActivateBooster(_boosterId);
    }
}