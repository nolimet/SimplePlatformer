using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControler : MonoBehaviour
{

    Rigidbody2D RB2;
    public float speed;

    void Start()
    {
        RB2 = GetComponent<Rigidbody2D>();
        transform.SetAsLastSibling();
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 force = Vector2.zero;
        float horSpeed = RB2.velocity.x;
        if (horSpeed < 0)
            horSpeed *= -1;

        if (horSpeed < 10)
            force.x = speed * Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.6f, 0), new Vector2(0, -1), 0.2f);
            if (hit)
                force.y = 400f;
        }
        RB2.AddForce(force);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("Action", SendMessageOptions.DontRequireReceiver);
    }


}
