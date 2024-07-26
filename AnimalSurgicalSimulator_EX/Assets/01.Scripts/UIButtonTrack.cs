using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonTrack : MonoBehaviour
{
    [SerializeField] Transform player; // �÷��̾��� Transform
    float minZ = 0.72f; // �ּ� Z ��
    float maxZ = 1.5f;  // �ִ� Z ��

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("�÷��̾ �������ּ���.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // �÷��̾��� ��ġ�� �������� ��ư�� ���ο� ��ġ�� ����
            Vector3 newPosition = player.position ;

            // Z ��ġ�� minZ�� maxZ ���̷� ����
            newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

            // ���ο� ��ġ ����: X�� Y�� �÷��̾��� ��ġ�� �״�� �����ϰ�, Z�� clampedZ�� ����
            transform.position = new Vector3(transform.position.x, transform.position.y, newPosition.z);
        }
    }
}


