using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVel = 2f;
    [SerializeField] float yVel = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //state
    bool hasLaunched = false;
    Vector2 ballPosRelToPaddle;

    //cached component references
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        ballPosRelToPaddle = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLaunched = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + ballPosRelToPaddle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasLaunched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
