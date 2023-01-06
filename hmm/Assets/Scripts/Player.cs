using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player player;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float angle;
    [SerializeField] private float angleSpeed;
    [SerializeField] private GameObject upmouth;
    [SerializeField] private GameObject downmouth;
    [SerializeField] private GameObject body;
    [SerializeField] private bool isPlaying;
    [SerializeField] private int meeter;
    [SerializeField] private float moveTime = 1;

    public static bool IsPlaying { get { return player.isPlaying; } }
    public static float MoveTime { get { return player.moveTime; } }
    public static float Meeter { get { return player.meeter; } }

    private float currentMoveTime = 0;
    private float inputAmount = 0.015f;
    private float angleGravity = 1.8f;

    Animator ani;

    private void Awake()
    {
        player = this;
        ani = GetComponent<Animator>();
    }

    void Start()
    {
        angle = 1;
        angleGravity = 0.015f;
        inputAmount = 1.8f;
    }

    void Update()
    {
        if (!isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isPlaying = true;
                angle = 1;
                angleGravity = 0.015f;
                inputAmount = 1.8f;
                angleSpeed = 0;
                meeter = 0;
            }
        }

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

            angleGravity += 0.0004f * Time.deltaTime;
            inputAmount += 0.04f * Time.deltaTime;

            if (Mathf.Abs(angle) >= 90)
            {
                isPlaying = false;
                moveTime = 1;
            }
        }

        ani.SetBool("isPlaying", isPlaying);
        ani.speed = 1 / moveTime;
    }

}
