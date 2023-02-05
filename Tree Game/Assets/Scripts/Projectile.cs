using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float timeToDie = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Object.Destroy(gameObject, timeToDie);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag.Equals("Alien")) {
            Debug.LogWarning("HIT");
            this.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(this.gameObject, 0f);
        }
        if (collision.gameObject.tag == "AlienProjectile")
        {
            Destroy(this.gameObject, 0f);
            Destroy(collision.gameObject, 0f);
        }
    } 
}
