//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TaskUIManager : MonoBehaviour
//{
//    public static TaskUIManager instance;
//    [SerializeField] HandModelControllNBH controllNBH;
//    [SerializeField] GameObject[] taskCompleteUI; // �۾� �Ϸ� UI ���
//    private int currentTaskIndex = 0; // ���� ǥ���� �۾� �ε���
//    private bool[] taskUIActivated; // �� UI�� Ȱ��ȭ ����
//    bool startUI = true;
//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//            taskUIActivated = new bool[taskCompleteUI.Length]; // UI Ȱ��ȭ ���� �迭 �ʱ�ȭ
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }
//    private void Start()
//    {
//        controllNBH.TaskCompleted += isUiTask;
//    }
//    //public void ShowNextTaskUI()
//    //{
//    //    // ���� �ε����� UI �迭�� ���̸� �ʰ����� �ʰ�, �̹� Ȱ��ȭ���� ���� ��쿡�� UI�� Ȱ��ȭ
//    //    if (currentTaskIndex < taskCompleteUI.Length && !taskUIActivated[currentTaskIndex])
//    //    {
//    //        Debug.Log("Open UI");
//    //        taskCompleteUI[currentTaskIndex].SetActive(true); // ���� �۾� UI Ȱ��ȭ
//    //        taskUIActivated[currentTaskIndex] = true; // ���� UI Ȱ��ȭ ���� ���
//    //        currentTaskIndex++; // ���� �۾����� �̵�
//    //    }
//    //    else if (currentTaskIndex >= taskCompleteUI.Length)
//    //    {
//    //        Debug.Log("��� UI�� �̹� Ȱ��ȭ�Ǿ����ϴ�.");
//    //    }
//    //}

//    //public void CloseCurrentTaskUI()
//    //{
//    //    if (startUI)
//    //    {
//    //        taskCompleteUI[currentTaskIndex].SetActive(false); // ���� �۾� UI ��Ȱ��ȭ
//    //        currentTaskIndex++; // ���� �۾����� �̵�
//    //        startUI = false;
//    //    }
//    //    if (currentTaskIndex > 0 && !startUI)
//    //    {
//    //        currentTaskIndex--; // ���� �۾����� �̵�
//    //        taskCompleteUI[currentTaskIndex].SetActive(false); // ���� �۾� UI ��Ȱ��ȭ
//    //        Debug.Log("Close UI");
//    //    }
//    //}

//    public void isUiTask(bool isCompleted)
//    {
//        taskCompleteUI[currentTaskIndex].SetActive(false); // ���� �۾� UI ��Ȱ��ȭ
//        currentTaskIndex++;
//        taskCompleteUI[currentTaskIndex].SetActive(true); // ���� �۾� UI ��Ȱ��ȭ
//        currentTaskIndex++; // ���� �۾����� �̵�
//    }
//}
