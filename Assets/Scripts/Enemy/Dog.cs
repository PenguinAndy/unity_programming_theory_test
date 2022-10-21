using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{
    private float speed = 8.0f;
    private int sleep = 2;

    // Start is called before the first frame update
    protected override void Start()
    {
        m_Agent.speed = speed;
        m_Sleep = sleep;
        base.Start();
    }

    // Update is called once per frame

    protected override void Update()
    {
        base.Update();
    }
}
