using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGameManager : MonoBehaviour {

    private int enemiesKilled;
    private int score;
    private float timeElapsed = 0f;

    void Start() {
        this.enemiesKilled = 0;
        this.score = 0;
    }

    void Update() {
        // this.timeElapsed += Time.deltaTime;
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
