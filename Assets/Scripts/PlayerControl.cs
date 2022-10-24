using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float forwardSpeed = 10.0f;
    private float rotateSpeed = 90.0f;
    [SerializeField] GameObject gameManagerObj;
    private GameManager gameManager;


    private void Awake()
    {
        gameManager = gameManagerObj.GetComponent<GameManager>();
    }

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
        if (gameManager.isGameOver) return;
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
        if (gameManager.isGameOver) return;
        if (Input.GetKey("a"))
        {
            gameObject.transform.Rotate(Vector3.down, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            gameObject.transform.Rotate(Vector3.up , rotateSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameOver) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            gameManager.CatchEnemy(enemy.score);
            Destroy(other.gameObject);
        }
    }
}
