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
    [SerializeField] HandModelControll handModelControll; // HandModelControll �ν��Ͻ� ����

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

        // HandModelControll�� TaskCompleted �̺�Ʈ ����
        handModelControll.IsTaskCompleted += OnTaskCompleted;
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
    }

    private IEnumerator BlinkObject(int index)
    {
        Debug.Log("��ũ");

        while (!isObjectInSocket)
        {
            objectsToBlink[index].SetActive(!objectsToBlink[index].activeSelf);
            yield return new WaitForSeconds(blinkInterval);
            isObjectInSocket = socketInteractor.hasSelection;
        }

        // ������Ʈ�� ���Ͽ� ���� �����̱� ����
        objectsToBlink[index].SetActive(false);
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

    // TaskCompleted �̺�Ʈ�� �߻��� �� ������ �޼���
    private void OnTaskCompleted(bool taskComplete)
    {
        if (taskComplete)
        {
            Debug.Log("Task is completed.");
            // ���⿡�� �ʿ��� �۾��� �����մϴ�.
            if (grabbedIndex >= 0 && grabbedIndex < objectsToBlink.Count)
            {
                StartCoroutine(BlinkObject(grabbedIndex));
            }
        }
    }

    //// ���� �ε����� ���� ������ ���� �����ϴ� �޼���
    //public void SetSocketPosition(int index)
    //{
    //    if (index >= 0 && index < socketIndexes.Count)
    //    {
    //        socketInteractor.transform.position = socketIndexes[index].transform.position;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("�߸��� �ε����Դϴ�.");
    //    }
    //}
}
