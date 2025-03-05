using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text Lifepercent;

    public int characterIndexes;
    private PlayerManager playerManager;


    // Start is called before the first frame update
    void Start()
    {
        PlayerManager[] managers = FindObjectsOfType<PlayerManager>();
        foreach (PlayerManager pm in managers)
        {
            if (pm.playerIndex ==characterIndexes)
            {
                this.playerManager = pm;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

       Lifepercent.text=playerManager.GetCharacter().GetHealth().ToString();

    }
}


