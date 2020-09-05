using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Manager : MonoBehaviour
{
    public Game_Manager _Instance;

    private void Awake()
    {
        if(_Instance == null)
        {
            _Instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Change_Scene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }
}
