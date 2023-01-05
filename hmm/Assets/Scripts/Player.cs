using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float angle;
    [SerializeField] private float angleSpeed;
    [SerializeField] private GameObject upmouth;
    [SerializeField] private GameObject downmouth;
    [SerializeField] private GameObject body;

    private float inputAmount = 0.015f;
    private float angleGravity = 1.8f;

    void Start()
    {
        angle = 1;
        angleGravity = 0.015f;
        inputAmount = 1.8f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) angleSpeed += inputAmount * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow)) angleSpeed += -inputAmount * Time.deltaTime;

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

        angleGravity += 0.0005f * Time.deltaTime;
        inputAmount += 0.03333333f * Time.deltaTime;
    }
}
