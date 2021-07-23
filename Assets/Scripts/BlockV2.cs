using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockV2 : MonoBehaviour
{
    [SerializeField]
    private float speed = default;
    [SerializeField]
    private float rotationSpeed = default;

    private new Rigidbody2D rigidbody = default;
    public Rigidbody2D Rigidbody => rigidbody;

    private new Collider2D collider = default;
    public Collider2D Collider => collider;


    private Camera mainCamera = default;

    private bool dragging = default;
    public bool Dragging => dragging;

    //Vector2 originalScreenTargetPosition;
    //Vector2 originalRigidbodyPos;

    Vector2 lastMouseWorldPosition = default;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        dragging = true;
        //Vector2 mousePixelPosition = Input.mousePosition;
        //Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

        //lastMouseWorldPosition
        //originalScreenTargetPosition = mouseWorldPosition;
        //originalRigidbodyPos = transform.position;
    }

    private void OnMouseUp()
    {
        dragging = false;
        //if (GetMouseWorldPosition() == lastMouseWorldPosition)
        //    rigidbody.velocity = Vector2.zero;
        //Debug.Log(rigidbody.velocity);
    }


    private void OnMouseDrag()
    {
        Vector2 mouseWorldPosition = GetMouseWorldPosition();
        if (mouseWorldPosition == lastMouseWorldPosition)
            return;

        Vector3 smoothedDelta = Vector3.MoveTowards(transform.position, mouseWorldPosition, Time.fixedDeltaTime * speed);
        rigidbody.MovePosition(smoothedDelta);
        //Debug.Log(rigidbody.velocity);
        lastMouseWorldPosition = mouseWorldPosition;
    }

    private void Update()
    {
        if (dragging)
            rigidbody.AddTorque(Input.mouseScrollDelta.y * rotationSpeed * Time.deltaTime);
    }

    private Vector2 GetMouseWorldPosition() => mainCamera.ScreenToWorldPoint(Input.mousePosition);
}
