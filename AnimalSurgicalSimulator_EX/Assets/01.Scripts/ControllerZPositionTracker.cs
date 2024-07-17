using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerZPositionTracker : MonoBehaviour
{
    public GameObject controller;

    private Vector3 previousControllerPosition;
    public float zPositionDelta;

    private void Start()
    {
        // �ʱ� ��Ʈ�ѷ� ��ġ ����
        previousControllerPosition = controller.transform.position;
    }

    private void Update()
    {
        // ��Ʈ�ѷ� ���� ��ġ ��������
        Vector3 currentControllerPosition = controller.transform.position;

        // z�� �Ÿ� ��ȭ ���
        zPositionDelta = currentControllerPosition.z - previousControllerPosition.z;

        // ���� ������ ��ġ ������Ʈ
        previousControllerPosition = currentControllerPosition;

        // z�� �Ÿ� ��ȭ ����Ͽ� �ʿ��� ���� ����
        HandleZPositionChange();
    }

    private void HandleZPositionChange()
    {
        // z�� �Ÿ� ��ȭ�� ���� ���� ����
        if(zPositionDelta >=-0.0001f && zPositionDelta <= 0.0001f)
        {
            zPositionDelta = 0;
        }
        else if (zPositionDelta > 0)
        {
            // ��Ʈ�ѷ��� �������� �̵��� ���
            zPositionDelta = 1;
        }
        else if (zPositionDelta < 0)
        {
            // ��Ʈ�ѷ��� �Ĺ����� �̵��� ���
            zPositionDelta = -1;
        }
    }
}
