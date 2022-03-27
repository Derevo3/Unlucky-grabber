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

    void Chill() //Состояние покоя
    {
        if (transform.position.x > point.position.x + positionOfPatrol) //Если координата объекта больше расстояния от точки патруля до края патруля, то поворот в сторону фолс
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol) //Иначе, не тупи, логично же всё
        {
            moveingRight = true;
        }

        if (moveingRight) //Поворот туда-сюда
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
        //Здесь надо будет бахнуть привязку к хуку, наверное через Joint
        //Заодно выключить все функции, которые я повешу сюда
        //Ну и повесить функции всякие, типа хотьбы и стрельбы
    }*/
}
