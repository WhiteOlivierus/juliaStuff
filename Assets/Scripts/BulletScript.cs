using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GrapplingHook grappler;

    public void Start()
    {
        grappler = GameObject.FindGameObjectWithTag("Grappler").GetComponent<GrapplingHook>();
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.gameObject.CompareTag("MainThought"))
        {
            return;
        }

        grappler.TargetHit(collider.gameObject);
        Destroy(gameObject);
    }
}
