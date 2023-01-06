using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartKeyExplainUI : MonoBehaviour
{
    TextMeshProUGUI tmp;

    private void Awake() 
    {
        tmp = GetComponent<TextMeshProUGUI>();    
    }

    private void Update() 
    {
        tmp.enabled = !Player.IsPlaying;
    }
}
