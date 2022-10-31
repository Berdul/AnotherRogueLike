using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBulletBehavior : MonoBehaviour, IBullet
{

    public GameObject bulletPrefab;
    public float bulletSpeed;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }

    public void Fire(Vector2 pointingDirection, Vector2 bulletSpawn, float angle) {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn, Quaternion.AngleAxis(angle, Vector3.forward));
        bullet.GetComponent<Rigidbody2D>().velocity = pointingDirection * bulletSpeed;

    }

    public GameObject GetBulletPrefab() {
        return bulletPrefab;
    }
}
