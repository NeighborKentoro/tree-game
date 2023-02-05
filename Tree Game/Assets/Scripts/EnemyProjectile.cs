using UnityEngine;

public class EnemyProjectile : MonoBehaviour
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
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        Object.Destroy(gameObject, timeToDie);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(this.gameObject, 0f);
            Destroy(collision.gameObject, 0f);
        } else if (collision.gameObject.tag == "Alien")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else if ("a#bc#d#ef#g#".Contains(collision.gameObject.tag)) {
            EventManager.KeyboardHit(this.tag);
            Destroy(this.gameObject, 0f);
        }

            
    }
}
