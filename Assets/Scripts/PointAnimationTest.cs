using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAnimationTest : MonoBehaviour
{
    [Range(0.1f, 2f)]
    public float duration = 1f;
    public int numPointsToGenerate;
    [Range(0f, 1f)]
    public float chanceToConverge;
    private float timer;
    private List<Vector3> lastPositions;
    private List<Point> pointList;
    private Line line;

    private void Awake()
    {
        timer = 0f;
        lastPositions = new List<Vector3>();
        pointList = new List<Point>();
    }

    private void Start()
    {
        //pointList.Add(new Point(0.5f, Color.white));
        //lastPositions.Add(Vector3.zero);
        //pointList.Add(new Point(0.5f, Color.green));
        //lastPositions.Add(Vector3.zero);
        //pointList.Add(new Point(0.5f, Color.magenta));
        //lastPositions.Add(Vector3.zero);
        for (int i = 0; i < numPointsToGenerate; ++i)
        {
            pointList.Add(new Point(0.5f, new Color(Random.value, Random.value, Random.value)));
            lastPositions.Add(Vector3.zero);
        }
        //line = new Line(0.1f, Color.white);
    }

    private void Update()
    {
        UpdateAllDrawables();

        bool converging = Random.value < chanceToConverge;
        Vector3 convergePoint = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
        for (int i = 0; i < pointList.Count; ++i)
        {
            Point p = pointList[i];
            if (!p.animating)
            {
                if (converging)
                {
                    p.Animate(lastPositions[i], convergePoint, duration);
                    this.lastPositions[i] = convergePoint;
                }
                else
                {
                    Vector3 newPosition = new Vector3(Random.Range(-8.3f, 8.3f), Random.Range(-4.3f, 4.3f), 0f);
                    p.Animate(lastPositions[i], newPosition, duration);
                    this.lastPositions[i] = newPosition;
                }

            }
        }
    }

    private void UpdateAllDrawables()
    {
        foreach (Point p in pointList)
        {
            p.Update(Time.deltaTime);
        }
    }
}
