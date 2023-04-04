using System.Linq;
using UnityEngine;

public class line_int : MonoBehaviour
{
    LineRenderer lineRenderer;
    public void Run(int[] intArray, float spacing)
    {
        int littleCount = intArray.Count();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = littleCount;
        int bottom = intArray.Min();
        int top = intArray.Max();
        for (int i = 0; i < littleCount; i++)
            lineRenderer.SetPosition(i, 
                transform.position + new Vector3(
                    (float)i / 10000.0f, 
                    (float)(intArray[i]-bottom)/ 
                    (float)(top-bottom), spacing)
                );
    }
}