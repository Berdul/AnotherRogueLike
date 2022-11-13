using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Bullet
{
    public float fireballSpeed;
    public Rigidbody2D rb;
    
    private GameObject instance;

    void FixedUpdate() {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("coucou " + collision.GetContact(0).collider.tag);
        if (collision.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }
        if (collision.GetContact(0).collider.CompareTag("Player")) {
            Destroy(gameObject);
            // Damage player
        }
    }

    public override GameObject GetBulletPrefab()
    {
        return gameObject;
    }

    public override void Fire(Vector2 pointingDirection, Vector2 bulletSpawn, float angle)
    {
        GameObject fireball = Instantiate(gameObject, bulletSpawn, Quaternion.AngleAxis(angle, transform.forward));
        fireball.GetComponent<Rigidbody2D>().velocity = pointingDirection * fireballSpeed;
    }
}
