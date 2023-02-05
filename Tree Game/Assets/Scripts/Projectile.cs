using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float timeToDie = 5f;
    private bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isColliding = false;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Object.Destroy(gameObject, timeToDie);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isColliding)
            return;
        isColliding = true;
        if (collision.gameObject.tag.Equals("Alien"))
        {
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
