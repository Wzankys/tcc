using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspecialIchigo : MonoBehaviour
{
    public Animator animator;
    bool anim0 = false;
    bool anim1 = false;

    float timeAnim = 0.0f;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)&& Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Deu boa");
            carregarRea();
            anim0 = true;
        }
        if (anim0&&anim1)
        {
            timeAnim += Time.deltaTime;
            Debug.Log(timeAnim);
            if(timeAnim >3)
            {
                carregarRea2();
            }
        }
    }
    void carregarRea()
    {
        animator.SetBool("AtkEspecial", true);
    }
    void carregarRea1()
    {

        animator.SetBool("AtkEspecial", false);
        animator.SetBool("TrocaEP1", true);
        anim1 =true;    }
    void carregarRea2()
    {
        animator.SetBool("TrocaEP1", false);
        animator.SetBool("TrocaEP2", true);
    }
    void fimAnim()
    {
        animator.SetBool("AtkEspecial", false);
        animator.SetBool("TrocaEP2", false);
        timeAnim = 0;
        anim0 = false;
        anim1 = false;
    }
}
