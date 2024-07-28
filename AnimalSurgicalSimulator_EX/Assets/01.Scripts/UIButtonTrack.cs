using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonTrack : MonoBehaviour
{
    Transform mainCamera; // �÷��̾��� Transform
    float minZ = 0.72f; // �ּ� Z ��
    float maxZ = 1.5f;  // �ִ� Z ��

    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    void Update()
    {
        if (mainCamera != null)
        {
            // �÷��̾��� ��ġ�� �������� ��ư�� ���ο� ��ġ�� ����
            Vector3 newPosition = mainCamera.position ;

            // Z ��ġ�� minZ�� maxZ ���̷� ����
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            // ���ο� ��ġ ����: X�� Y�� �÷��̾��� ��ġ�� �״�� �����ϰ�, Z�� clampedZ�� ����
            transform.position = new Vector3(transform.position.x, transform.position.y, newPosition.z);
        }
    }
}


