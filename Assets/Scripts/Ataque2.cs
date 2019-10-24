using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque2 : MonoBehaviour
{
    public PlayerMovement plm;
    public int DmgP2;
    private bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }
    void Ataque()
    {
        if (Input.GetButtonDown("AtaqueP2"))
        {
            //canAtq = false;

            plm.GetComponent<Animator>().SetTrigger("AtaqueP2");
            attacking = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (attacking && other.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            attacking = false;
            Player1Dmg player1 = other.GetComponent<Player1Dmg>();
            if (player1 != null)
            {
                player1.TookDmg(DmgP2);
            }

        }
    }
    void AttackOff()
    {
        attacking = false;
    }
}
