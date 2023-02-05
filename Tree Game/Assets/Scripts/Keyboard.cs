using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

    private TreeGameManager gameManager;
    [SerializeField]
    public int maxHealth = 100;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
        gameManager = GameObject.FindObjectOfType<TreeGameManager>().GetComponent<TreeGameManager>();
        deactivateAllKeys();
    }

    void Update() {

    }

    void OnEnable()
    {
        EventManager.keyboardHitEvent += KeyboardHit;
    }

    public void setRoot(string newRoot)
    {
        setActiveKeyByRoot(newRoot);
    }

    private void setActiveKeyByRoot(string newRoot)
    {

        // deactivate all
        deactivateAllKeys();

        // enable keys
        foreach (GameObject key in gameManager.getKeysByRoot(newRoot))
        {
            key.GetComponent<Key>().activate();

        }

        if (!gameManager.started)
            gameManager.startGame();
    }

    public void deactivateAllKeys()
    {
        GameObject[] keys = gameManager.getKeys();
        foreach(GameObject key in keys)
        {
            key.GetComponent<Key>().deactivate();
        }
    }

    public void activateAllKeys()
    {
        GameObject[] keys = gameManager.getKeys();
        foreach (GameObject key in keys)
        {
            key.GetComponent<Key>().activate();
        }
    }

    void KeyboardHit()
    {
        currentHealth--;
        Debug.Log(currentHealth);
        if (currentHealth < 0)
        {
            gameManager.youSuck();
        }
    }
}
