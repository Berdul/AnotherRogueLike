using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private Vector3 mousePos;
    private Vector3 pointingDirection;
    private Vector3 fireBulletPosition;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        fireBulletPosition = transform.GetChild(0).position;

        // Make gun face the mouse
        pointingDirection = mousePos - transform.position;
        angle = Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnDrawGizmosSelected()
    {
        // Draw gun center to mouse pos line
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, mousePos);
    }

    public void Fire() {
        GameObject bullet = Instantiate(bulletPrefab, fireBulletPosition, Quaternion.AngleAxis(angle, Vector3.forward));
        bullet.GetComponent<Rigidbody2D>().velocity = (mousePos - transform.position).normalized * bulletSpeed;
    } 
}
