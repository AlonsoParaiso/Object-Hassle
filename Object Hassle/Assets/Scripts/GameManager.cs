using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //el game manager controla las variables del juego y es accesible a todos
    private float time;
    private int life;
    private KeyCode Esc = KeyCode.Escape;
    //public AudioClip SelectClip;
    public uint[] characterIndexes;
    public AudioClip selection;

    public enum GameManagerVariables { TIME, LIFE };//para facilitar el codigo

    private void Awake()
    {
        if (!instance)
        {
            instance = this;//se instancia el objecto
            DontDestroyOnLoad(gameObject);// no se destruye entre cargas
            characterIndexes = new uint[2];
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
    public int GetPoints()
    {
        return life;
    }

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
        characterIndexes[0] = (uint)Selection;
        AudioManager.instance.PlayAudio(selection, "selection", false, 0.5f);
    }


}