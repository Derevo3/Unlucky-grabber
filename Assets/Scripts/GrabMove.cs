using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabMove : MonoBehaviour
{
    public Camera cam; //������ ����� ���������� ������� (���������)
    public Transform grabPoint; //����� �������� �����
    public Rigidbody2D rb;

    //������ �� ������ � � ������ ��������������
    public float grabForce;
    public float grabForce2;

    //����� ��� �����
    public Text textScore;
    public int score = 0;

    //����������� �������� �����
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float upperLimit;
    [SerializeField]
    float bottomLimit;

    // bool objBack = false; //��������� �����������, �� ����� �� ��� (���� ��� ���)

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3 //����������� �������� �����
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }

    void OnCollisionEnter2D(Collision2D col) //������� ���������
    {
        Vector2 grabPoint2 = grabPoint.position - transform.position; //������� ����� ��������
        rb.AddForce(grabPoint2 * grabForce2, ForceMode2D.Impulse); //������ ����� � ������
        score++;
        if (col.gameObject.tag == "Player")
            score = 0;
        textScore.text = "Score: " + score.ToString();
    }

    public void Shoot() //���������� �������
    {
        Vector2 mousePos = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rb.AddForce(mousePos * grabForce, ForceMode2D.Impulse);
    }

}