using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{

    public ExPlayer targetePlaeyr;
    //적이 플레이어에게 주는 피해량
    private int damage = 20;

    //플레이어에게 피해를 줄 때 호출되는 함수
    public void AttackPlayer(ExPlayer player)
    {
        //플레이어에게 피해를 줌
        player.TakeDamage(damage);
    }

    private void Update()
    {
        if(targetePlaeyr != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("공격");
                AttackPlayer(targetePlaeyr);
            }
        }
    }
}
