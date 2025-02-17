using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public int scenes;
    public void ExitGame()//hace que salga del juego
    {
        GameManager.instance.ExitGame();
    }

    public void LoadScene(string sceneName)//carga la escena a la que el boton este asignada
    {
        GameManager.instance.LoadScene(sceneName);
    }

    public void CharacterSelection(int selection)
    {
        FindObjectOfType<DisableButton>().GetComponent<Button>().interactable = true;
        GameManager.instance.SelectCharacter(selection);
    }

    public void ScenerySelection(string selection)
    {
        GameManager.instance.SelectScenery(selection);
    }


}