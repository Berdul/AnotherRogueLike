using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : State
{
    public MobAttackCooldown cooldownState;
    public Rigidbody2D rb;

    public override State RunCurrentState() {
        Debug.Log("Mob has attacked");

        return cooldownState;
    }

    IEnumerator attack() {
        rb.velocity = Vector2.zero;

        yield return new WaitForSecondsRealtime(1f);
    }
}
