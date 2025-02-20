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
    private Character character; 


    // Start is called before the first frame update
    void Start()
    {
        PlayerManager[] managers = FindObjectsOfType<PlayerManager>();
        foreach (PlayerManager pm in managers)
        {
            if (pm.playerIndex == GetComponent<CharacterReference>().playerIndex)
            {
                this.playerManager = pm;
                break;
            }
        }
        character = playerManager.GetCharacter();
    }

    // Update is called once per frame
    void Update()
    {

       

    }
}


