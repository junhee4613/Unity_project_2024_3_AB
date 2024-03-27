using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_character_different : Ex_character
{
    //override ¿Á¡§¿«
    protected override void Move()
    {
        base.Move();
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
