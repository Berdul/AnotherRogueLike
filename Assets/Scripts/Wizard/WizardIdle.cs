using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIdle : State
{
    public WizardAttack attackState;
    public WizardFlee fleeState;

    public float FLEE_DISTANCE;
    public float ATTACK_DISTANCE;

    public override State RunCurrentState()
    {
        if (PlayerManager.instance.GetDistanceToPlayer(gameObject) < FLEE_DISTANCE) {
            return fleeState;
        }
        if (PlayerManager.instance.GetDistanceToPlayer(gameObject) < ATTACK_DISTANCE) {
            return attackState;
        }

        return this;
    }
}
