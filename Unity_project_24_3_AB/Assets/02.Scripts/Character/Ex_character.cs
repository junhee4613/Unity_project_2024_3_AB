using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_character : MonoBehaviour
{
    public float speed = 5.0f;
    void Update()
    {
        Move();
    }
    protected virtual void Move()   //virtual ���� �Լ��� ���� ����ڿ��� �Լ��� ��ȯ�ϵ��� �Ѵ�.
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}
