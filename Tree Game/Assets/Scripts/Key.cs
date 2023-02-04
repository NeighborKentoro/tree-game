using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    public GameObject shootPoint;
    private bool activated = true;
    private Keyboard keyboard;

    // Start is called before the first frame update
    void Start()
    {
        keyboard = GameObject.FindGameObjectWithTag("Keyboard").GetComponent<Keyboard>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


                if (hit.collider != null && hit.collider.GetComponent<Key>().activated)
                {
                    Debug.Log("Clicked: " + hit.collider.gameObject.tag);
                    // if in select root mode, this key will be set as root
                    if (GameObject.FindGameObjectWithTag("Keyboard").GetComponent<Keyboard>().selectRootMode == true)
                    {
                        Debug.Log("SELECTING ROOT");
                        updateRoot(hit.collider.gameObject.tag);
                    }
                    // spawn projectile
                    Instantiate(projectile, hit.collider.GetComponent<Key>().shootPoint.transform);
                }

            }
        
        
    }

    public void deactivate()
    {
        activated = false;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = Color.clear;
        foreach (Transform c in transform.GetComponentsInChildren<Transform>())
        {
            if (c.GetComponent<SpriteRenderer>() != null)
                c.GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }

    public void activate()
    {
        activated = true;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = Color.blue;
        // get children
        foreach (Transform c in transform.GetComponentsInChildren<Transform>())
        {
            if (c.GetComponent<SpriteRenderer>() != null)
                c.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    private void updateRoot(string tag)
    {
        Debug.Log("Setting root to " + tag);
        keyboard.setRoot(tag);
    }

}
