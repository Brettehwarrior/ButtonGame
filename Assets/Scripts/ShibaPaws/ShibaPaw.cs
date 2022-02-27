using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Random = System.Random;
using UnityEngine;

public class ShibaPaw : MonoBehaviour
{

    private int speed = 2;

    private float oriX;

    private float oriY;

    private float oriZ;

    private bool returning = false;
    // Start is called before the first frame update
    void Start()
    {
        oriX = gameObject.transform.position.x;
        oriY = gameObject.transform.position.y;
        oriZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!returning)
        {
            float newX = oriX , newY = oriY, newZ = oriZ;
            if (oriX.Equals(-2))
            {
                newX = -0.5f;
            } else if (oriX.Equals(2))
            {
                newX = 0.5f;
            }
    
            if (oriZ.Equals(-2))
            {
                newZ = -0.5f;
            } else if (oriZ.Equals(2))
            {
                newZ = 0.5f;
            }
            gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(newX,newY,newZ), speed * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, new Vector3(oriX,oriY,oriZ), speed * Time.deltaTime);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit!");
    }

    private void OnMouseDown()
    {
        returning = true;

    }
}
