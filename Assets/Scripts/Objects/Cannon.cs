using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cannon : MonoBehaviour {

    List<Transform> targets = new List<Transform>();
    public Transform targetPosition;
    public float speed = 1f;
    Vector3 dir;

    void Awake()
    {
        
    }
	// Use this for initialization
	void Start () {

        dir = transform.position - targetPosition.position;
        dir.Normalize();
        dir *= -1;
        //transform.LookAt(targetPosition);
        //Vector3 tmp = transform.localRotation.eulerAngles;
        //transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0) + tmp);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
            fire();
    }

    void fire()
    {
        for (int i = targets.Count - 1; i >= 0; i--) 
        {
            if (Vector3.Distance(targets[i].position, targetPosition.position) > 0.75f)
            {
                targets[i].Translate(dir * speed * Time.deltaTime );
                targets[i].GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                targets[i].GetComponent<Rigidbody2D>().isKinematic = false;
                targets.Remove(targets[i]);
            }
        }
    }

    public void PickUp(GameObject other)
    {
        if (other.tag == Tags.player)
            if (!targets.Contains(other.transform))
            {
                targets.Add(other.transform);
                other.transform.position = transform.position;
            }
    }


}
