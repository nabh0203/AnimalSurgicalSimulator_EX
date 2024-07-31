using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectBlinker : MonoBehaviour
{
    //[SerializeField] XRBaseInteractor socketInteractor; // ���� ���ͷ��� ����
    [SerializeField] CustomSocket socket;
    //[SerializeField] CustomSocketNBH socket;
    [SerializeField] float blinkInterval = 0.5f; // �����̴� ����
    [SerializeField] List<XRGrabInteractable> grabInteractors; // XRGrabInteractable ����Ʈ
    [SerializeField] List<GameObject> objectsToBlink; // �����̰� �� ������Ʈ ����Ʈ
    [SerializeField] HandModelControll handModelControll; // HandModelControll �ν��Ͻ� ����
    [SerializeField] DrillTaskHandModelControll drillHandModelController;
    [SerializeField] MesTaskHandModelControll mesHandModelController;
    [SerializeField] ClampTaskHandModelControll calmpHandModelController;

    bool isObjectInSocket = false;
    bool isGrabbed = false;
    int grabbedIndex = -1;

    public enum BlinkName
    {
        Mes,
        Clamp,
        Dig
    }

    public BlinkName blinkName;


    void Start()
    {
        for (int i = 0; i < grabInteractors.Count; i++)
        {
            int index = i; // ĸó�� �ε���
            grabInteractors[i].selectEntered.AddListener((args) => OnGrabbed(index));
            grabInteractors[i].selectExited.AddListener((args) => OnReleased(index));
        }

        handModelControll.IsTaskCompleted += OnTaskCompleted;
        // HandModelControll�� TaskCompleted �̺�Ʈ ����
        if (blinkName == BlinkName.Mes)
        {
            mesHandModelController.IsTaskCompleted += OnTaskCompleted;
        }
        else if (blinkName == BlinkName.Clamp)
        {
            calmpHandModelController.IsTaskCompleted += OnTaskCompleted;
        }
        else if (blinkName == BlinkName.Dig)
        {
            drillHandModelController.IsTaskCompleted += OnTaskCompleted;
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
    }
    private IEnumerator BlinkObject(int index)
    {
        while (!isObjectInSocket)
        {
            objectsToBlink[index].SetActive(!objectsToBlink[index].activeSelf);
            yield return new WaitForSeconds(blinkInterval);
            isObjectInSocket = socket.hasSelection;
        }

        // ������Ʈ�� ���Ͽ� ���� �����̱� ����
        objectsToBlink[index].SetActive(false);
        TaskManager.instance.isNextTask = true;
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
            // ���⿡�� �ʿ��� �۾��� �����մϴ�.
            if (grabbedIndex >= 0 && grabbedIndex < objectsToBlink.Count)
            {
                StartCoroutine(BlinkObject(grabbedIndex));
            }
        }
    }
}
