using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachIndicatorNBH : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject indicatorAttach;
    [SerializeField] Transform handModelAttach;
    [SerializeField] GameObject handModel;
    [SerializeField] XRGrabInteractable grabInteractor;

    /*������Ʈ �����̰� �ϴ� ����*/
    [SerializeField] XRBaseInteractor socketInteractor; // ���� ���ͷ��� ����
    [SerializeField] GameObject objectToBlink; // �����̰� �� ������Ʈ
    [SerializeField] float blinkInterval = 0.5f; // �����̴� ����


    bool isAttach = false;
    bool isBlinking = false;
    bool isObjectInSocket = false;

    private void Update()
    {
        float distance = Vector3.Distance(indicator.transform.position, gameObject.transform.position);

        if (!isAttach && grabInteractor.isSelected && distance <= 0.2f)
        {
            indicator.SetActive(false);

            handModel.transform.position = indicatorAttach.transform.position;
            handModel.transform.SetParent(null);
            isAttach = true;
        }
        else if (isAttach && grabInteractor.isSelected && distance <= 0.2f)
        {
            handModel.transform.position = new Vector3(indicatorAttach.transform.position.x, indicatorAttach.transform.position.y, gameObject.transform.position.z);
            handModel.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }
        else if ((isAttach && distance > 0.2f) || !grabInteractor.isSelected)
        {
            indicator.SetActive(true);
            handModel.transform.SetParent(gameObject.transform);
            handModel.transform.position = handModelAttach.position;
            isAttach = false;
        }
    }
}