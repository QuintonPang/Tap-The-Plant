using System.Collections;
// using System.Collections.Generic;
using UnityEngine.UI; // communicate with UI
using UnityEngine;

public class Game : MonoBehaviour
{

    public Text ui;
    public Text ui2;


    public void Increment(){
        GameManager.o2 += GameManager.multiplier;
        PlayerPrefs.SetInt("o2",GameManager.o2);
    }

    public void Buy(int num)
    {
        if(num==1 &&GameManager.o2>=25)
        {
            GameManager.multiplier +=1;
            GameManager.o2 -= 25;
            PlayerPrefs.SetInt("o2",GameManager.o2);
            PlayerPrefs.SetInt("multiplier",GameManager.multiplier);
        }
    }

    void Update()
    {
        ui.text  = "O2: " + GameManager.o2;
        ui2.text  = "Current O2 rate:  " + GameManager.multiplier+" / click";
    }
}
