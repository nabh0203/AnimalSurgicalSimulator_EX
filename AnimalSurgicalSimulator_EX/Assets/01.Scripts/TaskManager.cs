using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    
    public DigComplete digComplete;
    //[SerializeField] List<MonoBehaviour> taskList;
    //int currentTaskIndex = 0;
    //[SerializeField] DigTask digTask;
    public enum TaskName
    {
        Start,
        Attach,
        Process,
        Complete
    }

    public TaskName task = TaskName.Start; // ���� �۾� ����

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
    //public void NextTask()
    //{
    //    if (currentTaskIndex < taskList.Count - 1) // ���� �ε����� ������ �½�ũ���� ���� ���� ����
    //    {
    //        taskList[currentTaskIndex].enabled = false; // ���� �½�ũ ��Ȱ��ȭ
    //        currentTaskIndex++;
    //        task = TaskName.Start;
    //        taskList[currentTaskIndex].enabled = true;  // ���� �½�ũ Ȱ��ȭ
    //    }
    //    else
    //    {
    //        Debug.Log("No more tasks available."); // ��� �½�ũ�� �Ϸ�� ��� �޽��� ���
    //    }
    //}


    //// ���� �½�ũ ��ȯ
    //public MonoBehaviour GetCurrentTask()
    //{
    //    return taskList[currentTaskIndex];
    //}
}
