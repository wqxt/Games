using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public Collider _collider;
    public GameObject _image;
    private void OnTriggerEnter(Collider other) => _image.SetActive(true);

}
