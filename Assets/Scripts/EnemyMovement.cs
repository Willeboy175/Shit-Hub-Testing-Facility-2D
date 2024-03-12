using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float lifeTime = 3f;

    private Transform target;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        dir = (target.position - transform.position).normalized;

        transform.position += speed * Time.deltaTime * dir;
    }

    private void OnTriggerEnter2D(Collision2D collision)
    {
        Destroy(this);
    }
}
