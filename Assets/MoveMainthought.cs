using System.Collections;
using UnityEngine;

public class MoveMainthought : MonoBehaviour
{
    public Vector3 currentPosition;
    public Vector3 newPosition;

    public float nextPosition = 5.5f;
    public float duration = 1;
    public bool hasMoved;

    private void Start()
    {
        currentPosition = transform.position;
    }

    public void OperateMainthought()
    {
        if (!hasMoved)
        {
            hasMoved = true;
            Vector3 moveToPosition = currentPosition + newPosition;
            StartCoroutine(MoveMainThought(moveToPosition));
        }
    }

    private IEnumerator MoveMainThought(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        currentPosition = targetPosition;
        hasMoved = false;
    }
}
