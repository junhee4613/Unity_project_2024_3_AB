using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExDataLoad : MonoBehaviour
{
    public ExGameData gameData;
    private void Start()
    {
        Debug.Log("Game Name : " + gameData.gameName);
        Debug.Log("Game Score : " + gameData.gmaeScore);
        Debug.Log("is Game Active : " + gameData.isGameActive);
    }
}
