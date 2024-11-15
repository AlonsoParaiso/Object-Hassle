using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerManager : MonoBehaviour
{
    private Character character;
    public uint playerIndex = 0;
    private void Awake()
    {
        switch (GameManager.instance.characterIndexes[playerIndex])
        {
            case 0:
                character = new ReyBomba("a", 10, -2);
                break;
            case 1:
                character = new Mechero("b", 10, -2);
                break;
            default:
                break;
        }

       

        Instantiate(character.GetGameObject(), new Vector3(-6.23999977f, 2.32999992f, -2.50999999f), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Character GetCharacter()
    {
        return character;
    }
}
