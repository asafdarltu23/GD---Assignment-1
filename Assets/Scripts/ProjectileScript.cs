using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    Vector3 mousepos;

    public float lifetime;
    float lifetimecounter = 0;

    public Transform particle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousepos - transform.position;
        Vector3 rotation = transform.position - mousepos;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        lifetimecounter += Time.deltaTime;
        if (lifetimecounter > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(particle, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Environment") || other.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }
}
