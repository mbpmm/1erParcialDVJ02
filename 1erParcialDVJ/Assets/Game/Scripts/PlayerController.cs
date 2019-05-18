using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private bool movesH;
    private bool movesV;

    void Start()
    {

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        transform.position += movement*Time.deltaTime*speed;
    }
}