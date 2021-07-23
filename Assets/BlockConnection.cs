using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockConnection : MonoBehaviour
{
    private BlockV2 parentBlock = default;

    private void Awake()
    {
        parentBlock = GetComponentInParent<BlockV2>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<BlockV2>(out BlockV2 block))
            return;

        if (!block.Dragging && block.transform.position != transform.position)
        {
            block.Rigidbody.MovePosition(transform.position);
            block.transform.SetParent(parentBlock.transform);

            block.Rigidbody.isKinematic = true;


        }
    }


}
