using System;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentsPanel : AbstractPanel
{
    [SerializeField] private List<MenuButton> _buttonList;
    [SerializeField] private Inventory _inventory;
    public Action ObjectAdded;
    private void Awake()
    {
        Addpanel("InstrumentsPanel", this);

        foreach (var button in _buttonList)
        {
            button.gameObject.SetActive(false);
        }

        HidePanel();
    }

    private void OnEnable()
    {
        foreach (var button in _buttonList)
        {
            button.ButtonSelectItem += SelectItem;

        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttonList)
        {
            button.ButtonSelectItem += SelectItem;
        }
    }

    private void SelectItem(string buttonName)
    {
        foreach (var item in _inventory._playerItemList)
        {
            if (item._itemData._itemName == buttonName)
            {
                item.gameObject.SetActive(true);
                item.gameObject.transform.SetParent(null, true);
                _inventory._playerItemList.Remove(item);
                HideButton(buttonName);
                HidePanel();
                return;
            }
        }

    }

    private void HideButton(string buttonName)
    {
        foreach (var button in _buttonList)
        {
            if (button.tag == buttonName)
            {
                button.gameObject.SetActive(false);
                return;
            }
        }
    }

    private void CheckPanelButton(ItemInstance item)
    {
        foreach (var button in _buttonList)
        {
            if (button.tag == item._itemData._itemName)
            {
                button.gameObject.SetActive(true);
                ObjectAdded?.Invoke();
            }
        }
    }

    private void CheckInventoryItem()
    {
        foreach (var instrument in _inventory._playerItemList)
        {
            CheckPanelButton(instrument);
        }
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        CheckInventoryItem();
    }

    public override void HidePanel()
    {
        base.HidePanel();
        CheckInventoryItem();
    }
}
