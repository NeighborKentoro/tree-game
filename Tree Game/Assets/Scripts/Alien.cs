using UnityEngine;

public class Alien : MonoBehaviour {

    public int movementFramesInterval;
    public int xLeftBounds;
    public int xRightBounds;
    public int deadEnemiesFrameDrop = 20;
    public int maxStepSpeed;

    private int xDirection;
    private int frameCount;
    private int row = 0;
    private int column = 0;
    private float xStart;

    void OnEnable() {
        EventManager.enemyDiedEvent += EnemyDied;
        EventManager.killEnemyEvent += GetMaid;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= EnemyDied;
        EventManager.killEnemyEvent -= GetMaid;
	}

    void Start() {
        this.frameCount = 1;
        this.xDirection = 1;
        this.xStart = this.transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        if (this.frameCount >= (this.movementFramesInterval)) {
            float yStep = 0f;
            float xStep = 1f * this.xDirection;
            
            //only move if so many frames have passed
            if ( (this.transform.position.x + xStep) >= (this.xStart + this.xRightBounds)) {
                this.xDirection = -1;
                yStep = -1f;
                xStep = 0f;
            } else if ( (this.transform.position.x + xStep)  <= (this.xStart + this.xLeftBounds)) {
                this.xDirection = 1;
                yStep = -1f;
                xStep = 0f;
            }
            
            this.transform.position += new Vector3(xStep, yStep, 0);
            this.frameCount = 1;
        }
        this.frameCount++;
    }

    public void SetGrid(int row, int column) {
        this.row = row;
        this.column = column;
    }

    private void EnemyDied() {
        if (this.movementFramesInterval - this.deadEnemiesFrameDrop < this.maxStepSpeed) {
            this.movementFramesInterval = this.maxStepSpeed;
        } else {
            this.movementFramesInterval -= this.deadEnemiesFrameDrop;
        }
    }

    private void GetMaid(int row, int column) {
        if (this.row == row && this.column == column) {
            EventManager.EnemyDied();
            Destroy(this.gameObject, 0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Projectile") {
            EventManager.EnemyDied();
            Destroy(this.gameObject, 0.5f);
        }
    } 
}
