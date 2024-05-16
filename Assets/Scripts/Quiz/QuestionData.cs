using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "questoes",menuName = "ScriptableObject",order = 1)]
public class QuestionData : ScriptableObject
{
    public string question;
    public string category;
    [Tooltip(" a resposta correta deve ser listada primeiro, elas são randomizadas posteriormente ")]
    public string answers;
    
}
