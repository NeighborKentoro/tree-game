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
    [SerializeField]
    public GameObject projectile;
    private float shootCooldown = 5f;
    private int chanceModifier = 0;
    private bool isColliding;
    private ParticleSystem particles;

    void OnEnable() {
        EventManager.enemyDiedEvent += EnemyDied;
        EventManager.beatEvent += FireProjectile;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= EnemyDied;
        EventManager.beatEvent -= FireProjectile;
	}

    void Start() {
        this.frameCount = 1;
        this.xDirection = 1;
        this.xStart = this.transform.position.x;
        this.chanceModifier = 0;
        this.particles = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {
        isColliding = false;
        if (this.frameCount >= (this.movementFramesInterval)) {
            float yStep = 0f;
            float xStep = 2f * this.xDirection;
            
            //only move if so many frames have passed
            if ( (this.transform.position.x + xStep) >= (this.xStart + this.xRightBounds)) {
                this.xDirection = -1;
                yStep = -2f;
                xStep = 0f;
            } else if ( (this.transform.position.x + xStep)  <= (this.xStart + this.xLeftBounds)) {
                this.xDirection = 1;
                yStep = -2f;
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
        this.chanceModifier++;
        if (this.movementFramesInterval - this.deadEnemiesFrameDrop < this.maxStepSpeed) {
            this.movementFramesInterval = this.maxStepSpeed;
        } else {
            this.movementFramesInterval -= this.deadEnemiesFrameDrop;
        }
    }

    private void FireProjectile(int beat) {
        int chanceToFire = Random.Range(0, 100);
        int chancePercent = this.chanceModifier >= 130 ? 25 : 0;
        if ( (this.row % 4 == (beat - 1) || this.column % 4 == (beat - 1)) && chanceToFire >= (98 - chancePercent) ) {
            GameObject.Instantiate(projectile, this.transform.position, this.transform.rotation);
            this.particles.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding) 
            return;
        isColliding = true;

        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject, 0f);
            EventManager.EnemyDied();
            
        }
        else if (collision.gameObject.tag == "AlienProjectile")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if ("a#bc#d#ef#g#".Contains(collision.gameObject.tag))
        {
            Destroy(this.gameObject, 0f);
            EventManager.EnemyDied();
            EventManager.KeyboardHit(this.tag);
        }
    }
}
