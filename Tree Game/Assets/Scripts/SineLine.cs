using System.Collections;
using System.Collections.Generic;
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
        // this.initalPosition = new Vector3(0, -100, 0);
        // this.secondPosition = new Vector3(0, 200, 0);
        this.line.positionCount = pointCount;
        this.line.useWorldSpace = false;
        this.points = new Vector3[pointCount];
    }

    private void Update() {
        // Vector3 dir = secondPosition - initalPosition;
        // get the segmentWidth from distance to end position
        segmentWidth = 20f;//= Vector3.Distance(initalPosition, secondPosition) / pointCount;

        // get the difference angle in the Z axis between the current transform.right
        // and the direction
        // float angleDifference = Vector3.SignedAngle(transform.right, dir, Vector3.forward);
        // and rotate the linerenderer transform by that angle in the Z axis
        // so the result will be that it's transform.right
        // points now towards the clicked position
        // transform.Rotate(Vector3.forward * angleDifference, Space.World);
        
        for (var i = 0; i < points.Length; ++i) {
            float y = segmentWidth * i - 17f;//18
            float x = Mathf.Sin(y * Time.time);
            points[i] = new Vector3(x, y, 0);
        }
        line.SetPositions(points);
    }
}
