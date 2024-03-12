using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 4f;
    public GameObject Object;

    private Transform pos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > cooldown)
        {
            Instantiate(Object, pos);
            cooldown = Random.Range(3, 5);
            timer = 0;
        }
    }
}
