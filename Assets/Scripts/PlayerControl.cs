using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float forwardSpeed = 10.0f;
    private float rotateSpeed = 45.0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
        RotationPlayer();
        MovePlayer();   
    }

    private void FixedUpdate()
    {
    }

    //  use s/w key to let user moved
    void MovePlayer()
    {
        if (Input.GetKey("s"))
        {
            gameObject.transform.Translate(Vector3.back * forwardSpeed * Time.deltaTime);
        }

        if (Input.GetKey("w"))
        {
            gameObject.transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }
    }

    //  use a/d key to let user moved
    void RotationPlayer()
    {
        if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(Vector3.up , rotateSpeed * Time.deltaTime);
        }
    }
}
