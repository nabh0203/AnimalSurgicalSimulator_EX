using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHandSensor : MonoBehaviour
{
    [SerializeField] GameObject handTrigger;
    [SerializeField] Transform waterPosition;
    [SerializeField] LineRenderer lineRenderer;

    int triggerCount = 0; // Ʈ���� Ƚ�� ī��Ʈ

    void Update()
    {
        if (triggerCount % 2 == 1) // Ʈ���Ű� Ȧ���� �� ���� �߻�
        {
            ShootRay();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == handTrigger)
        {
            // Ʈ���� Ƚ���� ������Ŵ
            triggerCount++;

            // Ȧ���� �� ���� �Ѱ�, ¦���� �� ���� ��
            if (triggerCount % 2 == 1)
            {
                StartRay(); // ���� �ѱ�
            }
            else
            {
                StopRay(); // ���� ����
            }
        }
    }

    private void StartRay()
    {
        lineRenderer.enabled = true; // LineRenderer Ȱ��ȭ
        Debug.Log("���� ��");
    }

    private void StopRay()
    {
        lineRenderer.enabled = false; // LineRenderer ��Ȱ��ȭ
        Debug.Log("���� ��");
    }

    void ShootRay()
    {
        Debug.Log("���� �߻�");
        Ray ray = new Ray(waterPosition.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("���̿� ���� ������Ʈ: " + hit.collider.name);
            lineRenderer.SetPosition(0, waterPosition.position);
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            Debug.Log("���̰� �ƹ��͵� ���� �ʾҽ��ϴ�.");
            Vector3 endPoint = waterPosition.position + Vector3.down.normalized * 1f;
            lineRenderer.SetPosition(0, waterPosition.position);
            lineRenderer.SetPosition(1, endPoint);
        }

        Debug.Log("���� ����: " + Vector3.down);
    }
}
