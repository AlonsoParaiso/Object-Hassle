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
                character = new ReyBomba("a", 10, 0);
                break;
            case 1:
                character = new Mechero("b", 8, 0);
                break;
            default:
                break;
        }

        character.SetCharacterIndex(playerIndex);
        Instantiate(character.GetGameObject(), new Vector3(-6.23999977f, 2.32999992f, -2.50999999f), Quaternion.identity);
    }

    // Start is called before the first frame update
    public Character GetCharacter()
    {
        return character;
    }
}
