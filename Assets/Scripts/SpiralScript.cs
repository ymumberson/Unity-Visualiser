using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralScript : MonoBehaviour
{
    [Range(0.01f,5f)]
    public float duration;
    public float spiralIncreaseRate;
    public int numPoints;
    public float spiralTurns;
    public float spiralRadius;
    [Range(0.01f,1f)]
    public float startScale;
    [Range(0.01f, 5f)]
    public float radius;
    public Color pointColourStart;
    public Color pointColourEnd;

    //private void Awake()
    //{
    //    spiralTurns = 1f;
    //}

    //private void FixedUpdate()
    //{
    //    spiralTurns += spiralIncreaseRate;
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        float animT = Mathf.Clamp01(Time.time/duration);
        animT = Visualiser.CubicInOut(animT);

        for (int i=0; i<numPoints; ++i)
        {
            float spiralT = i / (numPoints - 1f);
            float angle = spiralT * Mathf.PI * 2 * spiralTurns;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Vector2 pos = dir * spiralRadius * spiralT;
            float scale = Mathf.Lerp(startScale, 1f, spiralT);
            Color pointColour = Color.Lerp(pointColourStart, pointColourEnd, animT);

            Visualiser.Instance.DrawCircle(pos, radius * scale * animT, pointColour);
        }
    }
}
