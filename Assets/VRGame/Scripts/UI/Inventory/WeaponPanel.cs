using System.Collections.Generic;
using UnityEngine;

public class WeaponPanel : AbstractPanel
{
    [SerializeField] private List<MenuButton> _buttonList;

    private void Awake()
    {
        Addpanel("WeaponPanel", this);
        HidePanel();
    }

    public override void ShowPanel() => base.ShowPanel();
    public override void HidePanel() => base.HidePanel();
}