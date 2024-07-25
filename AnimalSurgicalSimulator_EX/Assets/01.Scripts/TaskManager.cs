using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;

    public DigComplete digComplete;
    [SerializeField] DigTask digTask;
    public enum TaskName
    {
        Start,
        Attach,
        Dig,
        Complete
    }

    public TaskName task = TaskName.Start; // ���� �۾� ����

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   


}
