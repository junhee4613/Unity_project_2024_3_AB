using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;        //������ �а� ���� ���ؼ�
using System.Xml.Serialization;     //XML�� ����ϱ� ���ؼ�


[System.Serializable]
public class Player_data        //������ ������ ����
{
    public string player_name;
    public int player_level;
    public List<string> items = new List<string>();
}
public class Ex_XML_data_manager : MonoBehaviour
{
    string file_path;

    private void Start()
    {
        file_path = Application.persistentDataPath + "/player_data.xml";            //���� ���
        Debug.Log(file_path);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            Player_data player_data = new Player_data();                //�÷��̾� �����͸� �����Ͽ�
            player_data.player_name = "�÷��̾� 1";                     //�����͸� �����ش�.
            player_data.player_level = 1;
            player_data.items.Add("��1");
            player_data.items.Add("����1");                               
            Save_data(player_data);                                     //�ش� ������ XML ���Ϸ� �����Ѵ�. ���� ������ �ø���. �� ������ �޸� �����ϸ� �ո��� �����̴�.
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Player_data player_data = new Player_data();                //���� �÷��̾� ������ ��ü

            player_data = Load_data();                                  //���Ͽ��� �ε��Ѵ�.

            Debug.Log(player_data.player_name);                         //�ε�� �����͸� ����Ѵ�.
            Debug.Log(player_data.player_level);
            for (int i = 0; i < player_data.items.Count; i++) 
            {
                Debug.Log(player_data.items[i]);
            }
        }
    }
    void Save_data(Player_data data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Player_data));      //XML ����ȭ
        FileStream stream = new FileStream(file_path, FileMode.Create);         //���� ���� ��� ����
        serializer.Serialize(stream, data);                                     //���Ͽ� �����͸� �����Ѵ�.
        stream.Close();                                                         //�ݵ�� Close ����ߵȴ�.
    }
    Player_data Load_data()
    {
        if (File.Exists(file_path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Player_data));
            FileStream stream = new FileStream(file_path, FileMode.Open);               //���� �б� ���� ����
            Player_data data = (Player_data)serializer.Deserialize(stream);             //����ȭ�� ���� Ŭ������ ����
            stream.Close();                                                             //������ �ݴ´�.
            return data;
        }
        else
        {
            return null;
        }
    }
}
