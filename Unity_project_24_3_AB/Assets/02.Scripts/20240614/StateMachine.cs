using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}
public class StateMachine : MonoBehaviour
{
    IState currentState;                //현재 상태값 인터페이스

    // Update is called once per frame
    void Update()
    {
        currentState?.Execute();
    }
    public void ChangeState(IState newState)
    {
        currentState?.Exit();               //이전 상태값을 빠져나간다.
        currentState = newState;            //인수로 받아온 상태값을 입력
        currentState?.Enter();               //다음 상태값
    }
}
