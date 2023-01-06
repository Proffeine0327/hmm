using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private float spawnPosX;
    [SerializeField] private float disablePosX;
    [SerializeField] private Vector2 spawnPosYRange;

    private float moveSpeed;
    private float randomSpawnTime;

    private void Update()
    {
        if (Player.IsPlaying)
        {
            if (transform.position.x <= disablePosX)
            {
                transform.position = new Vector3(spawnPosX, Random.Range(spawnPosYRange.x, spawnPosYRange.y), transform.position.z);
                randomSpawnTime = Random.Range(1, 4);
                moveSpeed = Random.Range(0.001f, 0.01f);
            }

            if (randomSpawnTime > 0) randomSpawnTime -= Time.deltaTime;
            else transform.Translate(Vector3.left * moveSpeed);
        }
    }
}
