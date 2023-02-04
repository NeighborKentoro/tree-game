using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGameManager : MonoBehaviour {

    private int enemiesKilled;
    private int score;
    private float timeElapsed = 0f;
    public float timeToDie = 0f;

    // Start is called before the first frame update
    void Start() {
        this.enemiesKilled = 0;
        this.score = 0;
    }

    // Update is called once per frame
    void Update() {
        this.timeElapsed += Time.deltaTime;
        if (this.timeElapsed >= timeToDie) {
            this.timeElapsed = 0f;
            EventManager.KillEnemy(Random.Range(1, 9), Random.Range(1, 5));
        }
    }

    void OnEnable() {
        EventManager.enemyDiedEvent += EnemyDied;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= EnemyDied;
	}

    private void EnemyDied() {
        this.score++;
        this.enemiesKilled++;
        EventManager.Score(this.score);
    }
}
