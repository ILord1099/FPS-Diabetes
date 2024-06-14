using System;
using Newtonsoft.Json;
using NoTask.Models;
using Quiz.Model;
using UnityEngine;

namespace Quiz.Fake
{
    public class LocalClientGeneric : ClientGeneric
    {
        [SerializeField] private TextAsset json;
        [SerializeField] private Form form;

        private void Start()
        {
            form.SetQuestions(JsonConvert.DeserializeObject<Questions>(json.text));
            OnQuestionsLoaded?.Invoke();
        }
    }

    public abstract class ClientGeneric : MonoBehaviour
    {
        public static Action OnQuestionsLoaded { get; set; }
    }
}