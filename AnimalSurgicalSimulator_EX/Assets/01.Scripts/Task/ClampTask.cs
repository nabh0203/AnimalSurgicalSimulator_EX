using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static TaskManager;

public class ClampTask : MonoBehaviour
{
    [SerializeField] HandModelControll handModel;
    [SerializeField] HandTrackingModelControll hand;
    [SerializeField] XRGrabInteractable grab;
    [SerializeField] TextMeshProUGUI uiText;
    [SerializeField] TextMeshProUGUI subUiText;
    [SerializeField] List<Transform> targets; // 타겟 오브젝트 리스트

    public delegate void TaskStateChanged(TaskName task);
    public event TaskStateChanged OnTaskStateChanged;

    // Start is called before the first frame update
    void Start()
    {
        OnTaskStateChanged += UpdateUIText;
        OnTaskStateChanged += UpdateTargets; // 타겟 업데이트를 위한 이벤트 추가

        // 초기 타겟 설정
        UpdateTargets(TaskManager.instance.task);
        // 초기 UI 텍스트 업데이트
        UpdateUIText(TaskManager.instance.task);
    }


    public void Update()
    {
        switch (TaskManager.instance.task)
        {
            case TaskName.Start:
                if (grab.isSelected)
                {
                    TaskStateChange(TaskName.Attach);
                }
                break;

            case TaskName.Attach:
                if (handModel.isAttach || hand.isAttach)
                {
                    TaskStateChange(TaskName.Process);
                }
                else if (!grab.isSelected)
                {
                    TaskStateChange(TaskName.Start);
                }
                break;

            case TaskName.Process:
                if (handModel.currentTaskComplete || hand.currentTaskComplete)
                {
                    TaskStateChange(TaskName.Complete);
                }
                else if ((handModel.isAttach == false && hand.isAttach == false))
                {
                    TaskStateChange(TaskName.Attach);
                }
                break;
            case TaskName.Complete:
                if (TaskManager.instance.isNextTask)
                {
                    TaskManager.instance.NextTask();
                    TaskManager.instance.GetCurrentTask().enabled = true;
                    this.enabled = false;
                }
                TaskManager.instance.isNextTask = false;
                break;
        }
    }

    private void TaskStateChange(TaskName taskName)
    {
        TaskManager.instance.task = taskName;
        OnTaskStateChanged?.Invoke(TaskManager.instance.task);
    }

    void UpdateUIText(TaskName taskName)
    {
        switch (taskName)
        {
            case TaskName.Start:
                uiText.text = "Grab the Clamp";
                subUiText.text = "* Follow the Mes guidelines on the right";
                break;
            case TaskName.Attach:
                uiText.text = "Attach the Clamp to the guidelines";
                subUiText.text = "* Hold the object and follow the guidelines";
                break;
            case TaskName.Process:
                uiText.text = "";
                subUiText.text = "* ";
                break;
            case TaskName.Complete:
                uiText.text = "Bring the Clamp back to its original position";
                subUiText.text = "* Take it to the stand. Put your hands down";
                break;
        }
    }

    void UpdateTargets(TaskName taskName)
    {
        List<Transform> newTargets = new List<Transform>();

        // TaskName에 따라 타겟 오브젝트를 변경
        switch (taskName)
        {
            case TaskName.Start:
                newTargets.Add(targets[0]);
                break;
            case TaskName.Attach:
                newTargets.Add(targets[1]);
                break;
            case TaskName.Process:
                newTargets.Add(targets[2]);
                break;
            case TaskName.Complete:
                newTargets.Add(targets[3]);
                break;

        }

        TaskArrow.Instance.SetTargets(newTargets); // 타겟 업데이트
    }
}
