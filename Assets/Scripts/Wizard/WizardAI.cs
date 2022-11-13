using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAI : MonoBehaviour
{
    public State state;

    void Update()
    {
        RunCurrentState();
    }

    private void RunCurrentState() {
        State nextState = state?.RunCurrentState();

        if (nextState != null) {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State nextState) {
        state = nextState;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
