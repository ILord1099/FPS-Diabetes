using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nomeCena;
    // Start is called before the first frame update
    public void scene_changer(string scene_name)

    {
        SceneManager.LoadScene(nomeCena);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
