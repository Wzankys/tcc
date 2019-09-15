using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*--------------------------------------------------------------------------------------------------------------------------------*/
    
    //declaracao dos controladores
    
    public CharacterController2D controller;
    public Animator animator;
 
    /*--------------------------------------------------------------------------------------------------------------------------------*/
    
    //declaração de numero do player 

    public int playerNumber;


    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //declaracao de variaveis do RB do personagem para movimentacao

    public float dashDist = 0;

    private int dire;

    Rigidbody2D rb;
    public float runSpeed = 40f;
    bool jump = false;
    bool ground = true;
    int contSeta = 0;
    float timeDash = 0.3f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    Vector3 sideDash;
    
    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //inicializacao
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //update
    
    void Update()
    {
        /*----------------------------------------------------------------------------------------------------------------------------*/
        //pega o eixo pro player 1 ou 2
        if (playerNumber == 1)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        if (playerNumber == 2)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal2")*runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        /*------------------------------------------------------------------------------------------------------------------------------*/
        
        //pega o pulo pro player 1 ou 2

        /*if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }*/
        
        if (playerNumber == 1)
        {
            if(Input.GetButtonDown("Jump1"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        if (playerNumber == 2)
        {
            if(Input.GetButtonDown("Jump2"))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
            
        }

       
        /*------------------------------------------------------------------------------------------------------------------------------*/

        //pega o dash pro player 1 ou 2
        //player 1
        if (playerNumber == 1)
        {
            
        }

        if (playerNumber == 2)
        {
            
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
        
        //player 2
   
    }
    /*------------------------------------------------------------------------------------------------------------------------------*/

    
    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }
    /*--------------------------------------------------------------------------------------------------------------------------------*/
    //Declaração de funções do personagem
    //Função Dash
    
    void Dash()
    {
        animator.SetBool("isDash", false);
    }
    
    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //area de checagem de colisoes
    //collision
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
    //triggers
    void OnTriggerEnter(Collider other)
    {

    }

    /*-------------------------------------------------------------------------------------------------------------------------------*/


}