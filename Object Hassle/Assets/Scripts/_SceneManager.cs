using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public int sceneryIndex = 0;

    private void Awake()
    {
        switch (GameManager.instance.sceneryIndexes)
        {
            case 0:
                SceneManager.LoadScene("MapRetro");
                break;
            case 1:
                SceneManager.LoadScene("MapRetro 1");
                break ;
            default:
                break;
        }

    }
}
