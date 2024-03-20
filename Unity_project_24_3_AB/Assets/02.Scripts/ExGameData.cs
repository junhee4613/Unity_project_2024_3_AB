using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* "GameData"라는 이름으로 파일을 만들고, "Game Data"라는 이름으로 메뉴에 표시하며, 메뉴에서의 순서를 50으로 지정합니다.*/
[CreateAssetMenu(fileName = "New GameData", menuName = "Game Data", order = 50)]
public class ExGameData : ScriptableObject
{
    public string gameName;
    public int gmaeScore;
    public bool isGameActive;
}
