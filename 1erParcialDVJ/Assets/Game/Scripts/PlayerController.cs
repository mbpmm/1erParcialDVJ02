using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float speed = 2f;
    public LayerMask raycastLayer;
    const float rayDistance = 0.52f;
    public GameObject bomb;

    private bool canMoveLeft;
    private bool canMoveRight;
    private bool canMoveUp;
    private bool canMoveDown;
    private void Start()
    {
        canMoveLeft = true;
        canMoveRight = true;
        canMoveUp = true;
        canMoveDown = true;
    }

    void FixedUpdate()
    {
        if (Input.anyKey)
        {
            CanMove();
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && canMoveUp)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && canMoveDown)
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && canMoveLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && canMoveRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Space) )
            {
                Instantiate(bomb, transform.position - Vector3.up*0.5f, bomb.transform.rotation) ;
            }
        }

    }

    void CanMove()
    {
        RaycastHit hit;
        string layerHitted;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, rayDistance, raycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Bomb")
            {
                canMoveUp = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.forward * rayDistance, Color.yellow);
            canMoveUp = true;
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, rayDistance, raycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Bomb")
            {
                canMoveDown = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.back * rayDistance, Color.yellow);
            canMoveDown = true;
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, rayDistance, raycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Bomb")
            {
                canMoveLeft = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.left * rayDistance, Color.yellow);
            canMoveLeft = true;
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, rayDistance, raycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Bomb")
            {
                canMoveRight = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.right * rayDistance, Color.yellow);
            canMoveRight = true;
        }
    }
}
