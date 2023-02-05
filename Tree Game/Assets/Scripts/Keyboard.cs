using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

    private TreeGameManager gameManager;

    void Start() {
        gameManager = GameObject.FindObjectOfType<TreeGameManager>().GetComponent<TreeGameManager>();
        //activateAllKeys();
    }

    void Update() {

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

        gameManager.selectRootMode = false;
    }

    private void deactivateAllKeys()
    {
        GameObject[] keys = gameManager.getKeys();
        foreach(GameObject key in keys)
        {
            key.GetComponent<Key>().deactivate();
        }
    }

    private void activateAllKeys()
    {
        GameObject[] keys = gameManager.getKeys();
        foreach (GameObject key in keys)
        {
            key.GetComponent<Key>().activate();
        }
    }
}
