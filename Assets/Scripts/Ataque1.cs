using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque1 : MonoBehaviour
{
    public PlayerMovement plm;
    private int DmgP1 = 0;
    private bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        Ataque();
        if(plm.isDead2)
        {
            plm.GetComponent<Animator>().SetTrigger("VitP1");
        }
    }
    void Ataque()
    { 
        if (Input.GetButtonDown("AtaqueP1"))
        {
            DmgP1 = 5;
            //canAtq = false;

          plm.GetComponent<Animator>().SetTrigger("AtaqueP1");
            attacking = true;
        }
        if (Input.GetButtonDown("AtaqueP1.1"))
        {
            //canAtq = false;
            DmgP1 = 8;
            plm.GetComponent<Animator>().SetTrigger("AtaqueP1Combo2");
            attacking = true;
        }
        if (Input.GetButtonDown("AtaqueP1.2"))
        {
            //canAtq = false;
            DmgP1 = 12;
            plm.GetComponent<Animator>().SetTrigger("AtaqueP1Combo3");
            attacking = true;
        }
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (attacking && other.gameObject.layer == LayerMask.NameToLayer("Player2"))
        {
            attacking = false;
            Player2Dmg player2 = other.GetComponent<Player2Dmg>();
            if(player2 !=null)
            {
                player2.TookDmg(DmgP1);
            }

        }
    }
    void AttackOff()
    {
        attacking = false;
    }
}
