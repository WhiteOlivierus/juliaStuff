using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public float normalThreshold = 0.25f;
    public float goodThreshold = 0.05f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > normalThreshold)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    
                }else if (Mathf.Abs(transform.position.y) > goodThreshold){
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    
                }
                else{
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();
                    
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.activeInHierarchy)
        {
            if (other.tag == "Activator")
            {
                canBePressed = false;

                GameManager.instance.NoteMissed();
                
            }
        }
    }
}

