using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableCounter : MonoBehaviour
{
    public static CollectableCounter Instance;

    public Text counterText;
    private int collectableCount = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void IncreaseCount()
    {
        collectableCount++;
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        counterText.text = "Collectibles: " + collectableCount.ToString();
    }
}
