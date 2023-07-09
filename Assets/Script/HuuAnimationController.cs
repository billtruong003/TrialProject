using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuuAnimationController : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void animController(bool status)
    {
        _anim.SetBool("move", status);
    }
}
