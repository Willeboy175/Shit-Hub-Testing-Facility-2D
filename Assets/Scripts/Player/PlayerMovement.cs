using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float airSpeed = 2f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private float horz;
    private bool grounded;
    private bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }

    void FixedUpdate()
    {
        horz = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.Space))
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }

        if (grounded)
        {
            if (jumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (Mathf.Abs(horz) > 0.2f)
            {
                rb.velocity = new Vector2(horz * speed, rb.velocity.y);
            }
        }
        else
        {
            if (Mathf.Abs(horz) > 0.2f)
            {
                rb.velocity = new Vector2(horz * airSpeed, rb.velocity.y);
            }
        }

        grounded = false;
    }
}
