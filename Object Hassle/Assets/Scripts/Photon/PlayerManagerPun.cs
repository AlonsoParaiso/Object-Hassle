using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using Photon.Realtime;

public class PlayerManagerPun : MonoBehaviourPunCallbacks
{
    private CharacterPun character;
    public uint playerIndex = 0;
    private void Start()
    {
        
        switch (Random.Range(0,3))
        {
            case 0:
                character = new ReyBombaPun("a", 10, 0);
                break;
            case 1:
                character = new MecheroPun("b", 8, 0);
                break;
            case 2:
                character = new WraithPun("c", 8, 0);
                break;
            default:
                break;
        }

        character.SetCharacterIndex(playerIndex);
        GameObject nPlayer = PlayerInput.Instantiate(character.GetGameObject(), pairWithDevice: Gamepad.all[(int)playerIndex]).gameObject;
        nPlayer.transform.Rotate(0,120,0);
        nPlayer.transform.rotation = Quaternion.identity;
        nPlayer.transform.position = new Vector3(0.5219868f, 3.851968f, -2.51f);
        nPlayer.AddComponent<CharacterReferencePun>().character = character;
        nPlayer.GetComponent<CharacterReferencePun>().playerIndex = (int)playerIndex;
        nPlayer.GetComponent<CharacterReferencePun>().UpdateName();
        //nPlayer.GetComponent<PlayerInput>().devices[(int)playerIndex].deviceId;
    }

    // Start is called before the first frame update
    public CharacterPun GetCharacter()
    {
        return character;
    }
}
