using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{    
    [SerializeField]
    private float speed;


    [SerializeField]
    private GameObject anchor = default;
    private Rigidbody2D anchorRigidbody = default;

    private new Rigidbody2D rigidbody = default;
    private new HingeJoint2D hingeJoint = default;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        anchorRigidbody = anchor.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        Vector2 mousePixelPosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

        anchor.transform.position = mouseWorldPosition;
        hingeJoint.anchor = mouseWorldPosition - (Vector2)transform.position;

    }

    private void OnMouseUp()
    {
        anchorRigidbody.velocity = Vector2.zero;
    }


    private void OnMouseDrag()
    {
        Vector2 mousePixelPosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;

        //anchorRigidbody.velocity += direction * Time.deltaTime * speed;
        anchorRigidbody.AddForce(direction * Time.deltaTime * speed);
        //this.transform.position = mouseWorldPosition;
    }
}
