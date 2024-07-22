using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;

public class HapticsTest : MonoBehaviour
{
    [SerializeField][Range(0.0f, 1.0f)] float intensity = 1.0f;
    [SerializeField][Range(0.0f, 1.0f)] float duration = 1.0f;
    [SerializeField][Range(0.0f, 360.0f)] float angleX = 0.0f;
    [SerializeField][Range(-0.5f, 0.5f)] float offsetY = 0.0f;
    private void OnTriggerEnter(Collider other)
    {
        Baisc();
        //CustomBasic();
        //CustomRange();
    }

    private void Baisc()
    {
        // Bhaptics Portal ������ ������ ��ƽ�� �����ų�� ����ϴ� ��ɾ�
        // BhapticsLibrary.Play(BhapticsEvent.EventID); �Ʒ� ��ɾ� ó�� ���ÿ��� EventID �� �׻� �빮��
        BhapticsLibrary.Play(BhapticsEvent.EXAMPLE);
        // BhapticsLibrary.Play("eventID"); �Ʒ� ��ɾ� ó�� ���ÿ��� EventID �� BHaptics ���� ���� EventID ��Ȯ�ϰ� �Է�
        BhapticsLibrary.Play("example");

    }

    private void CustomBasic()
    {
        //Bhaptics Portal ������ ������ ��ƽ�� �ɼ��� �� �����Ͽ� ����ϴ� ��ɾ�
        BhapticsLibrary.PlayParam(
            BhapticsEvent.EXAMPLE, // �����ų ��ƽ �̸� (BhapticsEvent.EventID) EventID�� �׻� ��ҹ��� 
            0.5f,   // ��ƽ ����
            0.5f,   // ��ƽ ���� �ð�
            360.0f,  // ��ƽ�� �ð� �������� ȸ��
            0.3f    // ��ƽ�� �� �Ʒ��� �̵�
        );
    }
    //���� Range �Ӽ��� ���� ��ƽ �̺�Ʈ ����
    private void CustomRange()
    {
        BhapticsLibrary.PlayParam(
            BhapticsEvent.EXAMPLE,
            intensity,
            duration,
            angleX,
            offsetY
        );
    }
}
