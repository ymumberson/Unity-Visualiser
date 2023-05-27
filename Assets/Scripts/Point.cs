using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static Point Instance;
    private Transform point;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        
        point = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        meshRenderer = point.GetComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Unlit/Color"));
        meshRenderer.sharedMaterial.color = Color.white;
        point.position = Vector3.zero;
        point.localScale = Vector3.one;
    }

    private void Update()
    {
        if (enabled) { this.enabled = false; }
    }

    public void DrawPoint(Vector3 position, float radius, Color color)
    {
        point.position = position;
        point.localScale = Vector3.one * radius;
        meshRenderer.sharedMaterial.color = color;
        this.enabled = true;
    }
}
