using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocket : MonoBehaviour
{
    [SerializeField] Transform attach;
    [SerializeField] LayerMask socketLayer;
    [SerializeField] GameObject hoverMesh;
    [SerializeField] XRGrabInteractable selectObjectGrabInteractable;

    public bool hasSelection = false;
    private void OnTriggerEnter(Collider other)
    {
        if ((socketLayer & (1 << other.gameObject.layer)) != 0)
        {
            hoverMesh.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!selectObjectGrabInteractable.isSelected)
        {
            selectObjectGrabInteractable.transform.position = attach.position;
            selectObjectGrabInteractable.transform.rotation = attach.rotation;

            hasSelection = true;

            hoverMesh.SetActive(false);
        }
        else
        {
            hoverMesh.SetActive(true);
            hasSelection = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hoverMesh.SetActive(false);
    }
}