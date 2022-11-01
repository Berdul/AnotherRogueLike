using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobIdle : State
{
    public MobChase chaseState;
    public float MIN_CHASE_DISTANCE;
    public Rigidbody2D rb;

    public override State RunCurrentState() {
        if (PlayerManager.instance.GetDistanceToPlayer(gameObject) < MIN_CHASE_DISTANCE) {
            return chaseState;
        }

        rb.velocity = Vector2.zero;

        return this;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MIN_CHASE_DISTANCE);
    }
}
