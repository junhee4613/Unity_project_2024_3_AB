using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* "GameData"��� �̸����� ������ �����, "Game Data"��� �̸����� �޴��� ǥ���ϸ�, �޴������� ������ 50���� �����մϴ�.*/
[CreateAssetMenu(fileName = "New GameData", menuName = "Game Data", order = 50)]
public class ExGameData : ScriptableObject
{
    public string gameName;
    public int gmaeScore;
    public bool isGameActive;
}
