using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    //[SerializeField] List<MonoBehaviour> taskList;
    int currentTaskIndex = 0;
    public bool isNextTask = false;

    public DigComplete digComplete;
    public enum MainTask
    {
        Mes,
        Clamp,
        Dig
    }
    public enum TaskName
    {
        Start,
        Attach,
        Process,
        Complete
    }

    public MainTask currentMainTask = MainTask.Mes;
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
    private void Start()
    {
        InitializeMainTask(currentMainTask);
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
                currentMainTask = MainTask.Clamp;
                break;
            case MainTask.Clamp:
                currentMainTask = MainTask.Dig;
                break;
            case MainTask.Dig:
                TaskArrow.Instance.isCompleteArrow = true;
                Debug.Log("��� ���� �۾� �Ϸ�");
                return;
        }

        InitializeMainTask(currentMainTask); // ���ο� ���� �½�ũ�� �ʱ�ȭ�մϴ�
    }

    public void UpdateTask(TaskName newTaskStatus)
    {
        task = newTaskStatus;
        if (task == TaskName.Complete)
        {
            NextTask(); // ���� �½�ũ�� �Ѿ��
        }
    }

    public void SetMainTask(MainTask newMainTask)
    {
        currentMainTask = newMainTask;
        InitializeMainTask(currentMainTask); // ���� �½�ũ �ʱ�ȭ
    }

    private void InitializeMainTask(MainTask mainTask)
    {
        // ���� �½�ũ�� ���� �� �½�ũ�� �ʱ�ȭ �۾��� �����մϴ�.
        // ��: TaskArrow.Instance.SetTargets(...); // �ʿ信 ���� Ÿ�� ����
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
