using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobChase : State
{
    public MobIdle idleState;
    public MobAttack attackState;
    public float MIN_ATTACK_DISTANCE;
    public Rigidbody2D rb;

    public float chaseSpeed;

    public override State RunCurrentState()
    {
        if (PlayerManager.instance.GetDistanceToPlayer(gameObject) > idleState.MIN_CHASE_DISTANCE) {
            return idleState;
        }
        if (PlayerManager.instance.GetDistanceToPlayer(gameObject) < MIN_ATTACK_DISTANCE) {
            return attackState;
        }

        rb.velocity = PlayerManager.instance.GetDirectionToPlayer(gameObject) * chaseSpeed;

        return this;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, MIN_ATTACK_DISTANCE);
    }
}
