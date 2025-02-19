using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text Lifepercent;
    public GameManager.GameManagerVariables variable;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.GetLifes();
        Lifepercent.text = "Lifes: " + GameManager.instance.GetLifes();
        

    }
}


