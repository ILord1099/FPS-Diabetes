using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackCollect : MonoBehaviour
{
    public Text itemCounterText;
    private int itemCount = 0;

    void Start()
    {
        UpdateItemCounter();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemCount++;
            UpdateItemCounter();
            Destroy(other.gameObject); // Destrói o item coletado
        }
    }

    void UpdateItemCounter()
    {
        itemCounterText.text = "x0 " + itemCount.ToString();
    }
}
