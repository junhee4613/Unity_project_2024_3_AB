using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IdleState : IState
{
    StateMachine stateMachine;
    float duration = 2.0f;
    float timer;
    public IdleState(StateMachine stateMachine)             //생성자
    {
        this.stateMachine = stateMachine;
    }
    public void Enter()
    {
        Debug.Log("Entered Idle State");
        timer = 0;
    }
    public void Execute()
    {
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            //다음 전환 함수
            stateMachine.ChangeState(new PatrolState(stateMachine));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
