using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Base
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fillImage;
        [SerializeField] private TextMeshProUGUI _amountText;

        private float _originalDelta;

        private bool _initialized = false;
    
        public void Initialize()
        {
            if (_initialized) return;
        
            _originalDelta = _fillImage.rectTransform.rect.width;
            _initialized = true;
        }

        public void UpdateValue(float current, float goal)
        {
            float value = current / goal;

            Vector2 rectSize = _fillImage.rectTransform.sizeDelta;
            rectSize.x = Mathf.Clamp(_originalDelta * (1 - value) * -1, -_originalDelta, 0);
            _fillImage.rectTransform.sizeDelta = rectSize;
            _amountText.SetText($"{current}/{goal}");
        }
    }
}