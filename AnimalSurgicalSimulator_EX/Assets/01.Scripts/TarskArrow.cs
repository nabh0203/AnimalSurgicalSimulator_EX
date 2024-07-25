using System.Collections.Generic;
using UnityEngine;

public class TaskArrow : MonoBehaviour
{
    [SerializeField]List<Transform> targetPositions; // ��ǥ ��ġ ����Ʈ
    int currentIndex;
    void Update()
    {
        if (currentIndex < targetPositions.Count)
        {
            // ���� ��ǥ ��ġ�� �̵�
            Transform targetPosition = targetPositions[currentIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, Time.deltaTime); // �ӵ� ����

            // z ȸ�� ���� (����ġ���� ����Ͽ� �� �ε����� ���� ȸ�� ����)
            switch (currentIndex)
            {
                case 0:
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90f);
                    break;
                case 1:
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -180f);
                    break;
                // �ʿ信 ���� �߰����� case�� �߰�
                default:
                    break;
            }

            // ��ǥ ��ġ�� �����ϸ� ���� ��ǥ�� ����
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
            {
                currentIndex++;
            }
        }
    }
}
