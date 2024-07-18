using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectBlinker : MonoBehaviour
{
    [SerializeField] XRBaseInteractor socketInteractor; // ���� ���ͷ��� ����
    [SerializeField] float blinkInterval = 0.5f; // �����̴� ����
    [SerializeField] List<XRGrabInteractable> grabInteractors; // XRGrabInteractable ����Ʈ
    [SerializeField] List<GameObject> objectsToBlink; // �����̰� �� ������Ʈ ����Ʈ

    bool isBlinking = false;
    bool isObjectInSocket = false;
    bool isGrabbed = false;
    int grabbedIndex = -1;

    void Start()
    {
        // ��� ������Ʈ�� ��Ȱ��ȭ
        foreach (var obj in objectsToBlink)
        {
            obj.SetActive(false);
        }

        // �� grabInteractor�� ���� SelectEntered �̺�Ʈ�� ���
        for (int i = 0; i < grabInteractors.Count; i++)
        {
            int index = i; // ĸó�� �ε���
            grabInteractors[i].selectEntered.AddListener((args) => OnGrabbed(index));
            grabInteractors[i].selectExited.AddListener((args) => OnReleased(index));
        }
    }

    void Update()
    {
        if (!isGrabbed)
        {
            if (grabbedIndex >= 0 && grabbedIndex < objectsToBlink.Count)
            {
                objectsToBlink[grabbedIndex].SetActive(false);
            }
            return;
        }

        // ���Ͽ� ������Ʈ�� �ִ��� Ȯ��
        isObjectInSocket = socketInteractor.hasSelection;

        // ���Ͽ� ������Ʈ�� ���� �����̴� ���� �ƴ϶�� �����̱� ����
        if (!isObjectInSocket && !isBlinking)
        {
            objectsToBlink[grabbedIndex].SetActive(true);
            StartCoroutine(BlinkObject(grabbedIndex));
        }
        else if (isObjectInSocket && !isBlinking)
        {
            objectsToBlink[grabbedIndex].SetActive(false);
        }
    }

    private IEnumerator BlinkObject(int index)
    {
        isBlinking = true;

        while (!isObjectInSocket)
        {
            objectsToBlink[index].SetActive(!objectsToBlink[index].activeSelf);
            yield return new WaitForSeconds(blinkInterval);
            isObjectInSocket = socketInteractor.hasSelection;
        }

        // ������Ʈ�� ���Ͽ� ���� �����̱� ����
        objectsToBlink[index].SetActive(true);
        isBlinking = false;
    }

    private void OnGrabbed(int index)
    {
        isGrabbed = true;
        grabbedIndex = index;
    }

    private void OnReleased(int index)
    {
        isGrabbed = false;
        grabbedIndex = -1;
    }
}
