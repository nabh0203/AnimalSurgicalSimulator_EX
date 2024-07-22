using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;
using UnityEngine.XR.OpenXR.Features.Interactions;

public class HapticsTest : MonoBehaviour
{

    public static HapticsTest instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void CustomBasic(float amplitude, float duration)
    {
        //Bhaptics Portal ������ ������ ��ƽ�� �ɼ��� �� �����Ͽ� ����ϴ� ��ɾ�
        BhapticsLibrary.PlayParam(
            BhapticsEvent.EXAMPLE, // �����ų ��ƽ �̸� (BhapticsEvent.EventID) EventID�� �׻� ��ҹ��� 
            amplitude,   // ��ƽ ����
            duration    // ��ƽ ���� �ð�
        );
    }
}
