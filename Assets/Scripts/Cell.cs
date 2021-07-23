using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool containsBlock = default;



    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.TryGetComponent<BlockV2>(out BlockV2 block))
    //        return;






    //    Debug.Log($"TriggerEnter {this.name}");
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<BlockV2>(out BlockV2 block))
            return;

        if (!block.Dragging && block.transform.position != transform.position)
        {
            block.Rigidbody.MovePosition(transform.position);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log($"CollisionEnter {this.name}");
    //}
}
