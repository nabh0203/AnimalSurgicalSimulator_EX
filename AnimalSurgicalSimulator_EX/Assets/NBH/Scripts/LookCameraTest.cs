//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static DigTask; // TaskName�� ���ǰ� �ִ� ����
//using static TaskManager; // TaskManager�� ���ǰ� �ִ� ����

//public class LookCameraTest : MonoBehaviour
//{
//    Camera mainCamera;
//    [SerializeField] List<Transform> targets; // �ٶ� ������Ʈ ����Ʈ
//    [SerializeField] float fieldOfView; // �ٶ󺸴� ���� ��� ����
//    [SerializeField] GameObject[] arrow; // ��Ȱ��ȭ�� Arrow ������Ʈ

//    public delegate void TaskStateChanged(TaskName task);
//    public event TaskStateChanged OnTaskStateChanged;

//    void Start()
//    {
//        mainCamera = Camera.main;
//        OnTaskStateChanged += RotateArrow;
//    }
//    void Update()
//    {
//        for (int i = 0; i < targets.Count; i++)
//        {
//            bool isOnTargets = targets[i].gameObject.activeInHierarchy;

//            if (targets[i] != null)
//            {
//                Vector3 directionToTarget = targets[i].position - mainCamera.transform.position;
//                float angle = Vector3.Angle(mainCamera.transform.forward, directionToTarget);

//                if (angle <= fieldOfView / 2 && isOnTargets)
//                {
//                   TaskName currentTask = TaskManager.instance.task; // ���� �۾� ���¸� ������
//                   TargetView(i, currentTask); // index�� ���� �۾��� �Ѱ���
//                }
//            }
//        }
//    }

//    void TargetView(int targetIndex, TaskName currentTask)
//    {
//        switch (targetIndex)
//        {
//            case 0:
//                arrow[0].SetActive(false);
//                if (currentTask == TaskName.Attach && targets[0].gameObject.activeInHierarchy) 
//                {
//                    RotateArrow(TaskName.Attach);
//                }
//                break;
//            case 1:
//                arrow[0].SetActive(false);
//                if (currentTask == TaskName.Dig && targets[1].gameObject.activeInHierarchy)
//                {
//                    RotateArrow(TaskName.Dig);
//                }
//                break;
//            case 2:
//                if (currentTask == TaskName.Complete && targets[2].gameObject.activeInHierarchy)
//                {
//                    RotateArrow(TaskName.Complete);
//                    arrow[0].SetActive(false); // Arrow ��Ȱ��ȭ
//                }
//                break;
//            default:
//                arrow[0].SetActive(false); // Arrow ��Ȱ��ȭ
//                arrow[1].SetActive(false); // Arrow ��Ȱ��ȭ
//                break;
//        }
//    }

//    private void TaskStateChange(TaskName taskName)
//    {
//        TaskManager.instance.task = taskName;
//        OnTaskStateChanged?.Invoke(TaskManager.instance.task);
//    }

//    void RotateArrow(TaskName task)
//    {
//        switch (task)
//        {
//            case TaskName.Attach:
//                if(task == TaskName.Attach)
//                arrow[1].SetActive(true);
//                break;

//            case TaskName.Dig:
//                if (task == TaskName.Dig)
//                    arrow[1].SetActive(true);
//                break;

//            case TaskName.Complete:
//                if (task == TaskName.Complete)
//                    arrow[1].SetActive(true);
//                break;

//            default:
//                break;
//        }
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DigTask; // TaskName�� ���ǰ� �ִ� ����
using static TaskManager; // TaskManager�� ���ǰ� �ִ� ����

public class LookCameraTest : MonoBehaviour
{
    Camera mainCamera;
    [SerializeField] List<Transform> targets; // �ٶ� ������Ʈ ����Ʈ
    [SerializeField] float fieldOfView; // �ٶ󺸴� ���� ��� ����
    [SerializeField] GameObject[] arrow; // ��Ȱ��ȭ�� Arrow ������Ʈ

    public delegate void TaskStateChanged(TaskName task);
    public event TaskStateChanged OnTaskStateChanged;

    void Start()
    {
        mainCamera = Camera.main;
        //OnTaskStateChanged += RotateArrow;
    }

    void Update()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            bool isOnTargets = targets[i].gameObject.activeInHierarchy;

            if (targets[i] != null)
            {
                Vector3 directionToTarget = targets[i].position - mainCamera.transform.position;
                float angle = Vector3.SignedAngle(mainCamera.transform.forward, directionToTarget, Vector3.up);

                // �þ߰��� Ÿ���� Ȱ��ȭ ���� Ȯ��
                if (Mathf.Abs(angle) <= fieldOfView / 2 && isOnTargets)
                {
                    TaskName currentTask = TaskManager.instance.task; // ���� �۾� ���¸� ������
                    //TargetView(i, currentTask); // index�� ���� �۾��� �Ѱ���
                }
                else if (isOnTargets)
                {
                    // �þ߰��� ������ �ʴ� ��� ���⿡ ���� ȭ��ǥ Ȱ��ȭ
                    if (angle < 0)
                    {
                        // ���ʿ� ��ġ
                        arrow[0].SetActive(true);
                        arrow[1].SetActive(false);
                    }
                    else
                    {
                        // �����ʿ� ��ġ
                        arrow[0].SetActive(false);
                        arrow[1].SetActive(true);
                    }
                }
            }
        }
    }

    //void TargetView(int targetIndex, TaskName currentTask)
    //{
    //    switch (targetIndex)
    //    {
    //        case 0:
    //            arrow[0].SetActive(false);
    //            if (currentTask == TaskName.Attach && targets[0].gameObject.activeInHierarchy)
    //            {
    //                RotateArrow(TaskName.Attach);
    //            }
    //            break;
    //        case 1:
    //            arrow[0].SetActive(false);
    //            if (currentTask == TaskName.Dig && targets[1].gameObject.activeInHierarchy)
    //            {
    //                RotateArrow(TaskName.Dig);
    //            }
    //            break;
    //        case 2:
    //            if (currentTask == TaskName.Complete && targets[2].gameObject.activeInHierarchy)
    //            {
    //                RotateArrow(TaskName.Complete);
    //                arrow[0].SetActive(false); // Arrow ��Ȱ��ȭ
    //            }
    //            break;
    //        default:
    //            arrow[0].SetActive(false); // Arrow ��Ȱ��ȭ
    //            arrow[1].SetActive(false); // Arrow ��Ȱ��ȭ
    //            break;
    //    }
    //}

    //private void TaskStateChange(TaskName taskName)
    //{
    //    TaskManager.instance.task = taskName;
    //    OnTaskStateChanged?.Invoke(TaskManager.instance.task);
    //}

    //void RotateArrow(TaskName task)
    //{
    //    switch (task)
    //    {
    //        case TaskName.Attach:
    //            arrow[1].SetActive(true);
    //            break;

    //        case TaskName.Dig:
    //            arrow[1].SetActive(true);
    //            break;

    //        case TaskName.Complete:
    //            arrow[1].SetActive(true);
    //            break;

    //        default:
    //            break;
    //    }
    //}
}
