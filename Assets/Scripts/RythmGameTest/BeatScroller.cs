using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo;

    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        //how fast it's moving per second. How many units it's moving is our beatTempo/ by 60
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            //Starting the game with any key press
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }else{
                transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            }
        }
    }
}
