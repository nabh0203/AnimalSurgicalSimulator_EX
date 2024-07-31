using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    public DigComplete digComplete;
    public MesComplete mesComplete;
    public ClampComplete clampComplete;

    [SerializeField] DigTask digTask;
    [SerializeField] ClampTask clampTask;
    [SerializeField] MesTask mesTask;

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
    public bool isNextTask = false;

    public delegate void MainTaskChanged(MainTask newMainTask);
    public event MainTaskChanged OnMainTaskChanged;

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
        SetActiveTask(currentMainTask);
    }

    public void UpdateTask(TaskName newTaskStatus)
    {
        task = newTaskStatus;
        if (task == TaskName.Complete)
        {
            ProceedToNextMainTask(); // ���� �½�ũ�� ��ȯ
        }
    }

    private void ProceedToNextMainTask()
    {
        switch (currentMainTask)
        {
            case MainTask.Mes:
                
            //    currentMainTask = MainTask.Clamp;
            //    break;
            //case MainTask.Clamp:
            //    currentMainTask = MainTask.Dig;
                break;
            case MainTask.Dig:
                TaskArrow.Instance.isCompleteArrow = true;
                Debug.Log("��� ���� �۾� �Ϸ�");
                return;
        }

        task = TaskName.Start; // �� �½�ũ�� ���� ���·� �ʱ�ȭ
        SetActiveTask(currentMainTask);
        OnMainTaskChanged?.Invoke(currentMainTask); // �̺�Ʈ ȣ��
        Debug.Log("���ο� ���� �۾�: " + currentMainTask);
    }

    private void SetActiveTask(MainTask newMainTask)
    {
        //if(digTask == enabled)
    }

    public void StartNewTask(MainTask newMainTask)
    {
        currentMainTask = newMainTask;
        task = TaskName.Start;
        SetActiveTask(newMainTask);
        OnMainTaskChanged?.Invoke(currentMainTask);
        Debug.Log("���ο� ���� �۾� ����: " + currentMainTask);
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
