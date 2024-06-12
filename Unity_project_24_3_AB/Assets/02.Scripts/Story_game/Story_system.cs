using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Story_system : MonoBehaviour
{
    public static Story_system instance;            //간단한 싱글톤화

    public Story_model current_story_model;

    public enum TEXTSYSTEM
    {
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                  //각 글자가 나타나는데 걸리는 시간
    public string full_text;                    //전체 표시할 텍스트
    string current_text = "";                   //현재까지 표시된 텍스트

    public Text text_component;                 //Text 컴포넌트
    public Text story_index;                    //지금 스토리 번호

    public Image image_component;               //보여진 이미지 컴포넌트

    public Button[] button_way = new Button[3];
    public Text[] button_way_text = new Text[3];
    private void Awake()
    {
        instance = this;
    }

    public void On_way_click(int index)         //버튼이 눌렸을 때 해당 설정된 index를 받아온다.
    {
        bool Check_event_type_none = false;     //기본으로 NONE일 때는 성공이라고 판단
        Story_model play_story_model = current_story_model;

        if (play_story_model.options[index].event_check.event_type == Story_model.Event_check.Event_type.NONE)
        {   
            for (int i = 0; i < play_story_model.options[index].event_check.sucess_result.Length; i++)
            {
                //FIX : 이거 나중에 수정
                Debug.Log(i);
                Game_system.instance.Apply_choice(current_story_model.options[index].event_check.sucess_result[i]); 
                Check_event_type_none = true;
            }
        }

        bool check_value = false;
    }
    
    public void Story_model_init()              //스토리 모델 init
    {
        full_text = current_story_model.story_text;

        story_index.text = current_story_model.story_number.ToString();

        for (int i = 0;i < current_story_model.options.Length; i++)
        {
            button_way_text[i].text = current_story_model.options[i].button_text;
        }
    }

    public void Reset_show()            //사용된 Component 초기화
    {
        text_component.text = "";

        for (int i = 0;i < button_way.Length; i++)
        {
            button_way[i].gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        for (int i = 0; i < button_way.Length; i++)
        {
            int way_index = i;      //클로저 (Closure) 문제를 해결 하기 위해서
            //클로저 문제 -> 람다식 또는 익명 함수가 외부 변수를 캡쳐할 때 발생하는 문제
            button_way[i].onClick.AddListener(() => On_way_click(way_index));       //()=> On_way_click(i)로 썼을 때는 2 값만 계속 들어감
        }
        Co_show_text();
    }
    public void Co_show_text()
    {
        Story_model_init();
        Reset_show();
        StartCoroutine(Show_text());
    }

    IEnumerator Show_text()                         //앞에 선언한 모든 컴포넌트들을 Model과 함수를 통해서 진행
    {
        if(current_story_model.main_image != null)
        {
            //Texture2D를 Sprite로 변환
            Rect rect = new Rect(0, 0, current_story_model.main_image.width, current_story_model.main_image.height);    //모델의 높이와 너비
            Vector2 pivot = new Vector2(0.5f, 0.5f);        //스프라이트 축(중심) 지정
            Sprite sprite = Sprite.Create(current_story_model.main_image, rect, pivot);

            //Sprite 변환된 이미지를 컴포넌트에 넣는다.
            image_component.sprite = sprite;
        }
        else
        {
            Debug.LogError("텍스쳐에 이상이 있다.");
        }

        for (int i = 0; i< full_text.Length; i++)
        {
            current_text = full_text.Substring(0, i);
            text_component.text = current_text;
            yield return new WaitForSeconds(delay);
        }

        for (int i = 0; i< current_story_model.options.Length ; i++)
        {
            button_way[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delay);

    }
}
