using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private float width;
    public float moveSpeed;
    
    private float startposx;

    private void Start() 
    {
        startposx = transform.position.x;    
    }

    void Update()
    {
        if(Mathf.Abs(startposx - transform.position.x) > width) transform.Translate(Vector3.right * width);
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
