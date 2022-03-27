using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabMove : MonoBehaviour
{
    public Camera cam; //Только чтобы стрельнуть вначале (гениально)
    public Transform grabPoint; //Точка возврата граба
    public Rigidbody2D rb;

    //Толчок от игрока и к игроку соответственно
    public float grabForce;
    public float grabForce2;

    //Штуки для Счёта
    public Text textScore;
    public int score = 0;

    //Ограничение движения граба
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float upperLimit;
    [SerializeField]
    float bottomLimit;

    // bool objBack = false; //Состояние возвращения, хз нужно ли оно (пока что нет)

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3 //Ограничение движения граба
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }

    void OnCollisionEnter2D(Collision2D col) //Условие коллыжына
    {
        Vector2 grabPoint2 = grabPoint.position - transform.position; //Рассчёт точки возврата
        rb.AddForce(grabPoint2 * grabForce2, ForceMode2D.Impulse); //Толчок граба к игроку
        score++;
        if (col.gameObject.tag == "Player")
            score = 0;
        textScore.text = "Score: " + score.ToString();
    }

    public void Shoot() //Собственно выстрел
    {
        Vector2 mousePos = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rb.AddForce(mousePos * grabForce, ForceMode2D.Impulse);
    }

}