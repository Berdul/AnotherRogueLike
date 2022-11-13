using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFlee : State
{
    public WizardIdle idleState;

    public override State RunCurrentState()
    {
        return idleState;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, idleState.FLEE_DISTANCE);
    }
}
