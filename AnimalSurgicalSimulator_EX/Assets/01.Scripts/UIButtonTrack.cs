using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonTrack : MonoBehaviour
{
    Camera mainCamera;
    float minZ = 0.72f; // �ּ� Z ��
    float maxZ = 1.5f;  // �ִ� Z ��

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // ī�޶��� ��ġ�� ���⿡ ���� ���ο� Z ��ġ ���
        Vector3 deltaPosition = mainCamera.transform.position + (mainCamera.transform.forward * 1.0f); // 1.0f�� ���ϴ� �Ÿ�

        // Z ��ġ�� minZ�� maxZ ���̷� ����
        float clampedZ = Mathf.Clamp(deltaPosition.z, minZ, maxZ);

        // ���ο� ��ġ ����: X�� Y�� �״�� �����ϰ�, Z�� clampedZ�� ����
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
    }
}
