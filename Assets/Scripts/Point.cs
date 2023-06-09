using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    private Transform point;
    private MeshRenderer meshRenderer;
    public bool animating { get; private set; }
    private float timer;
    private float duration;
    private Vector3 start;
    private Vector3 end;
    float radius;
    Color colour;

    // Start is called before the first frame update
    public Point(float radius, Color colour)
    {
        point = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        meshRenderer = point.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
        meshRenderer.sharedMaterial.color = Color.white;
        point.position = Vector3.zero;
        point.localScale = Vector3.one;
        this.radius = radius;
        this.colour = colour;
        timer = 0f;
        animating = false;
    }

    public void Update(float time)
    {
        if (animating)
        {
            timer += time;
            Animate();
        }
        else if (meshRenderer.enabled)
        {
            meshRenderer.enabled = false;
        }
    }

    public void DrawPoint(Vector3 position)
    {
        this.DrawPoint(position, this.radius, this.colour);
    }

    public void DrawPoint(Vector3 position, float radius, Color color)
    {
        point.position = position;
        point.localScale = Vector3.one * radius;
        meshRenderer.sharedMaterial.color = color;
        meshRenderer.enabled = true;
    }

    public void Animate(Vector3 start, Vector3 end, float duration)
    {
        this.Animate(start, end, duration, this.radius, this.colour);
    }

    public void Animate(Vector3 start, Vector3 end, float duration, float radius, Color colour)
    {
        this.start = start;
        this.end = end;
        this.duration = duration;
        this.radius = radius;
        this.colour = colour;
        this.animating = true;
        timer = 0f;
    }

    private void Animate()
    {
        float animT = Mathf.Clamp01(timer / duration);
        float a = Mathf.Round(animT);
        animT = (4 * Mathf.Pow(animT, 3) * (1 - a)) + ((1 - (4 * Mathf.Pow(1 - animT, 3))) * a);
        if (animT == 1)
        {
            this.animating = false;
        }
        //point.position = Vector3.Lerp(this.start, this.end, animT);
        this.DrawPoint(Vector3.Lerp(this.start, this.end, animT), this.radius, this.colour);
    }
}
