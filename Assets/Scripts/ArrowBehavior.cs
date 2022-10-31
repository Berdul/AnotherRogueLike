using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour, IBullet
{
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private int maxPiercing = 1;
    private int currentPiercing = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Wall") || currentPiercing >= maxPiercing) {
            Destroy(gameObject);
        } else if (collision.transform.CompareTag("Mob")) {
            currentPiercing++;
        }
    }

    public void Fire(Vector2 pointingDirection, Vector2 bulletSpawn, float angle) {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, Quaternion.AngleAxis(angle - 45, Vector3.forward));
        bullet.GetComponent<Rigidbody2D>().velocity = pointingDirection * bulletSpeed;
    }

    public GameObject GetBulletPrefab() {
        return bulletPrefab;
    }

}
