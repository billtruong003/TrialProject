using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuuChar : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float jumpForce;
    private bool move = false;
    private HuuAnimationController _anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<HuuAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        Hmove();
        VMove();
    }
    private void Hmove()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            // Nhân vật đi sang phải
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (move != true)
                move = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            // Nhân vật đi sang trái
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (move != true)
                move = true;
        }
        else
        {
            // Nhân vật đứng yên không di chuyển
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (move != false)
                move = false;
        }
        _anim.animController(move);
    }
    private void VMove()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
