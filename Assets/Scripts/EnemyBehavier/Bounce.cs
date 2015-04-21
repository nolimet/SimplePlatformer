using UnityEngine;
using System.Collections;

namespace EnemyBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bounce : MonoBehaviour
    {

        Rigidbody2D RB2;
        public Vector2 speed;
        int direction = 1;
        void Start()
        {
            RB2 = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            Vector2 dir = Vector2.zero;
            if (direction > 0 && RB2.velocity.x < 0)
                dir = speed * direction * 8f;
            else if (direction < 0 && RB2.velocity.x > 0)
                dir = speed * direction * 8f;
            else
                dir = speed * direction;
            RB2.AddForce(dir);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != Tags.turnAround)
                return;

            //RB2.velocity = Vector2.zero;
            direction *= -1;

            if (direction > 0)
                transform.rotation = Quaternion.Euler(0, 180, 0);
            else
                transform.rotation = Quaternion.identity;

            RB2.velocity = new Vector2(RB2.velocity.x, 0);
        }
    }
}