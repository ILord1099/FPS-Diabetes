using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string LvlName;
    public static GameController instance;
    public string deadlvlName;
    public string actualScene;
    public Image Mentor;
    public Image Aluno;
    public Image Paciente;
    
    private void Awake()
    {
        instance = this;
        
        
    }

    public void NextLVL()
    {
        SceneManager.LoadScene(LvlName);
    }

    public void Dead()
    {
        SceneManager.LoadScene(deadlvlName);
    }

    public void CaracterFade()
    {
        actualScene =  SceneManager.GetActiveScene().name;
        
            if(actualScene == "Dialogue") 
            {
                switch (DialogueControl.instance.index)
                {
                    case 1:
                        //Paciente On
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.white, 1f);
                        break;
                    case 2:
                        //Aluno On
                        Aluno.DOColor(Color.white, 1f);
                        Paciente.DOColor(Color.black, 1f);
                        break;
                    case 3:
                        //Paciente On

                        Aluno.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.white, 1f);
                        break;
                    case 4:
                        //Mentor On
                        Mentor.DOColor(Color.white, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.black, 1f);
                        break;
                    case 5:
                        //alunoOn
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.white, 1f);
                        break;
                    case 6:
                        //Mentor on
                        Mentor.DOColor(Color.white, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        break;
                    case 7:
                        //aluno On
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.white, 1f);
                    break;

                }

            
            }
            else if (actualScene == "Dialogue4")
            {
                switch (DialogueControl.instance.index)
                {
                    case 1:
                        //Aluno On
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.white, 1f);
                        Paciente.DOColor(Color.white, 1f);
                        Debug.Log("1");
                        break;
                    case 2:
                        //Paciente On
                        Aluno.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.white, 1f);
                        Debug.Log("2");
                        break;
                    case 3:
                        //Mentor On

                        Mentor.DOColor(Color.white, 1f);
                        Paciente.DOColor(Color.black, 1f);
                        Debug.Log("3");
                        break;
                    case 4:
                        //Aluno On
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.white, 1f);
                        Debug.Log("4");
                        break;
                    case 5:
                        //Mentor On
                        Mentor.DOColor(Color.white, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        Debug.Log("5");
                        break;
                }
 

             }
        else if (actualScene == "Dialogue6")
            {

                switch (DialogueControl.instance.index)
                {
                    case 1:
                        //Tutor On
                        Mentor.DOColor(Color.white, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.black, 1f);
                        Debug.Log("1");
                        break;
                    case 2:
                        //Paciente On
                        Mentor.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.white, 1f);
                        Debug.Log("2");
                        break;
                    case 3:
                        //tutor On

                        Mentor.DOColor(Color.white, 1f);
                        Paciente.DOColor(Color.black, 1f);
                        Debug.Log("3");
                        break;
                    case 4:
                        //Aluno On
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.white, 1f);
                        Debug.Log("4");
                        break;
                    case 5:
                        //tutor On
                        Mentor.DOColor(Color.white, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        Debug.Log("5");
                        break;
                    case 6:
                        //aluno on
                        Mentor.DOColor(Color.black, 1f);
                        Aluno.DOColor(Color.white, 1f);
                        Debug.Log("6");
                        break;
                    case 7:
                        //tutor On
                        Mentor.DOColor(Color.white, 1f);
                        Aluno.DOColor(Color.black, 1f);
                        Debug.Log("7");
                        break;
                    case 8:
                        //Paciente on
                        Mentor.DOColor(Color.black, 1f);
                        Paciente.DOColor(Color.white, 1f);
                        Debug.Log("8");
                    break;

                }
            }

    }


}
