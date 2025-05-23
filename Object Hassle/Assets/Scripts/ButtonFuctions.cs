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

    public void ScenerySelection(int selection)
    {
        switch (selection)
        {

            case 0:
                GameManager.instance.scenaryCombat = "MapRetro";
                FindObjectOfType<DisableButton>().GetComponent<Button>().interactable = true;
                break;
            case 1:
                GameManager.instance.scenaryCombat = "MapRain";
                FindObjectOfType<DisableButton>().GetComponent<Button>().interactable = true;
                break;
            case 2:
                GameManager.instance.scenaryCombat = "MapSpace";
                FindObjectOfType<DisableButton>().GetComponent<Button>().interactable = true;
                break;
            default:
                break;

        }

    }
    public void SelectScenary()
    {
        GameManager.instance.SelectScenery();

    }


}