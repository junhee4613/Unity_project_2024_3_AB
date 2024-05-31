using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Character_state         //ĳ���� ����
{
    Idle,
    WalkingToShelf,
    PickingItem,
    WalkingToCounter,
    PlacingItem
}
public class Timer      //Ŀ���� Ÿ�̸� Ŭ����
{
    float time_remaining;       //Ÿ�̸� float

    public void Set(float time)     //�ð� ����
    {
        time_remaining = time;
    }
    public void Update(float deltaTime)     //������Ʈ ����ȭ
    {
        if(time_remaining > 0)
        {
            time_remaining -= deltaTime;
        }
    }
    public bool IsFinished()        //���� üũ
    {
        return time_remaining <= 0;
    }
}

public class Character_FSM : MonoBehaviour
{
    public Character_state current_state;     //���� ĳ���� ����
    Timer timer;                            //Ÿ�̸� ����

    public NavMeshAgent agent;              //������Ʈ ���̱�
    public Transform target;

    public Transform Counter;
    public List<GameObject> target_pos = new List<GameObject>();

    static int Next_priority = 0;               //���� ������Ʈ �� �켱 ����
    static readonly object priority_lock = new object();        //�켱 ���� �Ҵ��� ���� ����ȭ ��ü

    public bool is_move_done = false;                   //���� �Ǻ��� Bool

    public List<GameObject> my_box = new List<GameObject>();

    public int boxes_to_pick = 5;
    int boxes_picked = 0;

    void Assign_priority()
    {
        lock (priority_lock)            //����ȭ ����� ����Ͽ� �켱 ������ �Ҵ�
        {
            agent.avoidancePriority = Next_priority;
            Next_priority = (Next_priority + 1) % 100;                  //NavMeshAgent �켱 ���� ������ 0 ~ 99
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer();                //Ÿ�̸� �Ҵ�
        current_state = Character_state.Idle;   //ĳ���� ���� ����
    }

    // Update is called once per frame
    void Update()
    {
        timer.Update(Time.deltaTime);               //Ÿ�̸� ������Ʈ�� ����ȭ

        if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
            {
                is_move_done = true;
            }
        }

        switch (current_state)
        {
            case Character_state.Idle:
                Idle();
                break;
            case Character_state.WalkingToShelf:
                Walking_to_shelf();
                break;
            case Character_state.PickingItem:
                Picking_item();
                break;
            case Character_state.WalkingToCounter:
                Walking_to_counter();
                break;
            case Character_state.PlacingItem:
                Placing_item();
                break;

        }
    }
    void Move_to_target()
    {
        is_move_done = false;

        if(target != null)
        {
            agent.SetDestination(target.position);
        }
    }
    void Change_state(Character_state next_state, float wait_time = 0.0f)       //FSM Stat ��ȯ �� ���� ������Ʈ�� Ÿ�̸� �ð� ����
    {
        current_state = next_state;
        timer.Set(wait_time);
    }
    void Idle()
    {
        if (timer.IsFinished())
        {
            target = target_pos[Random.Range(0, target_pos.Count)].transform;
            Move_to_target();
            Change_state(Character_state.WalkingToShelf, 2.0f);
        }
    }
    void Walking_to_shelf()
    {
        if (timer.IsFinished() && is_move_done)
        {
            Debug.Log("d");
            Change_state(Character_state.PickingItem, 2.0f);
            boxes_picked = 0;
        }
    }
    void Picking_item()
    {
        if (timer.IsFinished())
        {
            Debug.Log("d");
            if(boxes_picked < boxes_to_pick)
            {
            Debug.Log("d");
                GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                my_box.Add(box);
                box.transform.parent = gameObject.transform;
                box.transform.localEulerAngles = Vector3.zero;
                box.transform.localPosition = new Vector3(0, boxes_picked * 2f, 0);

                boxes_picked++;
                timer.Set(0.5f);
            }
            else
            {
                target = Counter;
                Move_to_target();
                Change_state(Character_state.WalkingToCounter, 2.0f);
            }
        }
    }
    void Walking_to_counter()
    {
        if (timer.IsFinished() && is_move_done)
        {
            Change_state(Character_state.PlacingItem, 2.0f);
        }
    }
    void Placing_item()
    {
        if (timer.IsFinished())
        {
            if(my_box.Count != 0)
            {
                my_box[0].transform.position = Counter.transform.position;
                my_box[0].transform.parent = Counter.transform;
                my_box.RemoveAt(0); 
                timer.Set(0.1f);
            }
            else
            {
                Change_state(Character_state.Idle, 2.0f);
            }
        }
    }
}

