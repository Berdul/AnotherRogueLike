using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttackCooldown : State
{
    public WizardIdle idleState;
    public Rigidbody2D rb;
    public float cooldownDuration;

    private bool isCoolingDown = false;
    private bool hasCooledDown = false;

    public override State RunCurrentState() {
        if (!isCoolingDown) {
            // Coroutine start on first run of the script.
            StartCoroutine(wait(cooldownDuration));

            return this;
        }
        if (!hasCooledDown) {
            // Always return this while coroutine is running, as isCooling down is true and hasCooledDown is false.
            return this;
        }
        // If coroutine has finished (isCoolingDown false, hasCooledDown true), reset hasCooledDown to false for another run.
        isCoolingDown = false;
        hasCooledDown = false;

        return idleState;
    }

    IEnumerator wait(float duration) {
        isCoolingDown = true;
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(duration);

        hasCooledDown = true;
    }
}
