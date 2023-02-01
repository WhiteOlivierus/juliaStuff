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

    public Transform gunPositionPlayer;
    public Transform gunPositionEnemy;
    
    public LineRenderer linePlayer;
    public LineRenderer lineEnemy;

    public SpringJoint2D spring;

    public bool hasShot;

    private void Start()
    {
        linePlayer.enabled = false;
        lineEnemy.enabled = false;
        spring.enabled = false;
        hasShot = false;
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/

        if (mainThought != null)
        {
            linePlayer.SetPosition(0, gunPositionPlayer.position);
            linePlayer.SetPosition(1, mainThought.transform.position);

            linePlayer.SetPosition(0, gunPositionPlayer.position);
            linePlayer.SetPosition(1, mainThought.transform.position);
        }

      /*  if (Input.GetMouseButtonDown(1))
        {
            Release();
        }*/

    }
    public void Shoot()
    {
       GameObject bulletInstance = Instantiate(bullet, gunPositionPlayer.position, Quaternion.identity);

       bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);

       hasShot = true;
    }

    public void SetLinePositionPlayer()
    {
        if (hasShot == true)
        {
            linePlayer.SetPosition(0, gunPositionPlayer.position);
            linePlayer.SetPosition(1, mainThought.transform.position);
        }
    }

    public void SetLinePositionEnemy()
    {
        lineEnemy.SetPosition(0, gunPositionEnemy.position);
        lineEnemy.SetPosition(1, mainThought.transform.position);
    }
    public void TargetHit(GameObject hit)
    {
        mainThought = hit;
        linePlayer.enabled = true;
        lineEnemy.enabled = true;
        /*spring.enabled = true;
        spring.connectedBody = mainThought.GetComponent<Rigidbody2D>();*/
    }
   
   public void Release()
   {
        linePlayer.enabled = false;
        lineEnemy.enabled = false;
        /*spring.enabled = false;*/
        //mainThought.set kinematic. Houdt een coroutine bij die checked of die al bij het einde is gekomen.
        mainThought = null;
   }
}
