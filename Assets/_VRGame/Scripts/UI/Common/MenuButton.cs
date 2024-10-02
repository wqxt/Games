using System;
using UnityEngine.EventSystems;

public class MenuButton : AbstractButton
{
    public Action ButtonClick;
    public Action<string> ButtonSelectItem;

    public override void OnPointerClick(PointerEventData eventData)
    {
       ButtonClick?.Invoke();
       ButtonSelectItem?.Invoke(eventData.pointerPress.tag);
    }
}