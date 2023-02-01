using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GrapplingHook grappler;

    // Start is called before the first frame update
    public void Start()
    {
        grappler = GameObject.FindGameObjectWithTag("Grappler").GetComponent<GrapplingHook>();
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MainThought")
        {
            grappler.TargetHit(collider.gameObject);
            Destroy(gameObject);
        }
        
    }
}
