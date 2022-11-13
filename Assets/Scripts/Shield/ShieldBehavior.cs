using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public float offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("que se paso ?");
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 pointingDirection = (mousePos - PlayerManager.instance.GetPlayerPosition()).normalized;
        float angle = Mathf.RoundToInt(Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = PlayerManager.instance.GetPlayerPosition() + pointingDirection * offset;
        Debug.Log("Oldel paso : " + transform.position);
    }

    void OnDrawGizmosSelected()
    {
        // Draw gun center to mouse pos line
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(PlayerManager.instance.GetPlayerPosition(), offset);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Shield hit " + collision.collider.tag);
        if (collision.collider.gameObject.CompareTag("Bullet")) {
            var previousVelocity = collision.rigidbody.velocity;
            collision.rigidbody.velocity = 
                Vector2.Reflect(collision.rigidbody.GetComponent<Bullet>().lastVelocity, collision.GetContact(0).normal);
            Debug.Log("Velocity changed ? " + (previousVelocity == collision.rigidbody.velocity));
        }
    }
}
