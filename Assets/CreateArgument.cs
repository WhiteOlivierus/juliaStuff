using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArgument : MonoBehaviour
{
    public GameObject argumentPanel;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color highlightColour;
    public bool canCreateArgument;
    public bool argumentCreated;
    private Color baseColour;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    private void Start()
    {
        //argumentPanel.SetActive(false);
        canCreateArgument = true;
        argumentCreated = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            argumentCreated = false;
            if (canCreateArgument)
            {
                HighLight();
                argumentPanel.SetActive(true);
            }
        }
        if (Input.GetKeyUp(keyToPress))
        {
            turnOnPannel();
        }

        if(argumentCreated)
        {
            argumentPanel.SetActive(false);
        }

    }

    public void HighLight()
    {
        baseColour = spriteRenderer.color;
        spriteRenderer.color = highlightColour;
    }

    //  What happens when you open one of the thoughts
    public void turnOnPannel()
    {
        //Check if the new thought bubble is clicked
        //Open popup window
        //argumentPanel.SetActive(true);
        //close the controller panel
        //Stop game time
        //Time.timeScale = 0f;
        spriteRenderer.color = baseColour;
        canCreateArgument = false;
    } 

    public void CloseButton()
    {
        //argumentPanel.SetActive(false);
        canCreateArgument = true;
        argumentCreated = true;
        //close the controller panel
    }
}
