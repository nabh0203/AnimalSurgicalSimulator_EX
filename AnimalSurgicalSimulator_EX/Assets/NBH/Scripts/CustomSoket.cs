using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocketHandler : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;
    public Transform[] targetPositions; // �̵��� ��ġ �迭

    private void OnEnable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnDisable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        // XRGrabInteractable�� ObjectIndex ������Ʈ�� ���� ������Ʈ�� ó���մϴ�.
        var interactable = args.interactableObject.transform.GetComponent<XRGrabInteractable>();
        var objectIndex = args.interactableObject.transform.GetComponent<SocketIndex>();

        if (interactable != null && objectIndex != null)
        {
            int index = objectIndex.index;

            // ��ȿ�� �ε������� Ȯ���մϴ�.
            if (index >= 0 && index < targetPositions.Length)
            {
                // ������Ʈ�� ������ ��ġ�� �̵���ŵ�ϴ�.
                args.interactableObject.transform.position = targetPositions[index].position;
                args.interactableObject.transform.rotation = targetPositions[index].rotation;
            }
        }
    }
}