using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIManager : MonoBehaviour
{
    public static TaskUIManager instance;

    [SerializeField] GameObject[] taskCompleteUI; // �۾� �Ϸ� UI ���
    private int currentTaskIndex = 0; // ���� ǥ���� �۾� �ε���

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowTaskCompleteUI()
    {
        if (currentTaskIndex < taskCompleteUI.Length)
        {
            Debug.Log("Open UI");
            taskCompleteUI[currentTaskIndex].SetActive(true); // ���� �۾� UI Ȱ��ȭ
            currentTaskIndex++; // ���� �۾����� �̵�
        }
    }

    public void CloseTaskCompleteUI()
    {
        taskCompleteUI[currentTaskIndex].SetActive(false); // ���� �۾� UI ��Ȱ��ȭ
        if (currentTaskIndex > 0)
        {
            Debug.Log("Close UI");
            currentTaskIndex--; // ���� �۾����� �̵�
            taskCompleteUI[currentTaskIndex].SetActive(false); // ���� �۾� UI ��Ȱ��ȭ
        }
    }
}
