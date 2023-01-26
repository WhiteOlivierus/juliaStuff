using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    //rotation Z
    // public float min_Z = 12f;
    // public float max_Z = -12f;
    // public float rotateSpeed = 5f;
    public GameObject bullet;

    public float bulletSpeed;

    public GameObject mainThought;

    public Transform gunPosition;

    public LineRenderer line;

    public SpringJoint2D spring;

    private void Start()
    {
        line.enabled = false;
        spring.enabled = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(mainThought != null)
        {
            line.SetPosition(0, gunPosition.position);
            line.SetPosition(1, mainThought.transform.position);
        }

        if(Input.GetMouseButtonDown(1))
        {
            Release();
        }
    }

    private void Shoot()
    {
       GameObject bulletInstance = Instantiate(bullet, gunPosition.position, Quaternion.identity);

       bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
    }

    public void TargetHit(GameObject hit)
    {
        mainThought = hit;
        line.enabled = true;
        spring.enabled = true;
        spring.connectedBody = mainThought.GetComponent<Rigidbody2D>();
    }
   
   void Release()
   {
        line.enabled = false;
        spring.enabled = false;
        //mainThought.set kinematic. Houdt een coroutine bij die checked of die al bij het einde is gekomen.
        mainThought = null;
   }
}
