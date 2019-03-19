﻿using UnityEngine;

public class Ball : MonoBehaviour
{

    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 5f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    public void PlaceBallAbovePaddle()
    {
        Vector2 newPos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y + 0.5f);
        transform.position = newPos;
        hasStarted = false;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float x;
        float y;
        if (myRigidBody2D.velocity.x >= 0){
            x = Random.Range(0f, randomFactor);
        } else {
            x = -(Random.Range(0f, randomFactor));
        }

        if (myRigidBody2D.velocity.y >= 0){
            y = Random.Range(0f, randomFactor);
        } else {
            y = -(Random.Range(0f, randomFactor));
        }
        Vector2 velocityTweak = new Vector2(x,y);
        if (hasStarted)
        {
            myAudioSource.PlayOneShot(ballSounds[0]);
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public void CollideLoseCollider()
    {
        myAudioSource.PlayOneShot(ballSounds[1]);
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }
}
