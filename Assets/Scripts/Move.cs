using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform groundCheck;
    private Animator anim;
    public bool isGrounded;
    public float jumpForce;
    public float speed;
    Rigidbody2D rb;

    public string player = "P1";

    private string horizontalInput = "Horizontal_";
    private string verticalInput = "Vertical_";
    private string jumpInput = "Jump_";

    private AudioSource thisAudio;

    public GameObject HUD;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        horizontalInput += player;
        verticalInput += player;
        jumpInput += player;

        thisAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown(jumpInput) && isGrounded)
        {
            HUD.SetActive(false);

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            thisAudio.Play();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        float x = Input.GetAxis(horizontalInput);

        if (x < 0)
        {
            this.transform.localScale = new Vector2(1.0f, 1.0f);
            anim.SetBool("IsWalking", true);
        }
        else if (x > 0)
        {
            this.transform.localScale = new Vector2(-1.0f, 1.0f);
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = move;
    }
}
