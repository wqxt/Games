using TMPro;
using UnityEngine;

public class GameplayPanel : AbstractPanel
{
    [SerializeField] private TextMeshProUGUI _boxText;

    private void Awake()
    {
        _panelsList.Add("GameplayPanel", this);
        HidePanel();
    }

    public override void ShowPanel() => base.ShowPanel();
    public override void HidePanel() => base.HidePanel();
    public void SetText(string textAction) => _boxText.text = textAction;
}
