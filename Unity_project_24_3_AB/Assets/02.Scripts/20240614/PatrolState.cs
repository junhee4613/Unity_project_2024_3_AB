using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    StateMachine stateMachine;
    float duration = 2.0f;
    float timer;
    public PatrolState(StateMachine stateMachine)             //������
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
        if (timer >= duration)
        {
            //���� ��ȯ �Լ�
            stateMachine.ChangeState(new ChaseState(stateMachine));
        }
    }

    public void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
