using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;

    private Vector2 mousePos;
    private Vector2 pointingDirection;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {;
    }

    // Update is called once per frame
    void Update()
    {
        // Use Vector2 to make normalized calculus correct, else Z axis makes calculus wrong
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position2D = new Vector2(transform.position.x, transform.position.y);

        // Make gun face the mouse
        pointingDirection = (mousePos - position2D).normalized;
        angle = Mathf.RoundToInt(Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnDrawGizmosSelected()
    {
        // Draw gun center to mouse pos line
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, mousePos);
    }

    public void Fire()
    {
        Vector2 bulletSpawnPos = transform.GetChild(0).position;
        bulletPrefab.GetComponent<IBullet>().Fire(pointingDirection, bulletSpawnPos, angle);
    } 
}
