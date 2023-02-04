using UnityEngine;

public class Alien : MonoBehaviour {

    public int movementFramesInterval;
    public int xLeftBounds;
    public int xRightBounds;
    public int deadEnemiesFrameDrop = 20;

    private int xDirection;
    private int xStepsMoved;
    private int frameCount;
    private int row = 0;

    void OnEnable() {
        EventManager.enemyDiedEvent += EnemyDied;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= EnemyDied;
	}

    void Start() {
        this.frameCount = 1;
        this.xDirection = 1;
    }

    // Update is called once per frame
    void Update() {
        if (this.frameCount >= (this.movementFramesInterval + this.row)) {
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

    public void SetRow(int row) {
        this.row = row;
    }

    private void EnemyDied() {
        this.movementFramesInterval -= deadEnemiesFrameDrop;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Projectile") {
            EventManager.EnemyDied();
            Destroy(this, 0f);
        }
    } 
}
