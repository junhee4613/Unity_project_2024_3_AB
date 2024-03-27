using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;        //파일을 읽고 쓰기 위해서
using System.Xml.Serialization;     //XML을 사용하기 위해서


[System.Serializable]
public class Player_data        //저장할 데이터 선언
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
        file_path = Application.persistentDataPath + "/player_data.xml";            //실제 경로
        Debug.Log(file_path);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            Player_data player_data = new Player_data();                //플레이어 데이터를 생성하여
            player_data.player_name = "플레이어 1";                     //데이터를 정해준다.
            player_data.player_level = 1;
            player_data.items.Add("돌1");
            player_data.items.Add("바위1");                               
            Save_data(player_data);                                     //해당 내용을 XML 파일로 저장한다. 보통 서버에 올린다. 그 이유가 메모리 어택하면 뚫리기 때문이다.
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Player_data player_data = new Player_data();                //받을 플레이어 데이터 객체

            player_data = Load_data();                                  //파일에서 로딩한다.

            Debug.Log(player_data.player_name);                         //로드된 데이터를 출력한다.
            Debug.Log(player_data.player_level);
            for (int i = 0; i < player_data.items.Count; i++) 
            {
                Debug.Log(player_data.items[i]);
            }
        }
    }
    void Save_data(Player_data data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Player_data));      //XML 직렬화
        FileStream stream = new FileStream(file_path, FileMode.Create);         //파일 생성 모드 설정
        serializer.Serialize(stream, data);                                     //파일에 데이터를 저장한다.
        stream.Close();                                                         //반드시 Close 해줘야된다.
    }
    Player_data Load_data()
    {
        if (File.Exists(file_path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Player_data));
            FileStream stream = new FileStream(file_path, FileMode.Open);               //파일 읽기 모드로 설정
            Player_data data = (Player_data)serializer.Deserialize(stream);             //직렬화된 것을 클래스로 변경
            stream.Close();                                                             //파일을 닫는다.
            return data;
        }
        else
        {
            return null;
        }
    }
}
