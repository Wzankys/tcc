using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider hpUI;
    public Slider hpUI2;
    public Image playerImg, playerImg2;

    private Player1Dmg pDmg;
    private Player2Dmg pDmg2;

    // Start is called before the first frame update
    void Start()
    {
        pDmg = FindObjectOfType<Player1Dmg>();
        pDmg2 = FindObjectOfType<Player2Dmg>();

        hpUI.maxValue = pDmg.MaxHP;
        hpUI.value = hpUI.maxValue;

        hpUI2.maxValue = pDmg2.MaxHP;
        hpUI2.value = hpUI2.maxValue;
    }

    public void UpdateHP1(int qntd)
    {
        hpUI.value = qntd;
    }
    public void UpdateHP2(int qntd)
    {
        hpUI2.value = qntd;
    }
}
