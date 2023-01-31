using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public GameObject bullet;

    public float bulletSpeed;

    public GameObject mainThought;

    public Transform gunPositionPlayer;
    public Transform gunPositionEnemy;

    public LineRenderer linePlayer;
    public LineRenderer lineEnemy;

    public SpringJoint2D spring;

    public bool hasShot;
    public bool hasHit;
    private GameObject bulletInstance;

    private void Start()
    {
        linePlayer.enabled = false;
        lineEnemy.enabled = false;
        spring.enabled = false;
        hasShot = false;
        hasHit = false;
    }

    private void Update()
    {
        if (mainThought == null)
        {
            return;
        }

        linePlayer.SetPosition(1, gunPositionPlayer.position);

        if (!hasHit && bulletInstance != null)
        {
            linePlayer.SetPosition(0, bulletInstance.transform.position);
        }
        else
        {
            linePlayer.SetPosition(0, mainThought.transform.position);
        }
    }

    public void Shoot()
    {
        bulletInstance = Instantiate(bullet, gunPositionPlayer.position, Quaternion.identity);

        bulletInstance.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
        linePlayer.enabled = true;

        hasShot = true;
        hasHit = false;
    }

    public void SetLinePositionPlayer()
    {
        if (!hasShot)
        {
            return;
        }

        linePlayer.SetPosition(0, gunPositionPlayer.position);
        linePlayer.SetPosition(1, mainThought.transform.position);
    }

    public void SetLinePositionEnemy()
    {
        lineEnemy.SetPosition(0, gunPositionEnemy.position);
        lineEnemy.SetPosition(1, mainThought.transform.position);
    }

    public void TargetHit(GameObject hit)
    {
        hasHit = true;
        mainThought = hit;
        lineEnemy.enabled = true;
    }

    public void Release()
    {
        hasShot = false;
        hasHit = false;
        linePlayer.enabled = false;
        lineEnemy.enabled = false;
        mainThought = null;
    }
}
