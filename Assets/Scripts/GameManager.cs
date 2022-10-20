using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject cameraCenterPoint;
    private float rotateSpeed = 45.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }


    // use Q and E key to rotate camera
    void RotateCamera()
    {
        if (Input.GetKey("left"))
        {
            cameraCenterPoint.gameObject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            cameraCenterPoint.gameObject.transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
    }


}
