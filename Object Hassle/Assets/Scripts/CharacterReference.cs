using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReference : MonoBehaviour
{
    public Character character;
    public int playerIndex;

    public string _name;

    public void UpdateName()
    {
        _name = character.GetName();
    }
}
