using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGameManager : MonoBehaviour {

    private int enemiesKilled;
    private int score;
    private float timeElapsed = 0f;
    private string root = "all";
    private GameObject[] keys;
    public bool selectRootMode = true;
    public float timeToShoot = 0f;

    void Start() {
        this.enemiesKilled = 0;
        this.score = 0;
        keys = getAllKeys();
    }

    void Update() {
        this.timeElapsed += Time.deltaTime;
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
        this.score++;
        this.enemiesKilled++;
        EventManager.Score(this.score);
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


}
