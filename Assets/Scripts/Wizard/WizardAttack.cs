using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : State
{
    public CircleCollider2D circleCollider;
    public WizardAttackCooldown attackCDState;
    public WizardIdle idleState;
    public FireBall fireBall;
    public float bulletSpawnOffset; // To prevent instant destroy when Fireball is in contact with Wizard

    public override State RunCurrentState()
    {
        if (hasSightOnPlayer()) {
            Vector2 pointingDirection = PlayerManager.instance.GetDirectionToPlayer(gameObject);
            float angle = Mathf.RoundToInt(Mathf.Atan2(pointingDirection.y, pointingDirection.x) * Mathf.Rad2Deg);
            Vector2 spawnPos = (Vector2)transform.position + (pointingDirection.normalized * bulletSpawnOffset);

            fireBall.Fire(PlayerManager.instance.GetDirectionToPlayer(gameObject), spawnPos, angle);

            return attackCDState;
        }
        
        return idleState;
    }

    private bool hasSightOnPlayer() {
        var posOffsetByMinRange = (Vector2)transform.position + PlayerManager.instance.GetDirectionToPlayer(gameObject) * (circleCollider.radius + 0.05f);
        RaycastHit2D hit = Physics2D.Raycast(posOffsetByMinRange, PlayerManager.instance.GetDirectionToPlayer(gameObject));
        Debug.DrawRay(posOffsetByMinRange, PlayerManager.instance.GetDirectionToPlayer(gameObject), Color.blue, 1);

        return hit.collider != null && (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Shield"));
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, idleState.ATTACK_DISTANCE);
    }
}
