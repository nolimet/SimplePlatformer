using UnityEngine;
using System.Collections;

namespace EnemyBehaviour
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Hover : MonoBehaviour
    {
        public float height = 1f;
        public float margine = 0.1f;
        public Vector2 offSet;
        public bool Debugline;

        readonly Vector2 dir = new Vector2(0, -1);

        Rigidbody2D RB2;

        void Start()
        {
            RB2 = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + offSet, dir);

            if (hit && hit.collider.tag != Tags.turnAround) 
            {
                if (hit.distance < height - margine)
                    RB2.AddForce(new Vector2(0, 4 + Mathf.Clamp(hit.distance, 0, 10)));
                else if (hit.distance > height + margine)
                    RB2.AddForce(new Vector2(0, -4 - Mathf.Clamp(hit.distance, 0, 10)));
                else if (RB2.velocity.y != 0)
                {
                    RB2.velocity = new Vector2(RB2.velocity.x,RB2.velocity.y / 1.7f);
                    if (RB2.velocity.y < 0.05f && RB2.velocity.y > -0.05f)
                        RB2.velocity = new Vector2(RB2.velocity.x, 0);
                }

                if (Debugline)
                    Debug.DrawLine(transform.position, hit.point, Color.red, 0.1f);
            }
        }
    }
}