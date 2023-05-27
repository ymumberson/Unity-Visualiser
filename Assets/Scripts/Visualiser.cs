using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualiser : MonoBehaviour
{
    public static Visualiser Instance;
    private float timer;
    private List<Vector3> lastPositions;
    private List<Point> pointList;
    private List<Point> sparePoints;
    private Line line;

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

        timer = 0f;
        lastPositions = new List<Vector3>();
        pointList = new List<Point>();
        sparePoints = new List<Point>();
    }

    private void Update()
    {
        UpdateAllDrawables();
    }

    public void DrawCircle(Vector3 position, float radius, Color colour)
    {
        Point p;
        if (sparePoints.Count == 0)
        {
            p = new Point(radius, colour);
            pointList.Add(p);
        }
        else
        {
            p = sparePoints[0];
            sparePoints.RemoveAt(0);
            pointList.Add(p);
        }
        p.DrawPoint(position, radius, colour);
    }

    private void UpdateAllDrawables()
    {
        foreach (Point p in pointList.ToArray())
        {
            p.Update(Time.deltaTime);
            if (!p.animating)
            {
                pointList.Remove(p);
                sparePoints.Add(p);
            }
        }
    }

    public static float CubicInOut(float t)
    {
        float a = Mathf.Round(t);
        return (4 * Mathf.Pow(t, 3) * (1 - a)) + ((1 - (4 * Mathf.Pow(1 - t, 3))) * a);
    }
}