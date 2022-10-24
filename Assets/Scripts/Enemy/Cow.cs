using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : Enemy
{
    private float speed = 3.0f;
    private int sleep = 3;

    protected override void Awake()
    {
        base.Awake();
        score = 6;
    }

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
