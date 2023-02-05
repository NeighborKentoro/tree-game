using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeGameManager : MonoBehaviour {

    private int enemiesKilled;
    private int score;
    private int scoreMultiplier;
    private float timeElapsed = 0f;
    private float multiplierTimeElapsed;
    private string root = "all";
    private GameObject[] keys;
    public bool selectRootMode = true;
    public float multiplierTime;
    public float timeToShoot = 0f;
    public bool started = false;
    public bool gameOver;
    public int maxAliens;

    void Awake() {
        keys = getAllKeys();
        GameObject.FindAnyObjectByType<SceneController>().showMenu();
    }

    void Start() {
        this.gameOver = false;
        this.maxAliens = 0;
        this.enemiesKilled = 0;
        this.score = 0;
        this.scoreMultiplier = 0;
        started = false;
        keys = getAllKeys();
    }

    void Update() {
        this.multiplierTimeElapsed += Time.deltaTime;
        this.timeElapsed += Time.deltaTime;
        if (this.multiplierTimeElapsed >= this.multiplierTime && this.scoreMultiplier > 1) {
            this.scoreMultiplier = 1;
            EventManager.ScoreMultiplier(this.scoreMultiplier);
        }

        if (this.timeElapsed >= timeToShoot)
        {
            this.timeElapsed = 0f;
            EventManager.EnemyShoot(Random.Range(1, 9), Random.Range(1, 5));
        }
    }

    void OnEnable() {
        EventManager.enemyDiedEvent += EnemyDied;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= EnemyDied;
	}

    private void EnemyDied() {
        this.enemiesKilled++;
        this.scoreMultiplier++;
        this.score += 100 * (this.scoreMultiplier == 0 ? 1 : this.scoreMultiplier);
        this.multiplierTimeElapsed = 0f;
        EventManager.Score(this.score);
        EventManager.ScoreMultiplier(this.scoreMultiplier);
        if (enemiesKilled >= maxAliens)
        {
            youDaMan();
        }
    }

    private GameObject[] getAllKeys()
    {
        List<GameObject> keys = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("a"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("a#"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("b"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("c"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("c#"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("d"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("d#"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("e"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("f"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("f#"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("g"))
        {
            keys.Add(go);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("g#"))
        {
            keys.Add(go);
        }


        return keys.ToArray();
    }

    public GameObject[] getKeys()
    {
        return keys;
    }

    public GameObject[] getKeysByRoot(string r)
    { 
        switch (r)
        {
            case "a":
                return GameObject.FindGameObjectsWithTag("a");
            case "a#":
                return GameObject.FindGameObjectsWithTag("a#");
            case "b":
                return GameObject.FindGameObjectsWithTag("b");
            case "c":
                return GameObject.FindGameObjectsWithTag("c");
            case "c#":
                return GameObject.FindGameObjectsWithTag("c#");
            case "d":
                return GameObject.FindGameObjectsWithTag("d");
            case "d#":
                return GameObject.FindGameObjectsWithTag("d#");
            case "e":
                return GameObject.FindGameObjectsWithTag("e");
            case "f":
                return GameObject.FindGameObjectsWithTag("f");
            case "f#":
                return GameObject.FindGameObjectsWithTag("f#");
            case "g":
                return GameObject.FindGameObjectsWithTag("g");
            case "g#":
                return GameObject.FindGameObjectsWithTag("g#");
            default:
                return getAllKeys();
        }
    }

    public void startGame()
    {
        if (!gameOver)
        {
            started = true;
            GameObject.FindObjectOfType<SceneController>().hideMenuAndRules();
            
            GameObject.FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>().spawnAliens();

            GameObject.Find("Heart").SetActive(true);

        }
        
    }

    // win
    public void youDaMan()
    {
        GameObject.FindGameObjectWithTag("EndGame").GetComponent<TMP_Text>().text = "Woop woop. You win.\n\nPress any key to reset.";
        started = false;
        this.gameOver = true;
        GameObject.FindGameObjectWithTag("Keyboard").GetComponent<Keyboard>().activateAllKeys();
        if (score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", score);
    }


    // lose
    public void youSuck()
    {
        GameObject.FindGameObjectWithTag("EndGame").GetComponent<TMP_Text>().text = "Womp womp. Game over.\n\nPress any key to reset.";
        started = false;
        this.gameOver = true;
        // destroy all aliens
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");
        foreach(GameObject a in aliens)
        {
            Destroy(a, 0f);
        }
        // destroy all projectiles
        GameObject[] alienProjectiles = GameObject.FindGameObjectsWithTag("AlienProjectile");
        foreach(GameObject a in alienProjectiles)
        {
            Destroy(a, 0f);
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject p in projectiles)
        {
            Destroy(p, 0f);
        }

        GameObject.FindGameObjectWithTag("Keyboard").GetComponent<Keyboard>().deactivateAllKeys();
    }


}
