using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesComplete : MonoBehaviour
{
    [SerializeField] GameObject taskObject;

    //Animator anim;

    private void Start()
    {
        //anim = taskObject.GetComponent<Animator>();
    }
    public void TaskComplete()
    {
        taskObject.SetActive(false);
        //�ִϸ��̼� ����
        //anim.SetBool("incision", true);
    }
}
