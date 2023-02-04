using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public int movementFramesInterval;
    public int xLeftBounds;
    public int xRightBounds;

    private int xDirection;
    private int xStepsMoved;
    private int frameCount;

    void Start() {
        this.frameCount = 1;
        this.xDirection = 1;
    }

    // Update is called once per frame
    void Update() {
        if (this.frameCount >= this.movementFramesInterval) {
            float yStep = 0f;
            float xStep = 1f * this.xDirection;
            
            //only move if so many frames have passed
            if (xStepsMoved >= xLeftBounds || xStepsMoved <= xRightBounds) {
                //flip the x movement direction, reset number of x steps moved, increment y position
                this.xDirection *= -1;
                this.xStepsMoved = 0;
                yStep = -1f;
                xStep = 0f;
            } else {
                this.xStepsMoved += 1;
            }
            
            this.transform.position += new Vector3(xStep, yStep, 0);
            this.frameCount = 1;
        }
        this.frameCount++;
    }
}
