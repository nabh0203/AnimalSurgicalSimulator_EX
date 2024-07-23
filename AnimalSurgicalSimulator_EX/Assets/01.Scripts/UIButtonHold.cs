using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;
    [SerializeField] GameObject surgicalBed;

    public enum ButtonName
    {
        BedUp,
        BedDown
    }

    [SerializeField] ButtonName buttonName;
    // Update �޼��忡�� ������ ����
    private void Update()
    {
        if (isHolding)
        {
            if (buttonName == ButtonName.BedUp)
            {
                BedUp();
            }
            else
            {
                BedDown();
            }
        }
    }

    // ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    // ��ư���� ���� ���� �� ȣ��Ǵ� �޼���
    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        Stop();
    }


    public void BedUp()
    {
        surgicalBed.transform.DOLocalMove(new Vector3(0, 0.1f, 0), 3).SetEase(Ease.Linear);
    }
    public void BedDown()
    {
        surgicalBed.transform.DOLocalMove(new Vector3(0, -0.1f, 0), 3).SetEase(Ease.Linear);
    }
    void Stop()
    {
        surgicalBed.transform.DOKill();
    }
}
