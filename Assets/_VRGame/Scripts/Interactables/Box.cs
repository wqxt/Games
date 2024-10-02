using System;
using System.Collections;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _audioSource;

    public Action<ItemInstance> HideDroppedObject;
    public Action RemoveDroppedObject;
    public Action<string> SetUIText;
    public Action TeleportPlayer;
    public Action ObjectDropped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemInstance itemInstance) && gameObject.tag != "BoxC")
        {
            if (itemInstance._itemData._itemName == "StoneLiftCoffin")
            {
                SetUIText?.Invoke(this.tag);
                ObjectDropped?.Invoke();
                _particleSystem.Play();
                _audioSource.Play();
            }
        }
        else
        {
            HideDroppedObject?.Invoke(itemInstance);
            TeleportPlayer?.Invoke();
            SetUIText?.Invoke("BoxB");
            ObjectDropped?.Invoke();
            StartCoroutine(RemoveObject(itemInstance));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _particleSystem.Stop();
        _audioSource.Stop();
        RemoveDroppedObject?.Invoke();
    }

    private IEnumerator RemoveObject(ItemInstance itemInstance)
    {
        yield return new WaitForSeconds(1f);
        RemoveDroppedObject?.Invoke();
    }
}