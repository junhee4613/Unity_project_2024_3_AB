using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{

    public ExPlayer targetePlaeyr;
    //���� �÷��̾�� �ִ� ���ط�
    private int damage = 20;

    //�÷��̾�� ���ظ� �� �� ȣ��Ǵ� �Լ�
    public void AttackPlayer(ExPlayer player)
    {
        //�÷��̾�� ���ظ� ��
        player.TakeDamage(damage);
    }

    private void Update()
    {
        if(targetePlaeyr != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("����");
                AttackPlayer(targetePlaeyr);
            }
        }
    }
}
