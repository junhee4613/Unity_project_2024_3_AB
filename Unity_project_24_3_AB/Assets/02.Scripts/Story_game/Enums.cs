using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum Story_type      //���丮 Ÿ��
    {
        MAIN,
        SUB,
        SERIAL
    }

    public enum Event_type      //�̺�Ʈ �߻� �� üũ
    { 
        NONE,
        GOTOBATTLE = 100,
        CheckSTR = 1000
    }

    public enum Result_type
    {
        Add_experience,
        Go_to_nect_story,
        GoToRandom_story
    }
}

[System.Serializable]
public class Stats
{
    public int hp_point;
    public int sp_point;

    public int current_hp_point;
    public int current_sp_point;
    public int current_xp_point;

    public int strength;
    public int dexterity;
    public int consitution;
    public int Intelligence;
    public int wisdom;
    public int charisma;
}
