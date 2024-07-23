using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomSocketNBH : XRSocketInteractor
{
    public List<GameObject> allowedObjects = new List<GameObject>();

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        // �⺻ ������ �����Ǵ��� Ȯ��
        if (!base.CanSelect(interactable))
            return false;

        // ������Ʈ�� ���� ������Ʈ ��Ͽ� �ִ��� Ȯ��
        return allowedObjects.Contains(interactable.transform.gameObject);
    }
}
