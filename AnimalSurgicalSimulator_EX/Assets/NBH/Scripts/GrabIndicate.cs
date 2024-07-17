using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabIndicate : MonoBehaviour
{
    //�帱 �������
    public UnityEvent OnGrab; 
    //�帱 ��������
    public UnityEvent OnRelease;

    public void Grab(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;
        if (interactor is XRDirectInteractor)
        {
            Debug.Log("����");
            OnGrab?.Invoke();
        }
    }

    public void Release(SelectExitEventArgs args)
    {
        var interactor = args.interactorObject;
        if (interactor is XRDirectInteractor)
        {
            Debug.Log("����");
            OnRelease?.Invoke();
        }
    }
}
