using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public string LvlName;
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }

    public void NextLVL()
    {
        SceneManager.LoadScene(LvlName);
    }
}
