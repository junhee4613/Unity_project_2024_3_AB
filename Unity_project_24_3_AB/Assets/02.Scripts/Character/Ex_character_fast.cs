using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ex_character_fast : Ex_character
{
    //override ������
    protected override void Move()
    {
        transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
    }
}
