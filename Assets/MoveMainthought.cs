using System.Collections;
using System.Collections.Generic;
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
        StopAllCoroutines();
        if (!hasMoved)
        {
            Vector3 moveToPosition = currentPosition + newPosition;
            StartCoroutine(MoveMainThought(moveToPosition));
        }
        else
        {
            StartCoroutine(MoveMainThought(currentPosition));
        }
        hasMoved = !hasMoved;
    }

    IEnumerator MoveMainThought(Vector3 targetPosition)
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
    }

/*     public void dontMove()
     {

     }

     public void moveDownOke()
     {

     }

     public void moveDownGood()
     {

     }

     public void moveDownPerfect()
     {

     }

     public void moveUpOke()
     {

     }

     public void moveUpGood()
     {

     }

     public void moveUpPerfect()
     {

     }*/
}
