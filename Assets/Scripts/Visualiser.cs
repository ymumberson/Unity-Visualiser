using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualiser : MonoBehaviour
{
    public float duration = 1f;
    private float timer;
    private Vector3 lastPosition;

    private void Awake()
    {
        timer = 0f;
        lastPosition = Vector3.zero;
    }

    private void Start()
    {
        //Point.Instance.Animate(new Vector3(-3,-3,0), new Vector3(3,3,0), 2f, 1f, Color.white);
    }

    private void Update()
    {
        if (!Point.Instance.animating)
        {
            Vector3 newPosition = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
            Point.Instance.Animate(lastPosition, newPosition, 1f, 1f, Color.white);
            this.lastPosition = newPosition;
        }
    }
}