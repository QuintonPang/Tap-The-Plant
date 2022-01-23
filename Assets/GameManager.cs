using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int o2;
    public static int multiplier;

    // Start is called before the first frame update
    void Start()
    {
        // multiplier=1;
        // o2 = 0;

        // for saving
        // parameter is identifier and default value if not found
        multiplier = PlayerPrefs.GetInt("multiplier",1);
        o2 = PlayerPrefs.GetInt("o2",0);

        // method starting in 10s, repeats every 5s
        InvokeRepeating("ShowAds",10.0f,Random.Range(10.0f,20.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    
    }

    void ShowAds(){
        AdManager.instance.RequestInterstitial();
        AdManager.instance.ShowInterstitial();
    }

}
