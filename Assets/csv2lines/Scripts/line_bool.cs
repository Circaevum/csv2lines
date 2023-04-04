using System.Linq;
using UnityEngine;

public class line_bool : MonoBehaviour
{
    LineRenderer lineRenderer;
    public void Run(bool[] boolStates,float spacing)
    {
        int littleCount = boolStates.Count();
        transform.position = transform.parent.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = littleCount;
        for (int i = 0; i < littleCount; i++)
        {
            if (boolStates[i] == false)
            {
                lineRenderer.SetPosition(i, 
                    transform.position + new Vector3(
                        (float)(i/10000.0f), 
                        0, 
                        spacing)
                    );
            }
            else
            {
                lineRenderer.SetPosition(i, 
                    transform.position + new Vector3(
                        (float)(i / 10000.0f), 
                        1, spacing)
                    );
            }
        }
    }
}

