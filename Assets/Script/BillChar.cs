using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillChar : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform footPos;
    [SerializeField] private Vector2 sizeBox = new Vector2(0.4f, 0.2f);
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private bool groundCheck = false;
    private bool moveStatus;
    private Rigidbody2D rb;
    private BillAnimationController animController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animController = GetComponent<BillAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundCheck = Physics2D.BoxCast(new Vector2(footPos.position.x, footPos.position.y), sizeBox, 0, Vector2.zero, 0, GroundLayer.value);
        HMove();
        VMove();
    }
    private void HMove()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
            if (moveStatus != true)
                moveStatus = true;

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
            if (moveStatus != true)
                moveStatus = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (moveStatus != false)
                moveStatus = false;
        }
        animController.AnimationControll(moveStatus);
    }
    public void VMove()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && groundCheck == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
