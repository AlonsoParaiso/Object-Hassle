using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerManager : MonoBehaviour
{
    private Character character;
    public uint playerIndex = 0;
    private void Start()
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
        GameObject nPlayer = PlayerInput.Instantiate(character.GetGameObject(), pairWithDevice: Gamepad.all[(int)playerIndex]).gameObject;
        nPlayer.transform.Rotate(0,120,0);
        nPlayer.transform.rotation = Quaternion.identity;
        nPlayer.transform.position = new Vector3(-6.23999977f, 2.32999992f, -2.50999999f);
        nPlayer.AddComponent<CharacterReference>().character = character;
        nPlayer.GetComponent<CharacterReference>().playerIndex = (int)playerIndex;
        nPlayer.GetComponent<CharacterReference>().UpdateName();
        //nPlayer.GetComponent<PlayerInput>().devices[(int)playerIndex].deviceId;
    }

    // Start is called before the first frame update
    public Character GetCharacter()
    {
        return character;
    }

    public void SeUnio(PlayerInput pI)
    {
        
    }
}
