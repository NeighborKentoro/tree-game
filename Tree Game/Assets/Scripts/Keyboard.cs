using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

    public string root = "all";
    public bool selectRootMode = true;

    void Start() {
        Debug.Log(root);
        Debug.Log(selectRootMode);
        activateAllKeys();
    }

    void Update() {

    }

    public void setRoot(string newRoot)
    {
        root = newRoot.ToLower().Trim();
        setActiveKeyByRoot();
    }

    private void setActiveKeyByRoot()
    {
        GameObject[] keysToActivate;
        switch (root)
        {
            case "a":
                keysToActivate = GameObject.FindGameObjectsWithTag("a");
                break;
            case "a#":
                keysToActivate = GameObject.FindGameObjectsWithTag("a#");
                break;
            case "b":
                keysToActivate = GameObject.FindGameObjectsWithTag("b");
                break;
            case "c":
                keysToActivate = GameObject.FindGameObjectsWithTag("c");
                break;
            case "c#":
                keysToActivate = GameObject.FindGameObjectsWithTag("c#");
                break;
            case "d":
                keysToActivate = GameObject.FindGameObjectsWithTag("d");
                break;
            case "d#":
                keysToActivate = GameObject.FindGameObjectsWithTag("d#");
                break;
            case "e":
                keysToActivate = GameObject.FindGameObjectsWithTag("e");
                break;
            case "f":
                keysToActivate = GameObject.FindGameObjectsWithTag("f");
                break;
            case "f#":
                keysToActivate = GameObject.FindGameObjectsWithTag("f#");
                break;
            case "g":
                keysToActivate = GameObject.FindGameObjectsWithTag("g");
                break;
            case "g#":
                keysToActivate = GameObject.FindGameObjectsWithTag("g#");
                break;
            default:
                keysToActivate = getAllKeys();
                break;
        }

        // deactivate all
        deactivateAllKeys();

        // enable keys
        foreach (GameObject key in keysToActivate)
        {
            key.GetComponent<Key>().activate();
            
        }

        Debug.Log("New root " + root);

        selectRootMode = false;
    }

    private void deactivateAllKeys()
    {
        GameObject[] keys = getAllKeys();
        foreach(GameObject key in keys)
        {
            key.GetComponent<Key>().deactivate();
        }
    }

    private void activateAllKeys()
    {
        GameObject[] keys = getAllKeys();
        foreach (GameObject key in keys)
        {
            key.GetComponent<Key>().activate();
        }
    }

    private GameObject[] getAllKeys()
    {
        List<GameObject> keys = new List<GameObject>();
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("a"))
        {
            keys.Add(go);
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("a#"))
        {
            keys.Add(go);
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("b"))
        {
            keys.Add(go);
        }
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("c"))
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
}
