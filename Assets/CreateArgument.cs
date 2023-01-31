using UnityEngine;
using UnityEngine.Events;

public class CreateArgument : MonoBehaviour
{
    public GameObject argumentPanel;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Color highlightColour;

    private Color baseColour;

    private Collider2D collider;

    public UnityEvent onArgumentCreated;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver()
    {
        HighLight();
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = baseColour;
    }

    private void OnMouseDown()
    {
        argumentPanel.SetActive(true);
    }

    private void OnMouseUp()
    {
        TurnOnPannel();
    }

    public void HighLight()
    {
        baseColour = spriteRenderer.color;
        spriteRenderer.color = highlightColour;
    }

    public void TurnOnPannel()
    {
        spriteRenderer.color = baseColour;
    }

    public void CloseButton()
    {
        onArgumentCreated.Invoke();
        argumentPanel.SetActive(false);
    }

    public void Disable(bool enabled)
    {
        collider.enabled = !enabled;
    }
}
