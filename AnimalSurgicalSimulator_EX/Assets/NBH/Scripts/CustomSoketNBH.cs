using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocketNBH : MonoBehaviour
{
    [SerializeField] List<Transform> attach; // ������ ��ġ
    [SerializeField] LayerMask socketLayer; // ���� ���̾�
    [SerializeField] GameObject hoverMesh; // ȣ�� �޽�
    [SerializeField] List<XRGrabInteractable> selectObjectGrabInteractable; // �׷� ������ ������Ʈ ����Ʈ

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
        for (int i = 0; i < selectObjectGrabInteractable.Count; ++i)
        {
            XRGrabInteractable grabInteractable = selectObjectGrabInteractable[i];

            // �ش� ������Ʈ�� Ʈ���ŵ� ���
            if (grabInteractable != null && other.gameObject == grabInteractable.gameObject)
            {
                print(selectObjectGrabInteractable[i]);
                // ���Ͽ� ����
                if (i < attach.Count)
                {
                    grabInteractable.transform.position = attach[i].position;
                    grabInteractable.transform.rotation = attach[i].rotation;

                    hasSelection = true;
                    hoverMesh.SetActive(false);
                }
                break; // �ϳ��� ������Ʈ�� ó��
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
