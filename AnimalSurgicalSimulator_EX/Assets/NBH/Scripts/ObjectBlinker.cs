using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectBlinker : MonoBehaviour
{
    [SerializeField] XRBaseInteractor socketInteractor; // ���� ���ͷ��� ����
    [SerializeField] GameObject objectToBlink; // �����̰� �� ������Ʈ
    [SerializeField] float blinkInterval = 0.5f; // �����̴� ����
    [SerializeField] XRGrabInteractable[] grabInteractor;

    bool isBlinking = false;
    bool isObjectInSocket = false;

    void Start()
    {
        objectToBlink.SetActive(false);
    }
    void Update()
    {
        // ���Ͽ� ������Ʈ�� �ִ��� Ȯ��
        isObjectInSocket = socketInteractor.hasSelection;

        // ���Ͽ� ������Ʈ�� ���� �����̴� ���� �ƴ϶�� �����̱� ����
        if (!isObjectInSocket && !isBlinking)
        {
            objectToBlink.SetActive(true);
            StartCoroutine(BlinkObject());
        }
        else if(isObjectInSocket && !isBlinking)
        {
            objectToBlink.SetActive(false);
        }
    }

    private IEnumerator BlinkObject()
    {
        isBlinking = true;

        while (!isObjectInSocket)
        {
            objectToBlink.SetActive(!objectToBlink.activeSelf);
            yield return new WaitForSeconds(blinkInterval);
            isObjectInSocket = socketInteractor.hasSelection;
        }

        // ������Ʈ�� ���Ͽ� ���� �����̱� ����
        objectToBlink.SetActive(true);
        isBlinking = false;
    }
}
