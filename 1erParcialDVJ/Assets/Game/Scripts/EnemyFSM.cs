using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        MovingUp,
        MovingDown,
        MovingLeft,
        MovingRight,
        Last,
    }

    [SerializeField] private EnemyState state;

    public float speed;
    public LayerMask RaycastLayer;
    const float RayDistance = 0.52f;

    private float t;
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
    private void FixedUpdate()
    {
        CanMove();

        switch (state)
        {
            case EnemyState.MovingUp:
                if (canMoveUp)
                {
                    t += Time.deltaTime;
                    transform.position = transform.position + transform.forward * speed * Time.deltaTime;
                    if (t > 3)
                    {
                        state = (EnemyState)Random.Range(0, 3);
                        SetState(state);
                        t = 0;
                    }
                }
                else
                {
                    state = (EnemyState)Random.Range(0, 3);
                    SetState(state);
                }
                break;
            case EnemyState.MovingDown:
                if (canMoveDown)
                {
                    t += Time.deltaTime;
                    transform.position = transform.position + transform.forward * -speed * Time.deltaTime;

                    if (t > 3)
                    {
                        state = (EnemyState)Random.Range(0, 3);
                        SetState(state);
                        t = 0;
                    }
                }
                else
                {
                    state = (EnemyState)Random.Range(0, 3);
                    SetState(state);
                }
                
                break;
            case EnemyState.MovingRight:
                if (canMoveRight)
                {
                    t += Time.deltaTime;
                    transform.position = transform.position + transform.right * speed * Time.deltaTime;
                    if (t > 3)
                    {
                        state = (EnemyState)Random.Range(0, 3);
                        SetState(state);
                        t = 0;
                    }
                }
                else
                {
                    state = (EnemyState)Random.Range(0, 3);
                    SetState(state);
                }
                break;
            case EnemyState.MovingLeft:
                if (canMoveLeft)
                {
                    t += Time.deltaTime;
                    transform.position = transform.position + transform.right * -speed * Time.deltaTime;
                    if (t > 3)
                    {
                        state = (EnemyState)Random.Range(0, 3);
                        SetState(state);
                        t = 0;
                    }
                }
                else
                {
                    state = (EnemyState)Random.Range(0, 3);
                    SetState(state);
                }
                break;
            default:
                break;
        }
    }

    private void NextState()
    {
        t = 0;
        int intState = (int)state;
        intState++;
        intState = intState % ((int)EnemyState.Last);
        SetState((EnemyState)intState);
    }

    private void SetState(EnemyState es)
    {
        state = es;
    }

    void CanMove()
    {
        RaycastHit hit;
        string layerHitted;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, RayDistance, RaycastLayer))
        {
            layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted == "Wall" || layerHitted == "Destroyable" || layerHitted == "Bomb" || layerHitted == "Enemy")
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

            if (layerHitted == "Wall" || layerHitted == "Destroyable" || layerHitted == "Bomb" || layerHitted == "Enemy")
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

            if (layerHitted == "Wall" || layerHitted == "Destroyable" || layerHitted == "Bomb" || layerHitted == "Enemy")
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

            if (layerHitted == "Wall" || layerHitted == "Destroyable" || layerHitted == "Bomb" || layerHitted == "Enemy")
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
}
