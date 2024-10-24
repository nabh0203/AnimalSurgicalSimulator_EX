using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectBlinker : MonoBehaviour
{
    ////[SerializeField] XRBaseInteractor socketInteractor; // 소켓 인터렉터 참조
    //[SerializeField] CustomSocket socket;
    ////[SerializeField] CustomSocketNBH socket;
    //[SerializeField] float blinkInterval = 0.5f; // 깜빡이는 간격
    //[SerializeField] List<XRGrabInteractable> grabInteractors; // XRGrabInteractable 리스트
    ////[SerializeField] List<GameObject> objectsToBlink; // 깜빡이게 할 오브젝트 리스트
    //[SerializeField] GameObject objectsToBlink; // 깜빡이게 할 오브젝트 리스트
    //[SerializeField] HandModelControll handModelControll; // HandModelControll 인스턴스 참조
    //[SerializeField] DrillTaskHandModelControll drillHandModelController;
    //[SerializeField] MesTaskHandModelControll mesHandModelController;
    //[SerializeField] ClampTaskHandModelControll calmpHandModelController;

    //bool isObjectInSocket = false;
    //bool isGrabbed = false;
    //int grabbedIndex = -1;

    //public enum BlinkName
    //{
    //    Mes,
    //    Clamp,
    //    Dig
    //}

    //public BlinkName blinkName;


    //void Start()
    //{
    //    for (int i = 0; i < grabInteractors.Count; i++)
    //    {
    //        int index = i; // 캡처된 인덱스
    //        grabInteractors[i].selectEntered.AddListener((args) => OnGrabbed(index));
    //        grabInteractors[i].selectExited.AddListener((args) => OnReleased(index));
    //    }

    //    handModelControll.IsTaskCompleted += OnTaskCompleted;
    //    // HandModelControll의 TaskCompleted 이벤트 구독
    //    if (blinkName == BlinkName.Mes)
    //    {
    //        mesHandModelController.IsTaskCompleted += OnTaskCompleted;
    //    }
    //    else if (blinkName == BlinkName.Clamp)
    //    {
    //        calmpHandModelController.IsTaskCompleted += OnTaskCompleted;
    //    }
    //    else if (blinkName == BlinkName.Dig)
    //    {
    //        drillHandModelController.IsTaskCompleted += OnTaskCompleted;
    //    }
    //}

    //void Update()
    //{
    //    if (!isGrabbed)
    //    {
    //        objectsToBlink.SetActive(false);
    //        //if (grabbedIndex >= 0 && grabbedIndex < objectsToBlink.Count)
    //        //{
    //        //    objectsToBlink[grabbedIndex].SetActive(false);
    //        //}
    //        return;
    //    }
    //}
    //private IEnumerator BlinkObject(int index)
    //{
    //    while (!isObjectInSocket)
    //    {
    //        //objectsToBlink[index].SetActive(!objectsToBlink[index].activeSelf);
    //        objectsToBlink.SetActive(!objectsToBlink.activeSelf);
    //        yield return new WaitForSeconds(blinkInterval);
    //        isObjectInSocket = socket.hasSelection;
    //    }

    //    // 오브젝트가 소켓에 들어가면 깜빡이기 멈춤
    //    //objectsToBlink[index].SetActive(false);
    //    objectsToBlink.SetActive(false);
    //    TaskManager.instance.isNextTask = true;
    //}

    //private void OnGrabbed(int index)
    //{
    //    isGrabbed = true;
    //    grabbedIndex = index;
    //}

    //private void OnReleased(int index)
    //{
    //    isGrabbed = false;
    //    grabbedIndex = -1;
    //}

    //// TaskCompleted 이벤트가 발생할 때 실행할 메서드
    //private void OnTaskCompleted(bool taskComplete)
    //{
    //    if (taskComplete)
    //    {
    //        StartCoroutine(BlinkObject(grabbedIndex));
    //        // 여기에서 필요한 작업을 수행합니다.
    //        //if (grabbedIndex >= 0 && grabbedIndex < objectsToBlink.Count)
    //        //{
    //        //    StartCoroutine(BlinkObject(grabbedIndex));
    //        //}
    //    }
    //}

    [SerializeField] CustomSocket socket;
    [SerializeField] float blinkInterval = 0.5f; // 깜빡이는 간격
    [SerializeField] XRGrabInteractable grabInteractors; // XRGrabInteractable 리스트
    [SerializeField] GameObject objectsToBlink; // 깜빡이게 할 오브젝트 리스트
    [SerializeField] HandModelControll handModelControll; // HandModelControll 인스턴스 참조
    [SerializeField] DrillTaskHandModelControll drillHandModelController;
    [SerializeField] MesTaskHandModelControll mesHandModelController;
    [SerializeField] ClampTaskHandModelControll calmpHandModelController;

    bool isObjectInSocket = false;
    bool isGrabbed = false;

    public enum BlinkName
    {
        Mes,
        Clamp,
        Dig
    }

    public BlinkName blinkName;


    void Start()
    {

        grabInteractors.selectEntered.AddListener((args) => OnGrabbed());
        grabInteractors.selectExited.AddListener((args) => OnReleased());
        
        handModelControll.IsTaskCompleted += OnTaskCompleted;

        if (blinkName == BlinkName.Mes)
        {
            mesHandModelController.IsTaskCompleted += OnTaskCompleted;
        }
        else if (blinkName == BlinkName.Clamp)
        {
            calmpHandModelController.IsTaskCompleted += OnTaskCompleted;
        }
        else if (blinkName == BlinkName.Dig)
        {
            drillHandModelController.IsTaskCompleted += OnTaskCompleted;
        }
    }

    private IEnumerator BlinkObject()
    {
        while (!isObjectInSocket)
        {
            objectsToBlink.SetActive(!objectsToBlink.activeSelf);
            yield return new WaitForSeconds(blinkInterval);
            isObjectInSocket = socket.hasSelection;
        }
        objectsToBlink.SetActive(false);
    }

    private void OnGrabbed()
    {
        isGrabbed = true;
    }

    private void OnReleased()
    {
        isGrabbed = false;
        if (!isGrabbed)
        {
            //isObjectInSocket = true;
            objectsToBlink.SetActive(false);
            return;
        }
    }
    private void OnTaskCompleted(bool taskComplete)
    {
        if (taskComplete)
        {
            StartCoroutine(BlinkObject());
        }
    }
}
