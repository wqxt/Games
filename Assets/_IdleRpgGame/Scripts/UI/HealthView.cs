using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentHealthValueText;
    [SerializeField] private TextMeshProUGUI _maxHealthValueText;
    [SerializeField] private Slider _healthSlider;

    public void ChangeHealth(int currentHealthValue)
    {
        _healthSlider.value = currentHealthValue;
        _currentHealthValueText.text = _healthSlider.value.ToString();
    }
}