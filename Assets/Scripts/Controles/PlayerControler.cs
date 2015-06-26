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


    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 force = Vector2.zero;
        Vector2 vol = RB2.velocity;
        float horSpeed = RB2.velocity.x;
        if (horSpeed < 0)
            horSpeed *= -1;

        if (Input.GetAxis(Axis.GetAxis(Axis.AxisType.Horizontal)) != 0)
        {
            if (horSpeed < 7)
            force.x = speed * Input.GetAxis(Axis.GetAxis(Axis.AxisType.Horizontal));
        }
        else if (horSpeed > 0.1f)
            vol.x *= 0.8f;
            

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -0.321f, 0), new Vector2(0, -1), 0.1f);
            if (hit)
                force.y = 845f;
        }
        RB2.velocity = vol;
        RB2.AddForce(force);
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.SendMessage("PickUp",this.gameObject ,SendMessageOptions.DontRequireReceiver);
    }
}
