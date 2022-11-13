using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : State
{
    public WizardAttackCooldown attackCDState;
    public WizardIdle idleState;
    public FireBall fireBall;
    public float bulletSpawnOffset; // To prevent instant destroy when Fireball is in contact with Wizard

    public override State RunCurrentState()
    {
        Vector2 pointingDirection = PlayerManager.instance.GetDirectionToPlayer(gameObject);
        float angle = Mathf.RoundToInt(Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg);
        Vector2 spawnPos = (Vector2)transform.position + (pointingDirection.normalized * bulletSpawnOffset);

        fireBall.Fire(PlayerManager.instance.GetDirectionToPlayer(gameObject), spawnPos, angle);

        return attackCDState;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, idleState.ATTACK_DISTANCE);
    }
}
