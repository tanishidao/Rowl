using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void Start()
    {
        var CapsuleCollider = this.transform.parent.gameObject.AddComponent<CapsuleCollider>();
        CapsuleCollider.radius = 1.5f;
        CapsuleCollider.height = 1f;
        CapsuleCollider.isTrigger = true;
        
        var dooraction = CapsuleCollider.gameObject.AddComponent<SetDoorAction>();
        var Animator = GetComponent<Animator>();
        dooraction.animator = Animator;
    }
}
