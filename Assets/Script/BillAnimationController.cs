using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillAnimationController : MonoBehaviour
{
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void AnimationControll(bool status)
    {
        _anim.SetBool("Move", status);
    }
}
