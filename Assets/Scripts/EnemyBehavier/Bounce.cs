using UnityEngine;
using System.Collections;

namespace EnemyBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bounce : MonoBehaviour
    {

        Rigidbody2D RB2;
        public Vector2 speed;
        public bool ConstSpeed;
        public float forceMult = 1f;
        int direction = 1;
        void Start()
        {
            RB2 = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (!ConstSpeed)
            {
                Vector2 dir = Vector2.zero;
                if (direction > 0 && RB2.velocity.x < 0)
                    dir = speed * direction * 8f *forceMult;
                else if (direction < 0 && RB2.velocity.x > 0)
                    dir = speed * direction * 8f * forceMult;
                else
                    dir = speed * direction * forceMult;
                RB2.AddForce(dir);
            }
            else
            {
                RB2.velocity = new Vector2((speed.x * direction), RB2.velocity.y);
            }
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

        }
    }
}