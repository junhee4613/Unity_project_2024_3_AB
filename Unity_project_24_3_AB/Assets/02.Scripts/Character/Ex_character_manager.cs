using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_character_manager : MonoBehaviour
{
    public List<Ex_character> character_list = new List<Ex_character>();
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < character_list.Count; i++)
            {
                character_list[i].DestroyCharacter();
            }
        }
    }
}
