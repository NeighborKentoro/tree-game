using UnityEngine;

public class SineLine : MonoBehaviour {

    public Vector3 initalPosition;
    public int pointCount = 400;
    public LineRenderer line;

    private Vector3 secondPosition;
    private Vector3[] points;
    private float segmentWidth;

    private void Awake() {
        this.line = GetComponent<LineRenderer>();
        this.line.positionCount = pointCount;
        this.line.useWorldSpace = false;
        this.points = new Vector3[pointCount];
        this.segmentWidth = 20f;
    }

    private void Update() {
        for (var i = 0; i < points.Length; ++i) {
            float y = segmentWidth * i - 17f;//18
            float x = Mathf.Sin(y * Time.time);
            points[i] = new Vector3(x, y, 0);
        }
        line.SetPositions(points);
    }
}
