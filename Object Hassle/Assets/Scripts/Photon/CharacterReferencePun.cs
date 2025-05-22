using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReferencePun : MonoBehaviour
{
    public CharacterPun character;
    public int playerIndex;

    public string _name;

    public void UpdateName()
    {
        _name = character.GetName();
    }
}
