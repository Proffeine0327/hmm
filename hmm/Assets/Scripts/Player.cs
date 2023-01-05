using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float angleSpeed;
    [SerializeField] private float angleGravity;
    [SerializeField] private float inputAmount;
    [SerializeField] private GameObject upmouth;
    [SerializeField] private GameObject downmouth;
    [SerializeField] private GameObject body;

    void Start()
    {
        angle = 0.1f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) angleSpeed += inputAmount;
        if (Input.GetKey(KeyCode.RightArrow)) angleSpeed += -inputAmount;

        if (Mathf.Abs(angle) < 90) angleSpeed += (angle * angleGravity) * Time.deltaTime;
        angle += angleSpeed;
        angle = Mathf.Clamp(angle, -90, 90);

        if (Mathf.Abs(angle) > 30)
        {
            upmouth.transform.localRotation = Quaternion.Euler(0, 0, (Mathf.Abs(angle) - 30) / 3);
            downmouth.transform.localRotation = Quaternion.Euler(0, 0, -(Mathf.Abs(angle) - 30) / 3);
        }
        else
        {
            upmouth.transform.localRotation = Quaternion.Euler(0, 0, 0);
            downmouth.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        body.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
