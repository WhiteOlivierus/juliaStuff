using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;

    private Vector3 startPostition;

    private void Start()
    {
        startPostition = transform.position;
        beatTempo /= 60f;
    }

    private void Update()
    {
        if (!hasStarted)
        {
            transform.position = startPostition;
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
