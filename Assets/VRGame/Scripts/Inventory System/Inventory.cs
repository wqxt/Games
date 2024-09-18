using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    internal protected List<ItemInstance> _playerItemList = new();
    private int _scoreValue;
    public event Action ItemAdded;
    internal protected int ScoreValue
    {
        get
        {
            return _scoreValue;
        }
        set
        {
            _scoreValue = value;
        }
    }

    public void AddItem(ItemInstance itemInstance)
    {
        _playerItemList.Add(itemInstance);
        _scoreValue++;
    }
}