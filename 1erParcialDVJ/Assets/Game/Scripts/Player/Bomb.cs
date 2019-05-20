using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public LayerMask RaycastLayer;
    public float expDelay;
    public float tilesLength;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(EnableCollision(1));
        Invoke("Explode", expDelay);
    }

    private IEnumerator EnableCollision(float delay)
    {
        yield return new WaitForSeconds(delay);
        GetComponent<SphereCollider>().enabled = true;
    }

    private IEnumerator CreateExplosions(Vector3 direction)
    {
        for (int i = 1; i < tilesLength; i++)
        {
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(0, .5f, 0), direction, out hit, i, RaycastLayer);
            if (!hit.collider)
            {
                Instantiate(explosion, transform.position + (i * direction),explosion.transform.rotation);
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(.05f);
        }
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        StartCoroutine(CreateExplosions(Vector3.forward));
        StartCoroutine(CreateExplosions(Vector3.right));
        StartCoroutine(CreateExplosions(Vector3.back));
        StartCoroutine(CreateExplosions(Vector3.left));
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, .3f); 
    }
}
