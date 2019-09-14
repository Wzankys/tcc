using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float dashDist = 0;

    private int dire;

    Rigidbody2D rb;
    public float runSpeed = 40f;
    bool jump = false;
    bool ground = true;
    int contSeta = 0;
    float timeDash = 0.3f;
    float horizontalMove = 0f;
    Vector3 sideDash;


    // Start is called before the first frame update

    // Update is called once per frame
    /*void Dash(int lado)
    {
        
        if (contSeta >= 2 && timeDash >0 && lado ==1)
        {
            //Debug.Log(" Its Works my little friends");
            
            animator.SetBool("isDash", true);
            contSeta = 0;
        }
        else
        {
            timeDash = 0.5f;
            contSeta++;
        }
    }*/

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
       if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            dire = 2;
            if (contSeta >= 2 && timeDash > 0 && dire==2)
            {
                rb.AddForce( transform.TransformDirection(Vector2.right)*dashDist,ForceMode2D.Impulse);
                animator.SetBool("isDash", true);
                contSeta = 0;
            }
            else
            {
                timeDash = 0.3f;
                contSeta++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            dire = 1;
            if (contSeta >= 2 && timeDash > 0&&dire==1)
            {
                rb.velocity =  Vector2.left * dashDist;
                animator.SetBool("isDash", true);
                contSeta = 0;
            }
            else
            {
                timeDash = 0.3f;
                contSeta++;
            }
        }
        if (timeDash>0)
        {
            timeDash -= 0.9f* Time.deltaTime;
        }
        else
        {
            timeDash = 0;
        }
   
    }
   void OnColisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            ground = true;
        } else
        {
            ground = false;
        }
            
        if(ground)
        {
            animator.SetBool("isJumping", false);
        }
    }
    void Dash()
    {
        animator.SetBool("isDash", false);
    }

     void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }
}
