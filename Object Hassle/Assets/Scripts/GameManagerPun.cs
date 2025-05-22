using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerPun : MonoBehaviourPunCallbacks
{
    public static GameManagerPun instance; //el game manager controla las variables del juego y es accesible a todos
    private float time;
    private float life;

    private KeyCode Esc = KeyCode.Escape;
    //public AudioClip SelectClip;
    public uint[] characterIndexes;
    public int sceneryIndexes;
    public AudioClip selection;
    public string scenaryCombat;
    public Character character;



    public enum GameManagerVariables { TIME, LIFE };//para facilitar el codigo

    private void Awake()
    {
        if (!instance)
        {
            instance = this;//se instancia el objecto
            characterIndexes = new uint[2];
            DontDestroyOnLoad(gameObject);// no se destruye entre cargas
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(Esc))
        {
            SceneManager.LoadScene("Menu");
            AudioManager.instance.ClearAudio();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            time = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AudioManager.instance.ClearAudio();
        }
    }

    // getter
    public float GetTime()
    {
        return time;
    }

    // getter


    // setter
    public void SetPoints(int value)
    {
        life = value;
    }

    public void LoadScene(string sceneName)
    {
        time = 0;
        SceneManager.LoadScene(sceneName);
        AudioManager.instance.ClearAudio();
    }

    public void ExitGame()
    {
        Debug.Log("Me cerraste wey");
        Application.Quit();
    }

    public void SelectCharacter(int Selection)
    {
        characterIndexes[0] = (uint)Selection;//selecciona el persoanje elegido
        AudioManager.instance.PlayAudio(selection, "selection", false, 0.5f);
    }

    public void SelectScenery()
    {
        LoadScene(scenaryCombat);//selencionna la escena la cual has elegido
        AudioManager.instance.PlayAudio(selection, "selection", false, 0.5f);
    }
    //public float GetLifes()
    //{
    //    //life=character.GetHealth();
    //    //return life;

    //}

}

