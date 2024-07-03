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
    private string actualScene;
    public Image Mentor;
    public Image Aluno;
    public Image Paciente;
    
    private void Awake()
    {
        instance = this;
        CaracterFade();
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
                if (DialogueControl.instance.index == 1)
                {
                    //Mentor On

                    Mentor.DOColor(Color.black, 1f);
                    Aluno.DOColor(Color.black, 1f);
                    Paciente.DOColor(Color.white, 1f);

                }
                if (DialogueControl.instance.index == 2)
                {
                    //Paciente On

                    Aluno.DOColor(Color.white, 1f);
                    Paciente.DOColor(Color.black, 1f);
                }

                if (DialogueControl.instance.index == 3)
                {
                    //Aluno On

                    Aluno.DOColor(Color.black, 1f);
                    Paciente.DOColor(Color.white, 1f);

                }
                if (DialogueControl.instance.index == 4)
                {
                    //Mentor On

                    Mentor.DOColor(Color.white, 1f);
                    Aluno.DOColor(Color.black, 1f);
                    Paciente.DOColor(Color.black, 1f);

                }
                if (DialogueControl.instance.index == 5)
                {
                    //alunoOn
                    Mentor.DOColor(Color.black, 1f);
                    Aluno.DOColor(Color.white, 1f);


                }
                if (DialogueControl.instance.index == 6)
                {
                    //Mentor on
                    Mentor.DOColor(Color.white, 1f);
                    Aluno.DOColor(Color.black, 1f);


                }
                if (DialogueControl.instance.index == 7)
                {
                    //aluno On
                    Mentor.DOColor(Color.black, 1f);
                    Aluno.DOColor(Color.white, 1f);


                }
                if (DialogueControl.instance.index == 8)
                {
                     SceneManager.LoadScene("Quiz");
                }
            

        }
            else if (actualScene == "Dialogue4")
            {
                if (DialogueControl.instance.index == 0)
                {
                    //Mentor On

                    Mentor.DOColor(Color.white, 1f);
                    Aluno.DOColor(Color.black, 1f);
                    Paciente.DOColor(Color.black, 1f);

                }
                if (DialogueControl.instance.index == 1)
                {
                    //Mentor On

                    Mentor.DOColor(Color.black, 1f);
                    Aluno.DOColor(Color.white, 1f);
                    Paciente.DOColor(Color.black, 1f);

                }


                if (DialogueControl.instance.index == 7)
                {
                   
                    SceneManager.LoadScene("Quiz4");
                }
        }
            else if (actualScene == "Dialogue6")
             {
                
                if (DialogueControl.instance.index == 9)
                {
                   SceneManager.LoadScene("Menu");
                }
        }

    }
    
}
