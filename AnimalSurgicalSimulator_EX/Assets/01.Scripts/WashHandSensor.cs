using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHandSensor : MonoBehaviour
{
    [SerializeField] Transform waterPosition;

    bool isTriggering = false;
    bool isRayOn = false;

    float triggerTime = 0f;
    float requiredTriggerTime = 1f; // Ʈ���Ÿ� �����ؾ� �ϴ� �ð� (1��)
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            Debug.Log("���� ����");
            isTriggering = true;
            triggerTime = 0f; // Ʈ���� ���� �� Ÿ�̸� �ʱ�ȭ
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (isTriggering)
        {
            triggerTime += Time.deltaTime; // Ʈ���� ���� �ð� ����

            if (triggerTime >= requiredTriggerTime)
            {
                if (!isRayOn)
                {
                    ShootRay();
                    isRayOn = true;
                }
                else
                {
                    StopRay();
                    isRayOn = false;
                }
                isTriggering = false; // Ʈ���� ���� �ʱ�ȭ
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject)
        {
            isTriggering = false;
            triggerTime = 0f; // Ʈ���� ���� �� Ÿ�̸� �ʱ�ȭ
        }
    }

    void ShootRay()
    {
        Ray ray = new Ray(waterPosition.position, waterPosition.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("���̿� ���� ������Ʈ: " + hit.collider.name);
            // �ʿ��� ��� �߰����� ������ ���⿡ �ۼ�
        }

        Debug.DrawRay(waterPosition.position, waterPosition.forward * 10, Color.red, 2f); // ����׿� ����
    }

    void StopRay()
    {
        // ���̸� ���� ������ ���⿡ �ۼ�
        Debug.Log("���� ����");
    }
}
