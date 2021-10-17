using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    //References to other objects & scripts
    [SerializeField] TextMeshProUGUI StarCounts;
    [SerializeField] GameObject heroKnight;
    HeroKnight myhero;

    //Script Variables
    public int StarsWin = 7;
    bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        myhero = heroKnight.GetComponent<HeroKnight>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!win)
        {
            myhero.M_Stars++;
            StarCounts.text = myhero.M_Stars.ToString();
            
            if (myhero.M_Stars == StarsWin)
            {            
                Debug.Log("Win");
                win = true;
            }
        }
        
    }
}
