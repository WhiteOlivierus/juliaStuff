using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.UI;
 
public class NewThoughts : MonoBehaviour
{
    public GameObject thoughtsPanel;
    public GameObject controlPanel;
    public GameObject mainThought;
    public GameObject secondaryThoughts;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Color highlightColour; 

    private Color baseColour;

    // Start is called before the first frame update
    private void Start()
    {
        thoughtsPanel.SetActive (false);
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//  What happens when you open one of the thoughts
    public void OnMouseUp()
    {
        //Check if the new thought bubble is clicked
        //Open popup window
        thoughtsPanel.SetActive (true);
        //close the controller panel
        controlPanel.SetActive (false);
        //Stop game time
        //Time.timeScale = 0f;
        spriteRenderer.color = baseColour;
    }

    public void OnMouseDown()
    {
        baseColour = spriteRenderer.color;
        spriteRenderer.color = highlightColour;
    }

    public void CloseButton()
    {
        thoughtsPanel.SetActive (false);
        //close the controller panel
        controlPanel.SetActive (true);
    }
}
