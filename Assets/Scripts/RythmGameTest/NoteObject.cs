using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    public float normalThreshold = 0.25f;
    public float goodThreshold = 0.05f;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        if (!canBePressed)
        {
            return;
        }

        gameObject.SetActive(false);

        if (Mathf.Abs(transform.position.y) > normalThreshold)
        {
            Debug.Log("Hit");
            GameManager.instance.NormalHit();
        }
        else if (Mathf.Abs(transform.position.y) > goodThreshold)
        {
            Debug.Log("Good");
            GameManager.instance.GoodHit();
        }
        else
        {
            Debug.Log("Perfect");
            GameManager.instance.PerfectHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Activator"))
        {
            return;
        }

        canBePressed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }

        if (!other.CompareTag("Activator"))
        {
            return;
        }

        canBePressed = false;

        GameManager.instance.NoteMissed();
    }
}
