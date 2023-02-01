using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    //public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Transform mainThought;


    // Start is called before the first frame update
    private void Start()
    {
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 thoughtPosition = mainThought.position;
            _lineRenderer.SetPosition(0, thoughtPosition);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = thoughtPosition;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
    }

   
}
