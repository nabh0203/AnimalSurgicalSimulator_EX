using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    //[SerializeField] List<MonoBehaviour> taskList;
    

    public DigComplete digComplete;
    public enum MainTask
    {
        Mes,
        Dig
        //Clamp,
    }
    public MesComplete mesComplete;

    [SerializeField] DigTask digTask;
    public enum TaskName
    {
        Start,
        Attach,
        Process,
        Complete
    }

    public MainTask currentMainTask = MainTask.Mes;
    public TaskName task = TaskName.Start; // ���� �۾� ����
    public bool isNextTask = false;
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

    public void NextTask()
    {
        if (task == TaskName.Complete)
        {
            ProceedToNextMainTask();
        }
    }

    private void ProceedToNextMainTask()
    {
        switch (currentMainTask)
        {
            case MainTask.Mes:
                //currentMainTask = MainTask.Clamp;
                currentMainTask = MainTask.Dig;
                break;
            //case MainTask.Clamp:
            //    currentMainTask = MainTask.Dig;
            //    break;
            case MainTask.Dig:
                TaskArrow.Instance.isCompleteArrow = true;
                Debug.Log("��� ���� �۾� �Ϸ�");
                return;
        }

        task = TaskName.Start; // �� �½�ũ�� ���� ���·� �ʱ�ȭ
        Debug.Log("���ο� ���� �۾�: " + currentMainTask);
    }

    public void UpdateTask(TaskName newTaskStatus)
    {
        task = newTaskStatus;
        if (task == TaskName.Complete)
        {
            NextTask(); // ���� �½�ũ�� �Ѿ��
        }
    }
    //public void NextTask()
    //{
    //    currentTaskIndex++;
    //    if (currentTaskIndex < taskList.Count)
    //    {
    //        task = TaskName.Start;
    //        taskList[currentTaskIndex].enabled = true;  // ���� �½�ũ Ȱ��ȭ
    //    }
    //    else if (currentTaskIndex == taskList.Count)
    //    {
    //        TaskArrow.Instance.isCompleteArrow = true;
    //        Debug.Log("�׽�ũ ����");
    //        return;
    //    }
    //}

    //// ���� �½�ũ ��ȯ
    //public MonoBehaviour GetCurrentTask()
    //{
    //    return taskList[currentTaskIndex];
    //}
}
