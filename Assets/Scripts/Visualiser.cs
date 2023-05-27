using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualiser : MonoBehaviour
{
    public float duration = 1f;
    private float timer;

    private void Awake()
    {
        timer = 0f;
    }

    private void LateUpdate()
    {
        timer += Time.deltaTime;
        float start = -5f;
        float end = 5f;

        float animT = Mathf.Clamp01(timer / duration);
        float size = Mathf.Lerp(0.5f, 3, (animT > 0.5f ? 1f - animT : animT));
        Color c = Color.Lerp(Color.black, Color.green, size);
        if (timer > 2 * duration)
        {
            timer = 0f;
            animT = 0f;
            size = Mathf.Lerp(0.5f, 3, (animT > 0.5f ? 1f - animT : animT));
            c = Color.Lerp(Color.black, Color.green, size);
        }
        else if (timer > duration)
        {
            float temp = end;
            end = start;
            start = temp;
            animT = Mathf.Clamp01((timer - duration) / duration);
            size = Mathf.Lerp(0.5f, 0.1f, (animT > 0.5f ? 1f - animT : animT));
            c = Color.Lerp(Color.black, Color.green, size);
        }

        //float size = Mathf.Lerp(0.5f, 2, (animT > 0.5f ? 1f - animT : animT));

        float a = Mathf.Round(animT);
        animT = (4 * Mathf.Pow(animT, 3) * (1 - a)) + ((1 - (4 * Mathf.Pow(1 - animT, 3))) * a);
        float x = Mathf.Lerp(start, end, animT);

        Point.Instance.DrawPoint(new Vector3(x, 0, 0), size, c);
    }
}
