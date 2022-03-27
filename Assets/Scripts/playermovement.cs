
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playermovement : MonoBehaviour
{
    //��������
    public float movespeed;
    public Rigidbody2D rb;
    public Camera cam;

    public GameObject gr; //������ �� ������ Grab

    //����� ����� ����
    public GameObject deathScreen;
    public Text scoreEnd;
    public Text bestScoreEnd;
    public int score;
    private int bScore;
    public GrabMove grab;

    //public Joystick joystick;

    //����� ��� ��
    [SerializeField] private int health = 3;
    private int maxHealth;
    [SerializeField] private Image[] healthImage;
    [SerializeField] private Sprite[] healthSprite;

    bool objInHand = true; //���� �� � "����" ������ ��� ���

    //�������. �� ����� ��� ��?
    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        maxHealth = health;
        deathScreen.SetActive(false);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //movement.x = joystick.Horizontal;
        //movement.y = joystick.Vertical;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && objInHand == true) //���� ������ ��� � ���� � ���� ���� ������
        {
            gr.GetComponent<GrabMove>().Shoot(); //���������� ������� �� ������� Grab (������ GrabMove)
            objInHand = false; //����� �������� � ����� ������ ���
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); //��� �����-�� �������. ���������� �� ����� �� �����

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grab" && health > 0)
        {
            health -= 1;
            for (int i = 0; i < maxHealth; i++)
            {
                if (i < health)
                    healthImage[i].sprite = healthSprite[0];
                else
                    healthImage[i].sprite = healthSprite[1];
            }
            score = grab.score;
            PlayerPrefs.SetInt("score", score);
            bScore = PlayerPrefs.GetInt("bscore");
            if (bScore < score)
                PlayerPrefs.SetInt("bscore", score);
        }
        if (health < 1)
        {
            deathScreen.SetActive(true);
            scoreEnd.text = "Score: " +  score.ToString();
            bestScoreEnd.text = "Best score: " + bScore.ToString();
        }
    }
}
