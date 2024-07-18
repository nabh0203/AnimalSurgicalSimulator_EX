using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectBlinker : MonoBehaviour
{
    [SerializeField] XRBaseInteractor socketInteractor; // ���� ���ͷ��� ����
    [SerializeField] GameObject objectToBlink; // �����̰� �� ������Ʈ
    [SerializeField] float blinkInterval = 0.5f; // �����̴� ����
    [SerializeField] List<XRGrabInteractable> grabInteractors; // XRGrabInteractable ����Ʈ

    bool isBlinking = false;
    bool isObjectInSocket = false;
    bool isGrabbed = false;

    void Start()
    {
        objectToBlink.SetActive(false);

        // �� grabInteractor�� ���� SelectEntered �̺�Ʈ�� ���
        foreach (var grabInteractor in grabInteractors)
        {
            grabInteractor.selectEntered.AddListener(OnGrabbed);
            grabInteractor.selectExited.AddListener(OnReleased);
        }
    }

    void Update()
    {
        if (!isGrabbed)
        {
            objectToBlink.SetActive(false);
            return;
        }

        // ���Ͽ� ������Ʈ�� �ִ��� Ȯ��
        isObjectInSocket = socketInteractor.hasSelection;

        // ���Ͽ� ������Ʈ�� ���� �����̴� ���� �ƴ϶�� �����̱� ����
        if (!isObjectInSocket && !isBlinking)
        {
            objectToBlink.SetActive(true);
            StartCoroutine(BlinkObject());
        }
        else if (isObjectInSocket && !isBlinking)
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

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }
}
