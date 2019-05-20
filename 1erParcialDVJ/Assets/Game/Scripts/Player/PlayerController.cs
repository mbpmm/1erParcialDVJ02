using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float speed = 2f;
    public LayerMask RaycastLayer;
    const float RayDistance = 0.52f;
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
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) )
            {
                DropBomb();
            }
        }

    }

    void CanMove()
    {
        RaycastHit hit;
        string layerHitted;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, RayDistance, RaycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Destroyable")
            {
                canMoveUp = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.forward * RayDistance, Color.yellow);
            canMoveUp = true;
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, RayDistance, RaycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Destroyable")
            {
                canMoveDown = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.back * RayDistance, Color.yellow);
            canMoveDown = true;
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, RayDistance, RaycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Destroyable")
            {
                canMoveLeft = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.left * RayDistance, Color.yellow);
            canMoveLeft = true;
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, RayDistance, RaycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Destroyable")
            {
                canMoveRight = false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.right * RayDistance, Color.yellow);
            canMoveRight = true;
        }
    }

    void DropBomb()
    {
        if (bomb)
        {
            Instantiate(bomb, new Vector3(Mathf.RoundToInt(transform.position.x),
            bomb.transform.position.y, Mathf.RoundToInt(transform.position.z)), bomb.transform.rotation);
        }
    }
}
