using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabGuideControll : MonoBehaviour
{
    [SerializeField] GameObject guideMesh;

    public enum GripObject
    {
        Mes,
        Clamp,
        Dig
    }

    public GripObject gripObjectName;

    void Update()
    {
        // ���� ���� �½�ũ�� ���Ͽ� ���̵带 Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        if (TaskManager.instance.task == TaskManager.TaskName.Start && TaskManager.instance.currentMainTask == (TaskManager.MainTask)gripObjectName)
        {
            guideMesh.SetActive(true);
        }
        else
        {
            guideMesh.SetActive(false);
        }
    }
}
