using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeeterUI : MonoBehaviour
{
    TextMeshProUGUI tmp;

    private void Awake() 
    {
        tmp = GetComponent<TextMeshProUGUI>();   
    }

    private void Update() 
    {
        tmp.text = Player.Meeter.ToString() + " m";
    }
}
