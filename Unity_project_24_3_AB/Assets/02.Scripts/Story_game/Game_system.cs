using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;



public class Game_system_editor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}
public class Game_system : MonoBehaviour
{
    public static Game_system instance;

    private void Awake()
    {
        instance = this;
    }

    public enum GAMESTATE
    {
        STORYSHOW,
        WAITSELECT,
        STORYEND
    }

    public Stats stats;
    public GAMESTATE current_state;
    public int current_story_index = 1;
    public Story_model[] story_models;

    public void Start()
    {
        Change_state(GAMESTATE.STORYSHOW);
    }
    public void Change_stats(Story_model.Result result)     //���� ���� ����(���丮 ���� �����)
    {
        if (result.stats.hp_point > 0) stats.hp_point += result.stats.hp_point;
        if (result.stats.sp_point > 0) stats.sp_point += result.stats.sp_point;

        if (result.stats.current_hp_point > 0) stats.current_hp_point += result.stats.current_hp_point;
        if (result.stats.current_sp_point > 0) stats.current_sp_point += result.stats.current_sp_point;
        if (result.stats.current_xp_point > 0) stats.current_xp_point += result.stats.current_xp_point;

        if (result.stats.strength > 0) stats.strength += result.stats.strength;
        if (result.stats.dexterity > 0) stats.dexterity += result.stats.dexterity;
        if (result.stats.consitution > 0) stats.consitution += result.stats.consitution;
        if (result.stats.wisdom > 0) stats.wisdom += result.stats.wisdom;
        if (result.stats.Intelligence > 0) stats.Intelligence += result.stats.Intelligence;
        if (result.stats.charisma > 0) stats.charisma += result.stats.charisma;
    }
    public void Change_state(GAMESTATE temp)             //���� ���� ���� �Լ� �߰�
    {
        current_state = temp;

        if(current_state == GAMESTATE.STORYSHOW)        
        {
            Story_show(current_story_index);        //���丮 ���
        }
    }
    public void Apply_choice(Story_model.Result result)
    {
        switch (result.result_type) 
        {
            case Story_model.Result.Result_type.ChangeHp:
                stats.current_hp_point += result.value;
                Change_stats(result);
                break;
            case Story_model.Result.Result_type.AddExperience:
                stats.current_xp_point += result.value;
                Change_stats(result);
                break;
            case Story_model.Result.Result_type.GoToNextStory:
                current_story_index = result.value;
                Change_state(GAMESTATE.STORYSHOW);
                Change_stats(result);
                break;
            case Story_model.Result.Result_type.GoToRandomStory:
                Random_story();
                Change_state(GAMESTATE.STORYSHOW);
                Change_stats(result);
                break;
            default:
                Debug.LogError("Unknown type");
                break;
        }
    }

#if UNITY_EDITOR
    [ContextMenu("Reset Story Models")]
    public void Reset_story_models()
    {
        story_models = Resources.LoadAll<Story_model>("");      //Resource ���� �Ʒ� ��� StoryModel �� �ҷ� �´�. 
    }
#endif

    public void Story_show(int number)
    {
        Story_model temp_story_models = Find_story_model(number);

        Story_system.instance.current_story_model = temp_story_models;
        Story_system.instance.Co_show_text();
    }

    Story_model Find_story_model(int number)
    {
        Story_model temp_story_models = null;
        for (int i = 0; i < story_models.Length; i++)           //foir ������ story_model�� �˻��Ͽ� Number�� ���� ���丮 ��ȣ�� ���丮 ����
        {
            if (story_models[i].story_number == number)
            {
                temp_story_models = story_models[i];
                break;
            }
        }
        return temp_story_models;
    }

    Story_model Random_story()
    {
        Story_model temp_story_models = null;

        List<Story_model> story_model_list = new List<Story_model>();       //for ������ StroyModel �� �˻��Ͽ� Main�� ��츸 ����.

        for (int i = 0;i < story_models.Length; i++)
        {
            if (story_models[i].story_type == Story_model.STORYTYPE.MAIN)
            {
                story_model_list.Add(story_models[i]);
            }
        }

        temp_story_models = story_model_list[Random.Range(0, story_model_list.Count)];  //����Ʈ���� �������� �ϳ� ����
        current_story_index = temp_story_models.story_number;
        return temp_story_models;
    }
}
