using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawCircleArroundPlayer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float radius = 2f; // Set the desired radius
    public int segments = 50; // Number of segments for the circle's smoothness

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("Line Renderer component not found!");
            return;
        }
        
        DrawCircle();
    }

    void Update()
    {
        radius = GetComponent<AreaOfDamagePowerup>().radius;
    }

    void DrawCircle()
    {
        lineRenderer.positionCount = segments;
        float angleStep = 2f * Mathf.PI / segments; // Calculate angle step in radians

        for (int i = 0; i < segments; i++)
        {
            float angle = i * angleStep;
            // Calculate X and Y positions using sine and cosine
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            
            // Set the position for the current segment
            // For 2D, use the x and y coordinates and a z position of 0
            lineRenderer.SetPosition(i, new Vector3(x, y, 0)); 
        }
    }
}
