using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;

    private void Start()
    {
        target = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
