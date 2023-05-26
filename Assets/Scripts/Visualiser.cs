using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualiser : MonoBehaviour
{
    private Transform point;
    private MeshRenderer meshRenderer;
    public bool reversed;
    public float duration = 1f;
    public float y = 0f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        meshRenderer = point.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
        meshRenderer.sharedMaterial.color = Color.white;
        point.position = Vector3.zero;
        point.localScale = Vector3.one;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float start = -5f;
        float end = 5f;
        if (reversed)
        {
            float temp = end;
            end = start;
            start = temp;
        }

        float animT = Mathf.Clamp01(timer / duration);
        float size = Mathf.Lerp(0.5f, 3, (animT > 0.5f ? 1f - animT : animT));
        Color c = Color.Lerp(Color.black, Color.green, size);
        if (timer > 2*duration) 
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
            animT = Mathf.Clamp01((timer-duration) / duration);
            size = Mathf.Lerp(0.5f, 0.1f, (animT > 0.5f ? 1f - animT : animT));
            c = Color.Lerp(Color.black, Color.green, size);
        }

        //float size = Mathf.Lerp(0.5f, 2, (animT > 0.5f ? 1f - animT : animT));

        float a = Mathf.Round(animT);
        animT = (4 * Mathf.Pow(animT,3) * (1-a)) + ((1 - (4*Mathf.Pow(1-animT,3))) * a);
        float x = Mathf.Lerp(start, end, animT);

        //Color c = Color.Lerp(Color.black, Color.green, size);

        DrawPoint(new Vector3(x,y,0), size, c);
    }

    public void DrawPoint(Vector3 position, float radius, Color color)
    {
        point.position = position;
        point.localScale = Vector3.one * radius;
        meshRenderer.sharedMaterial.color = color;
    }
}
