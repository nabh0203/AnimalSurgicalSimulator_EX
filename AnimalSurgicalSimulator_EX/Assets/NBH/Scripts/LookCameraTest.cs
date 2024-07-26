using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCameraTest : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform target; // �ٶ� ������Ʈ
    [SerializeField] float lookThreshold; // �ٶ󺸴� ���� ��� ����

    void Update()
    {
        
        // ī�޶��� ��ġ�� �ٶ󺸴� ����
        //Vector3 directionToTarget = target.position - mainCamera.transform.position;
        float angle = Vector3.Angle(mainCamera.transform.forward, target.position);

        // ������ ��� ���� ���� ���� ��� ����� �޽��� ���
        if (angle < lookThreshold)
        {
            Debug.Log("����ڰ� ������Ʈ�� �ٶ󺸰� �ֽ��ϴ�!");
        }
        else
        {
            // ������ ����� �޽����� ���
            Debug.Log($"������Ʈ�� ī�޶��� ���� ������ ������ϴ�. ���� ����: {angle}��, ���� ����: {lookThreshold}��");
        }
    }
}
