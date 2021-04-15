using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D playerrb;
    Animator animator;
    bool isalive;
    [SerializeField] float runspeed = 5f;
    [SerializeField] float jumpspeed = 10f;
    [SerializeField] float climpspeed = 5f;
    [SerializeField] Vector2 deathkick = new Vector2(30f,30f);
    BoxCollider2D boxCollider2D;
    CapsuleCollider2D capsuleCollider2D;
    gamesession gamesession;
    // Start is called before the first frame update
    void Start()
    {
        gamesession = Object.FindObjectOfType<gamesession>();
        isalive = true;
        playerrb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
         capsuleCollider2D= GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isalive)
        {
            run();
            flipsprite();
            jump();
            climb();
            die();
        }
    }
    public void run()
    {
        float xMove = Input.GetAxis("Horizontal");
        Vector2 playervelocity = new Vector2(xMove * runspeed, playerrb.velocity.y);
        playerrb.velocity = playervelocity;
        bool ishorizontalmove = Mathf.Abs(playerrb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("running", ishorizontalmove);
    }
    public void flipsprite()
    {
        bool ishorizontalmove = Mathf.Abs(playerrb.velocity.x) > Mathf.Epsilon;
        if(ishorizontalmove)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerrb.velocity.x), 1f);
        }
    }
    public void die()
    {
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("hazard","enemylayer")))
        {
            isalive = false;
            animator.SetTrigger("dying");
            playerrb.velocity = deathkick;
            gamesession.processplayer();
        }
    }
    public void jump()
    {
       if(boxCollider2D.IsTouchingLayers(LayerMask.GetMask("foreground")))
        {
            if(Input.GetButtonDown("Jump"))
            {
                Vector2 jumpvelocity = new Vector2(0f, jumpspeed);
                playerrb.velocity += jumpvelocity;
            }
        }
    }
    public void climb()
    {
        if (boxCollider2D.IsTouchingLayers(LayerMask.GetMask("climbing")))
        {
            float ymove = Input.GetAxis("Vertical");
            Vector2 climbvelocity = new Vector2(playerrb.velocity.x, ymove*climpspeed);
            playerrb.velocity = climbvelocity;
            playerrb.gravityScale = 0f;
            bool isveticalmove = Mathf.Abs(playerrb.velocity.y) > Mathf.Epsilon;
            animator.SetBool("climbing", isveticalmove);
        }
        else
        {
            animator.SetBool("climbing", false);
            playerrb.gravityScale = 1f;
        }
    }

}
