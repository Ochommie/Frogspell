using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    public LayerMask solidObjectsLayer;

    public LayerMask interactablesLayer;

    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                //Animator.SetFloat("moveX", input.x);
                //Animator.SetFloat("moveY", input.y);


                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }



        //animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }

    void Interact()
    {
        var facingDir = new Vector3();
        var interactPos = transform.position + facingDir;
        //Debug.DrawLine(transform.position, interactPos, Color.red, 1f);

        var collider = Physics2D.OverlapCircle(interactPos, 1f, interactablesLayer);
        if (collider != null)
        {
          Debug.Log("Here is a NPC");
        }

    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactablesLayer) != null)
        {
            return false;
        }

        return true;
    }
}
