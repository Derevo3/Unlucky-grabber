using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float dumping;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool isleft;
    private Transform player;
    private int lastX;

    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float upperLimit;
    [SerializeField]
    float bottomLimit;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(isleft);
    }

    public void  FindPlayer(bool playerIsLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft)
            transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        else
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }

    void Update()
    {
        if (player)
        {
            int currentX = Mathf.RoundToInt(player.position.x);
            if (currentX > lastX)
                isleft = false;
            else
                if (currentX < lastX)
                    isleft = true;
            lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target;
            if (isleft)
                target = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
            else
                target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }

        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
            transform.position.z
            );
    }
}
