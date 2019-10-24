using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //declaracao dos controladores

    public CharacterController2D controller;
    public Animator animator;

    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //declaração de numero do player 

    public int playerNumber;
    public bool isDead1 = false;
    public bool isDead2 = false;
    public bool vitP1 = false;


    /*--------------------------------------------------------------------------------------------------------------------------------*/
    //declaracao de variaveis do RB do personagem para movimentacao

    public float dashDist = 0;
    private int dire;

    Rigidbody2D rb;
    bool canAtq = true;
    public float runSpeed = 40f;
    float rSpeed = 0f;
    bool jump = false;
    int contSeta = 0;
    float timeDash = 0.3f;
    float horizontalMove = 0f;
    Vector3 sideDash;

    /*--------------------------------------------------------------------------------------------------------------------------------*/

    //inicializacao
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rSpeed = runSpeed;
    }

    /*--------------------------------------------------------------------------------------------------------------------------------*/

    /* Horizontal1
    Hotizontal2
    private string HorizontalButtonName;
    HorizontalButtonName = "Horizontal" + playerNumber;
    if (Input.GetAxisRaw(HorizontalButtonName)) */

    void Update()
    {
        if (!isDead1 && !isDead2)
        {
            /*----------------------------------------------------------------------------------------------------------------------------*/
            //pega o eixo pro player 1 ou 2
            if (playerNumber == 1)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            }

            if (playerNumber == 2)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal2") * runSpeed;
                animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            }
            /*------------------------------------------------------------------------------------------------------------------------------*/

            //pega o pulo pro player 1 ou 2

            if (playerNumber == 1)
            {
                if (Input.GetButtonDown("Jump1"))
                {
                    jump = true;
                    animator.SetBool("isJumping", true);

                    if (Input.GetButtonDown("AtaqueP1"))
                    {
                        animator.SetTrigger("AtaqueP1");
                    }
                }

            }

            if (playerNumber == 2)
            {
                if (Input.GetButtonDown("Jump2"))
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
                if (Input.GetKeyDown(KeyCode.D))
                {
                    dire = 2;
                    if (contSeta >= 2 && timeDash > 0 && dire == 2)
                    {
                        rb.AddForce(transform.TransformDirection(Vector2.right) * dashDist, ForceMode2D.Impulse);
                        animator.SetBool("isDash", true);
                        contSeta = 0;
                    }
                    else
                    {
                        timeDash = 0.3f;
                        contSeta++;
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    dire = 1;
                    if (contSeta >= 2 && timeDash > 0 && dire == 1)
                    {
                        rb.velocity = Vector2.left * dashDist;
                        animator.SetBool("isDash", true);
                        contSeta = 0;
                    }
                    else
                    {
                        timeDash = 0.3f;
                        contSeta++;
                    }
                }
                if (timeDash > 0)
                {
                    timeDash -= 0.9f * Time.deltaTime;
                }
                else
                {
                    timeDash = 0;
                }
            }

            //player 2

            if (playerNumber == 2)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    dire = 2;
                    if (contSeta >= 2 && timeDash > 0 && dire == 2)
                    {
                        rb.AddForce(transform.TransformDirection(Vector2.right) * dashDist, ForceMode2D.Impulse);
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
                    if (contSeta >= 2 && timeDash > 0 && dire == 1)
                    {
                        rb.velocity = Vector2.left * dashDist;
                        animator.SetBool("isDash", true);
                        contSeta = 0;
                    }
                    else
                    {
                        timeDash = 0.3f;
                        contSeta++;
                    }
                }
                if (timeDash > 0)
                {
                    timeDash -= 0.9f * Time.deltaTime;
                }
                else
                {
                    timeDash = 0;
                }

            }
        }

    }
    /*------------------------------------------------------------------------------------------------------------------------------*/



    void FixedUpdate()
    {
        if (!isDead1 && !isDead2)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
        }
        else
        {
            runSpeed = 0;
        }
      
    }
    /*--------------------------------------------------------------------------------------------------------------------------------*/
    //Declaração de funções do personagem
    //Função Dash

    void Dash()
    {
        animator.SetBool("isDash", false);
    }

    /*--------------------------------------------------------------------------------------------------------------------------------*/


    /*-------------------------------------------------------------------------------------------------------------------------------*/
    void ZerarSpeed()
    {
        runSpeed = 0;
    }
    void ResetSpeed()
    {
        runSpeed = rSpeed;
    }

}