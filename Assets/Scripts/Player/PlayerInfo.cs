using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfo : MonoBehaviour
{
    //Récuperer les infos du personnage

    public static PlayerInfo pi;

    public int nbCoins = 0;
    public TMP_Text coinTxt;
    public int nbPoulet = 0;
    public TMP_Text pouletTxt;

    private void Awake()
    {
        pi = this;
    }

    public void GetCoin()
    {
        nbCoins++;
        coinTxt.text = nbCoins.ToString() + "/14";
    }

    public void GetPoulet() 
    {
        nbPoulet++;
        pouletTxt.text = nbPoulet.ToString() + "/4";
    }
    
    void Update()
    {
        
    }
}
