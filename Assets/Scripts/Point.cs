using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    private Transform point;
    private MeshRenderer meshRenderer;
    public float duration;
    private float timer;
    private float y;
    private float radius;

    // Start is called before the first frame update
    public Point(float duration, float y, float radius)
    {
        point = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        meshRenderer = point.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
        meshRenderer.sharedMaterial.color = Color.white;
        point.position = Vector3.zero;
        point.localScale = Vector3.one * radius;
        this.y = y;
        this.duration = duration;
        this.radius = radius;
    }

    // Update is called once per frame
    public void Update()
    {
        timer += Time.deltaTime;
        float start = -3f;
        float end = 3f;
        float animT = Mathf.Clamp01(timer / duration);
        if (timer > 2 * duration)
        {
            timer = 0f;
            animT = 0f;
        }
        else if (timer > duration)
        {
            float temp = end;
            end = start;
            start = temp;
            animT = Mathf.Clamp01((timer - duration) / duration);
        }
        float a = Mathf.Round(animT);
        animT = (4 * Mathf.Pow(animT, 3) * (1 - a)) + ((1 - (4 * Mathf.Pow(1 - animT, 3))) * a);

        float x = Mathf.Lerp(start, end, animT);
        DrawPoint(new Vector3(x, y, 0), radius, Color.white);
    }

    public void DrawPoint(Vector3 position, float radius, Color color)
    {
        point.position = position;
        point.localScale = Vector3.one * radius;
        meshRenderer.sharedMaterial.color = color;
    }
}
