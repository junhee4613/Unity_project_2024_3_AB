using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExAccessControl : MonoBehaviour
{
    //public���� ����� ������ �ٸ� ��ũ��Ʈ���� ���� ���� ����
    public int publicValue;

    //private���� ����� ������ ���� Ŭ���� �������� ���� ����
    private int privateValue;

    //protected�� ����� ������ ���� Ŭ���� �� �Ļ� Ŭ�������� ���� ����
    protected int protectedValue;

    //internal�� ����� ������ ���� �����( ������Ʈ �� �ٸ� ��ũ��Ʈ)������ ���� rksmd
    internal int internalValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
