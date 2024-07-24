using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocketNBH : MonoBehaviour
{
    [SerializeField] Transform attach;
    [SerializeField] LayerMask socketLayer;
    [SerializeField] GameObject hoverMesh;
    [SerializeField] List<XRGrabInteractable> selectObjectGrabInteractable;

    [SerializeField] List<CustomSocketNBH> sokets; // ���� ����Ʈ

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
        for (int i = 0; i < sokets.Count; i++)
        {
            // ���õ� ������Ʈ�� ���� ���
            if (!selectObjectGrabInteractable[i].isSelected)
            {
                hasSelection = true;
                hoverMesh.SetActive(false);
                Debug.Log("���ϵ��");
                // �ش� ������ ��ġ�� �̵�
                selectObjectGrabInteractable[i].transform.position = sokets[i].attach.position;
                selectObjectGrabInteractable[i].transform.rotation = sokets[i].attach.rotation;
                
                return; // �ش� ������Ʈ�� �̵��� �� �ݺ��� ����
            }
            else
            {
                hoverMesh.SetActive(true);
                hasSelection = false;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        hoverMesh.SetActive(false);
    }
}
