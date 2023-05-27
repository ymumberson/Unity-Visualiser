using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    float THICKNESS_BASELINE = 0.1f;
    private Transform point;
    private MeshRenderer meshRenderer;
    public bool animating { get; private set; }
    private float timer;
    private float duration;
    private Vector3 start;
    private Vector3 end;
    float thickness;
    Color colour;

    // Start is called before the first frame update
    public Line(float thickness, Color colour)
    {
        point = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        meshRenderer = point.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
        meshRenderer.sharedMaterial.color = Color.white;
        point.position = Vector3.zero;
        point.localScale = Vector3.one * thickness;
        this.thickness = thickness;
        this.colour = colour;
        timer = 0f;
        animating = false;
    }

    public void DrawLine(Vector3 start, Vector3 end, float thickness, Color colour)
    {
        float distance = Vector3.Distance(start, end);
        Vector3 midpoint = (end + start)/2f;
        point.position = midpoint;
        point.localScale = new Vector3(distance, thickness, thickness);
        //Vector3 toStart = (start - midpoint).normalized;
        //Vector3 dir = Vector3.Cross(new Vector3(0,0,-1),toStart);
        //point.LookAt(dir);
    }
}
