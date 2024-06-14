using Newtonsoft.Json;
using NoTask.WebRequests;
using NoTask.WebRequests.Settings;
using UnityEngine;

public class HttpTest : MonoBehaviour
{
    
    private static QuizClient _client;
    public HttpSettings settings;
    
    // Start is called before the first frame update
    private async void Start()
    {
        _client = new QuizClient(settings);
        var settingsLoaded = await _client.GetSettings();
        
        Debug.Log(JsonConvert.SerializeObject(settingsLoaded));
    }
}
