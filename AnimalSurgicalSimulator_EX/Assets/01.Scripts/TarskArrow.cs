//using System.Collections.Generic;
//using UnityEngine;
//using static DigTask;
//using static TaskManager;

//public class TaskArrow : MonoBehaviour
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
//    }

//    void Update()
//    {
//        for (int i = 0; i < targets.Count; i++)
//        {
//            if (targets[i] != null && targets[i].gameObject.activeInHierarchy)
//            {
//                Vector3 cameraPosition = mainCamera.transform.position;
//                Vector3 objectPosition = targets[i].position;

//                // ���� ���� ���
//                Vector3 directionToTarget = objectPosition - cameraPosition;
//                float angle = Vector3.SignedAngle(mainCamera.transform.forward, directionToTarget, Vector3.up);

//                // �þ߰� Ȯ��
//                if (Mathf.Abs(angle) <= fieldOfView / 2)
//                {
//                    // �þ߰� �ȿ� ���� ���� ó�� (��: �۾� ���� ��������)
//                    TaskName currentTask = TaskManager.instance.task;
//                    // TargetView(i, currentTask);
//                    arrow[0].SetActive(false);
//                    arrow[1].SetActive(false);
//                }
//                else
//                {
//                    // �þ߰��� ������ �ʴ� ��� ���⿡ ���� ȭ��ǥ Ȱ��ȭ
//                    if (angle < 0)
//                    {
//                        // ���ʿ� ��ġ
//                        arrow[0].SetActive(true);
//                        arrow[1].SetActive(false);
//                    }
//                    else
//                    {
//                        // �����ʿ� ��ġ
//                        arrow[0].SetActive(false);
//                        arrow[1].SetActive(true);
//                    }
//                }
//            }
//            else
//            {
//                // Ÿ���� ��Ȱ��ȭ �Ǿ� ������ ȭ��ǥ ��Ȱ��ȭ
//                arrow[0].SetActive(false);
//                arrow[1].SetActive(false);
//            }
//        }
//    }
//}
using System.Collections.Generic;
using UnityEngine;

public class TaskArrow : MonoBehaviour
{
    private static TaskArrow instance; // �̱��� �ν��Ͻ�
    private Camera mainCamera;
    [SerializeField] float fieldOfView; // �ٶ󺸴� ���� ��� ����
    [SerializeField] GameObject[] arrow; // ��Ȱ��ȭ�� Arrow ������Ʈ
    private List<Transform> targets; // Ÿ�� ����Ʈ
    public static TaskArrow Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TaskArrow>();
                if (instance == null)
                {
                    Debug.LogError("TaskArrow instance not found in the scene.");
                }
            }
            return instance;
        }
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (targets == null || targets.Count == 0) return;

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null && targets[i].gameObject.activeInHierarchy)
            {
                Vector3 cameraPosition = mainCamera.transform.position;
                Vector3 objectPosition = targets[i].position;

                // ���� ���� ���
                Vector3 directionToTarget = objectPosition - cameraPosition;
                float angle = Vector3.SignedAngle(mainCamera.transform.forward, directionToTarget, Vector3.up);

                // �þ߰� Ȯ��
                if (Mathf.Abs(angle) <= fieldOfView / 2)
                {
                    // �þ߰� �ȿ� ���� ���� ó��
                    arrow[0].SetActive(false);
                    arrow[1].SetActive(false);
                }
                else
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
            else
            {
                // Ÿ���� ��Ȱ��ȭ �Ǿ� ������ ȭ��ǥ ��Ȱ��ȭ
                arrow[0].SetActive(false);
                arrow[1].SetActive(false);
            }
        }
    }

    public void SetTargets(List<Transform> newTargets)
    {
        targets = newTargets;
    }
}
