using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour
{
    public Rigidbody2D Player;
    public Rect bound = new Rect();
    public float MoveTime = 0.03f;
    Vector3 newPos = Vector3.zero;

    float timerTick = 0;
    float timerY = 0;
    void Update()
    {
        if (timerTick <= 0)
        {
            SetPosX();
            timerTick = MoveTime;
        }

        if (timerY <= 0)
        {
            SetPosY();
            timerY = MoveTime * 3f; 
        }

        Move();

        timerTick -= Time.deltaTime;
        timerY -= Time.deltaTime;
    }

    void Move()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, Mathf.Clamp(timerTick, 0, MoveTime));
    }

    void SetPosY()
    {
        Vector3 PlayerMove = ((Vector3)Player.velocity / 3f);

        if (PlayerMove.y > bound.height)
            PlayerMove.y = bound.height;
        if (PlayerMove.y < bound.y)
            PlayerMove.y = bound.y;

        newPos.z = -5f;
        newPos.y = PlayerMove.y;
    }

    void SetPosX()
    {
        Vector3 PlayerMove = ((Vector3)Player.velocity / 3f);

        if (PlayerMove.x > bound.width)
            PlayerMove.x = bound.width;
        if (PlayerMove.x < bound.x)
            PlayerMove.x = bound.x;

        newPos.z = -5f;
        newPos.x = PlayerMove.x;
        
    }
}
