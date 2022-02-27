using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlyingObject : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    private float horizontal;
    private float vertical;
    private float time;
    private Vector3 force;
    private Rigidbody body;
    private bool collisionOccured;
    private float bound = 20;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        horizontal = (int)Random.Range(-bound, bound);
        vertical = (int)Random.Range(-bound, bound);
        time = Random.Range(-5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        changeDirection();
        Movement();
    }

    void Movement()
    {
        force = new Vector3(forceMagnitude * horizontal, 0f , forceMagnitude * vertical);
        body.AddForce(force);
        
    }

    void changeDirection()
    {
        time -= Time.deltaTime;
        if(time == 0 || collisionOccured)
        {
            horizontal = (int)Random.Range(-bound, bound);
            vertical = (int)Random.Range(-bound, bound);
            time = Random.Range(-5f, 5f);
        }

    }

    void OnCollisionEnter(Collision col)
    {   
        if(col.gameObject.name == "Swatter")
        {
            Destroy(gameObject);
        } else
        {
            collisionOccured = true;
            changeDirection();
        }
    }
}
