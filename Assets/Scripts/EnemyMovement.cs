using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;

    bool active = true;
    bool moveingRight;

    void Start()
    {
        
    }

    void Update()
    {
        if (active == true)
        {
            Chill();
        }
    }

    void Chill() //��������� �����
    {
        if (transform.position.x > point.position.x + positionOfPatrol) //���� ���������� ������� ������ ���������� �� ����� ������� �� ���� �������, �� ������� � ������� ����
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol) //�����, �� ����, ������� �� ��
        {
            moveingRight = true;
        }

        if (moveingRight) //������� ����-����
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    
    /*void ActiveOff()
    {
        active = false;
        //����� ���� ����� ������� �������� � ����, �������� ����� Joint
        //������ ��������� ��� �������, ������� � ������ ����
        //�� � �������� ������� ������, ���� ������ � ��������
    }*/
}
