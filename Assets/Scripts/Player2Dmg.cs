using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Dmg : MonoBehaviour
{
    public PlayerMovement plm;
    public int MaxHP = 100;
    private int CurrentHP;

    private void Awake()
    {

        CurrentHP = MaxHP;
        
    }

    public void TookDmg(int dmg)
    {
        if (plm.isDead2 == false)
        {
            CurrentHP -= dmg;
            plm.GetComponent<Animator>().SetTrigger("LevarDano");
            FindObjectOfType<UIManager>().UpdateHP2(CurrentHP);

            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
                plm.isDead2 = true;
                plm.GetComponent<Animator>().SetTrigger("MorteP2"); 

            }
        }
    }
}
