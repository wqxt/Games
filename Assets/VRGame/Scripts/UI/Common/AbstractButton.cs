using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AbstractButton : MonoBehaviour, IPointerClickHandler
{
    public virtual void OnPointerClick(PointerEventData eventData) { }
}