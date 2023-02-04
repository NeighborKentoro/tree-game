using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGameManager : MonoBehaviour {

    private int enemiesKilled;
    private int score;

    // Start is called before the first frame update
    void Start() {
        this.enemiesKilled = 0;
        this.score = 0;
    }

    // Update is called once per frame
    void Update() {
        
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
        //INCREASE TEMPO BASED ON ENEMIES KILLED
    }
}
