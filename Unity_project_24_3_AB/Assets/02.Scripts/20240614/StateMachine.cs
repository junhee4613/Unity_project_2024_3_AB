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
    IState currentState;                //���� ���°� �������̽�

    // Update is called once per frame
    void Update()
    {
        currentState?.Execute();
    }
    public void ChangeState(IState newState)
    {
        currentState?.Exit();               //���� ���°��� ����������.
        currentState = newState;            //�μ��� �޾ƿ� ���°��� �Է�
        currentState?.Enter();               //���� ���°�
    }
}
