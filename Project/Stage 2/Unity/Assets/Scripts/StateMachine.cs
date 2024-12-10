using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;

    public void SetState(State newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}