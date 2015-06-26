using UnityEngine;
using System.Collections;

public class floatfield : MonoBehaviour {

    public Vector2 Force,MaxSpeed;
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == Tags.player)
            if (other.gameObject.GetComponent<Rigidbody2D>())
                if ((MaxSpeed.x > 0 && other.gameObject.GetComponent<Rigidbody2D>().velocity.x < MaxSpeed.x) || (MaxSpeed.x < 0 && other.gameObject.GetComponent<Rigidbody2D>().velocity.x > MaxSpeed.x) || MaxSpeed.x == 0)
                    if ((MaxSpeed.y > 0 && other.gameObject.GetComponent<Rigidbody2D>().velocity.y < MaxSpeed.y) || (MaxSpeed.y < 0 && other.gameObject.GetComponent<Rigidbody2D>().velocity.y > MaxSpeed.y) || MaxSpeed.y == 0)
                        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Force);
    }
}
