using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex_player_prefab_data : MonoBehaviour
{
    public int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            Save_data(Score);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(Load_data());
        }
    }
    void Save_data(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }
    int Load_data()
    {
        return PlayerPrefs.GetInt("Score");
    }
}
