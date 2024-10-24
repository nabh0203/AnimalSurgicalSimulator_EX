using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands.Samples.VisualizerSample;
using UnityEngine.XR.Interaction.Toolkit;
using static TaskManager;

public class DrillTaskHandModelControll : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject handModel;
    [SerializeField] GameObject grabObject;

    [SerializeField] Transform indicatorAttach;
    [SerializeField] Transform drillAttach;

    [SerializeField] XRSocketInteractor socketInteractor;
    [SerializeField] XRGrabInteractable grabInteractor;
    [SerializeField] HandTrackingDrillTrigger drillTrigger;

    [SerializeField] HandVisualizer handVisualizer;

    float drillSpeed = 0.03f;
    public bool isAttach { get; private set; } = false;

    public bool currentTaskComplete { get; private set; } = false;

    public delegate void TaskCompleted(bool taskComplete);
    public event TaskCompleted IsTaskCompleted;

    private void Start()
    {
        IsTaskCompleted += TaskComplete;
    }
    private void Update()
    {
        float distance = Vector3.Distance(indicator.transform.position, gameObject.transform.position);

        if(TaskManager.instance.currentMainTask == MainTask.Dig)
        {
            if (!currentTaskComplete && !isAttach && grabInteractor.isSelected && distance <= 0.2f)
            {
                indicator.SetActive(false);
                Attach();
            }
            else if (isAttach && grabInteractor.isSelected && distance <= 0.2f)
            {
                Move();
            }
            else if (isAttach && !grabInteractor.isSelected && distance <= 0.2f)
            {
                indicator.SetActive(true);
                Detach();
            }
            else if (!currentTaskComplete && isAttach && distance > 0.2f)
            {
                indicator.SetActive(true);
                Detach();
            }
        }
    }
    private void Attach()
    {
        handVisualizer.drawMeshes = false;
        handModel.SetActive(true);

        socketInteractor.transform.SetParent(handModel.transform);
        socketInteractor.transform.position = drillAttach.transform.position;
        socketInteractor.transform.rotation= drillAttach.transform.rotation;

        grabObject.transform.SetParent(handModel.transform);

        isAttach = true;
    }

    private void Detach()
    {
        handVisualizer.drawMeshes = true;
        handModel.SetActive(false);

        socketInteractor.transform.SetParent(gameObject.transform);
        socketInteractor.transform.position = gameObject.transform.position;
        socketInteractor.transform.rotation = gameObject.transform.rotation;

        grabObject.transform.SetParent(null);
        grabObject.transform.position = socketInteractor.transform.position;

        isAttach = false;
    }

    void Move()
    {
        if (drillTrigger.buttonOn) //자동으로 움직이는 기능
        {
            if (drillTrigger.currentTriggerLayerName == "OutsideBone")
            {
                drillSpeed = 0.002f;
            }
            else if (drillTrigger.currentTriggerLayerName == "InsideBone")
            {
                drillSpeed = 0.004f;
            }
            else if (drillTrigger.currentTriggerLayerName == "EndLayer")
            {
                currentTaskComplete = true;
                IsTaskCompleted?.Invoke(currentTaskComplete);
                Detach();
            }

            handModel.transform.Translate(0, 0, drillSpeed * Time.deltaTime);
        }

    }

    void TaskComplete(bool taskComplete)
    {
        TaskManager.instance.digComplete.TaskComplete();
    }
}
