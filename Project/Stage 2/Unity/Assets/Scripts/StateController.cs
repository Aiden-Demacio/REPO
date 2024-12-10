using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();

        OnState on = new OnState();
        OffState off = new OffState();

        stateMachine.SetState(off);
    }
}

