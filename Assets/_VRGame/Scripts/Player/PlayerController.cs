using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private TrackedPoseDriver _trackedPoseDriver;
    [SerializeField] private XRRayInteractor _xRRayInteractor;
    [SerializeField] private XRDeviceSimulator _simulator;
    [SerializeField] private XROrigin _xrOrigin;
    private Vector3 _playerBackPosition = new Vector3(0, 1.3f, 0);

    public event Action<ItemInstance> GripObject;
    public event Action OpenInventoryPanel;

    private void OnEnable()
    {
        _simulator.triggerAction.action.performed += TakeObject;
        _simulator.menuAction.action.performed += OpenMenu;
    }

    private void OnDisable()
    {
        _simulator.gripAction.action.performed -= TakeObject;
        _simulator.menuAction.action.performed -= OpenMenu;
    }

    private void TakeObject(InputAction.CallbackContext callbackcontext)
    {
        if (_simulator.gripAction.action.IsPressed())
        {
            try
            {
                if (_xRRayInteractor.rayEndTransform.gameObject.TryGetComponent(out ItemInstance itemInstance))
                {
                    Vector3 playerLocalPosition = _xrOrigin.Camera.transform.localPosition;
                    _playerBackPosition = transform.TransformPoint(playerLocalPosition);
                    HideObject(itemInstance);
                    OpenInventoryPanel?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("Item not found");
                    return;
                }
            }
            catch (Exception exeption)
            {
                Debug.LogException(exeption);
            }
        }
        else
        {
            return;
        }
    }

    protected internal void HideObject(ItemInstance itemInstance)
    {
        GripObject?.Invoke(itemInstance);
        itemInstance.transform.SetParent(_xRRayInteractor.gameObject.transform, true);
        itemInstance.gameObject.SetActive(false);
    }

    private void OpenMenu(InputAction.CallbackContext callbackcontext) => OpenInventoryPanel?.Invoke();
    internal protected void Teleport()
    {
        Vector3 playerPosition = new Vector3(_playerBackPosition.x, 1.3f, _playerBackPosition.z);
        _xrOrigin.MoveCameraToWorldLocation(playerPosition);
    }
}