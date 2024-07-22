using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIManager : MonoBehaviour
{
    [SerializeField] GameObject[] taskCompleteUI; // �۾� �Ϸ� UI ���

    private int currentTaskIndex = 0; // ���� ǥ���� �۾� �ε���

    // �۾� �Ϸ� UI ǥ��
    public void ShowTaskCompleteUI()
    {
        if (currentTaskIndex < taskCompleteUI.Length)
        {
            taskCompleteUI[currentTaskIndex].SetActive(true); // ���� �۾� UI Ȱ��ȭ
            currentTaskIndex++; // ���� �۾����� �̵�
        }
    }

    public void CloseTaskCompleteUI()
    {
        if (currentTaskIndex > 0)
        {
            currentTaskIndex--; // ���� �۾����� �̵�
            taskCompleteUI[currentTaskIndex].SetActive(false); // ���� �۾� UI ��Ȱ��ȭ
        }
    }
}
