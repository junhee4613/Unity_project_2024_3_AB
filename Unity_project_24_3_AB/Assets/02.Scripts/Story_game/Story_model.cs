using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_story", menuName = "scriptable_objects/story_model")]
public class Story_model : ScriptableObject
{

    public int story_number;
    public Texture2D main_image;

    public enum STORYTYPE
    {
        MAIN,
        SUB,
        SERIAL
    }

    public STORYTYPE story_type;
    public bool story_done;

    [TextArea(10, 10)]
    public string story_text;

    public Option[] options;            //선택지 배열

    [System.Serializable]
    public class Option
    {
        public string option_text;
        public string button_text;      //선택지 버튼의 이름

        public Event_check event_check;
    }
    [System.Serializable]
    public class Event_check
    {
        public int check_value;
        public enum Event_type : int
        {
            NONE,
            GoToBattle,
            CheckSTR,
            CheckDEX,
            CheckCON,
            CheckINT,
            CheckWIS,
            CheckCHA
        }

        public Event_type event_type;

        public Result[] sucess_result;          //선택지에 대한 효과 배열
        public Result[] fail_result;
    }
    [System.Serializable]
    public class Result                         //결과값 정보 데이터
    {
        public enum Result_type : int 
        { 
            ChangeHp,
            ChangeSp,
            AddExperience,
            GoToShop,
            GoToNextStory,
            GoToRandomStory
        }

        public Result_type result_type;
        public int value;
        public Stats stats;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
