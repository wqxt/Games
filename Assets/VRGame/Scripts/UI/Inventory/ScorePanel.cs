using TMPro;
using UnityEngine;

public class ScorePanel : AbstractPanel
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Inventory _inventory;

    private void Awake()
    {
        Addpanel("ScorePanel", this);
        HidePanel();
    }
    public override void ShowPanel()
    {
        _scoreText.text = _inventory.ScoreValue.ToString();
        base.ShowPanel();
    }
    public override void HidePanel() => base.HidePanel();
}
