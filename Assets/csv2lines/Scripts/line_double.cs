using System.Linq;
using UnityEngine;

public class line_double : MonoBehaviour
{
    LineRenderer lineRenderer;
    public void Run(double[] doubleArray, float spacing)
    {
        int littleCount = doubleArray.Count();
        transform.position = transform.parent.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = littleCount;
        double bottom = doubleArray.Min();
        double top = doubleArray.Max();
        for (int i = 0; i < littleCount; i++)
            lineRenderer.SetPosition(i, 
                transform.position + new Vector3(
                    (float)(i / 10000.0f), 
                    (float)((doubleArray[i] - bottom)/(top-bottom)), 
                    spacing)
                );
    }
}