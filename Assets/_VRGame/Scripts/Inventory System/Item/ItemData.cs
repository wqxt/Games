using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    [Serialize]
    public string _itemTag;
    public string _itemName;
}
