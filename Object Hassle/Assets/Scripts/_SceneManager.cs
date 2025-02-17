using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    public uint sceneryIndex = 0;

    private void Awake()
    {
        switch (GameManager.instance.sceneryIndexes[sceneryIndex])
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
