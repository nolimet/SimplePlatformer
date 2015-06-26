using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class BasePickup : MonoBehaviour
{

    public virtual void PickUp(GameObject obj)
    {
        print("this is a Test");
    }
}
