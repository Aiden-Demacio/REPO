using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = GetComponent<StateMachine>();

        CutSceneState cutscene = new CutSceneState();
        WalkingState walking = new WalkingState();
        MiningState mining = new MiningState();

        stateMachine.SetState(cutscene);
    }
}

