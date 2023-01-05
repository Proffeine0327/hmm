using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager manager;

    [SerializeField] private bool isPlaying;
    [SerializeField] private int meeter;

    private float moveTime = 1;
    private float currentMoveTime = 0;

    private void Awake()
    {
        manager = this;
    }

    private void Update()
    {
        if (isPlaying)
        {
            currentMoveTime += Time.deltaTime;
            if (currentMoveTime > moveTime)
            {
                meeter++;
                currentMoveTime = 0;
                moveTime -= 0.0083333f;
                moveTime = Mathf.Clamp(moveTime, 0.25f, 1);
            }
        }
    }
}