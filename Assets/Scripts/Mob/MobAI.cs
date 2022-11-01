using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
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
}
