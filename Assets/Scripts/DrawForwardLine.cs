using UnityEngine;

public class DrawForwardLine : MonoBehaviour
{
    [SerializeField] private float _lengthLine = 4f, _width = 1f;
    [SerializeField] private Color _color;

    private GameObject line;
    private LineRenderer lineRenderer;

    void Start()
    {
        line = new GameObject("Line");
        lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = _color;
        lineRenderer.startWidth = _width;
        lineRenderer.endWidth = _width;
        lineRenderer.positionCount = 2;
        lineRenderer.sortingOrder = 10;
    }

    void Update()
    {
        DrawLine();
    }

    public void DrawLine()
    {
        Vector3 startPoint = new Vector3(transform.position.x, transform.position.y, -1);
        Vector3 endPoint = new Vector3(startPoint.x + (transform.right.x * _lengthLine),startPoint.y + (transform.right.y * _lengthLine),-1);

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }
}
