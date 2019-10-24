using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Dmg : MonoBehaviour
{
    public PlayerMovement plm;
    public int MaxHP = 100;
    private int currentHP;
    private string[] lDano = new string[] { "LevarDano", "LevarDano2", "LevarDano3", "LevarDano4" };
    int i = 0;

    private void Awake()
    {
        currentHP = MaxHP;
    }


    public void TookDmg(int dmg)
    {
        if (!plm.isDead1)
        {
            currentHP -= dmg;
            plm.GetComponent<Animator>().SetTrigger(lDano[i]);
            FindObjectOfType<UIManager>().UpdateHP1(currentHP);
            i++;
            if(i > 3)
            {
                i = 0;
            }
            if (currentHP <= 0)
            {
                Debug.Log("Entrou");
                plm.isDead1 = true;
                currentHP = 0;
                plm.GetComponent<Animator>().SetBool("MorteP1", true);
                
            }
        }
    }
}
