using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Story_system : MonoBehaviour
{
    public static Story_system instance;            //������ �̱���ȭ

    public Story_model current_story_model;

    public enum TEXTSYSTEM
    {
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                  //�� ���ڰ� ��Ÿ���µ� �ɸ��� �ð�
    public string full_text;                    //��ü ǥ���� �ؽ�Ʈ
    string current_text = "";                   //������� ǥ�õ� �ؽ�Ʈ

    public Text text_component;                 //Text ������Ʈ
    public Text story_index;                    //���� ���丮 ��ȣ

    public Image image_component;               //������ �̹��� ������Ʈ

    public Button[] button_way = new Button[3];
    public Text[] button_way_text = new Text[3];
    private void Awake()
    {
        instance = this;
    }

    public void On_way_click(int index)         //��ư�� ������ �� �ش� ������ index�� �޾ƿ´�.
    {
        bool Check_event_type_none = false;     //�⺻���� NONE�� ���� �����̶�� �Ǵ�
        Story_model play_story_model = current_story_model;

        if (play_story_model.options[index].event_check.event_type == Story_model.Event_check.Event_type.NONE)
        {   
            for (int i = 0; i < play_story_model.options[index].event_check.sucess_result.Length; i++)
            {
                //FIX : �̰� ���߿� ����
                Debug.Log(i);
                Game_system.instance.Apply_choice(current_story_model.options[index].event_check.sucess_result[i]); 
                Check_event_type_none = true;
            }
        }

        bool check_value = false;
    }
    
    public void Story_model_init()              //���丮 �� init
    {
        full_text = current_story_model.story_text;

        story_index.text = current_story_model.story_number.ToString();

        for (int i = 0;i < current_story_model.options.Length; i++)
        {
            button_way_text[i].text = current_story_model.options[i].button_text;
        }
    }

    public void Reset_show()            //���� Component �ʱ�ȭ
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
            int way_index = i;      //Ŭ���� (Closure) ������ �ذ� �ϱ� ���ؼ�
            //Ŭ���� ���� -> ���ٽ� �Ǵ� �͸� �Լ��� �ܺ� ������ ĸ���� �� �߻��ϴ� ����
            button_way[i].onClick.AddListener(() => On_way_click(way_index));       //()=> On_way_click(i)�� ���� ���� 2 ���� ��� ��
        }
        Co_show_text();
    }
    public void Co_show_text()
    {
        Story_model_init();
        Reset_show();
        StartCoroutine(Show_text());
    }

    IEnumerator Show_text()                         //�տ� ������ ��� ������Ʈ���� Model�� �Լ��� ���ؼ� ����
    {
        if(current_story_model.main_image != null)
        {
            //Texture2D�� Sprite�� ��ȯ
            Rect rect = new Rect(0, 0, current_story_model.main_image.width, current_story_model.main_image.height);    //���� ���̿� �ʺ�
            Vector2 pivot = new Vector2(0.5f, 0.5f);        //��������Ʈ ��(�߽�) ����
            Sprite sprite = Sprite.Create(current_story_model.main_image, rect, pivot);

            //Sprite ��ȯ�� �̹����� ������Ʈ�� �ִ´�.
            image_component.sprite = sprite;
        }
        else
        {
            Debug.LogError("�ؽ��Ŀ� �̻��� �ִ�.");
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
