using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDoorAction : MonoBehaviour
{
    public bool isOpen = false;
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (!isOpen)
        {
            ///this.transform.GetChild(0).localEulerAngles = new Vector3(0, -90, 0);
            isOpen = true;
           animator.SetBool("IsOpen", isOpen);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (isOpen)
        {
           /// this.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);
           
            isOpen = false;
            animator.SetBool("IsOpen", isOpen);
        }
    }
}
