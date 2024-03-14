using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldownMax = 2f;
    public float cooldownMin = 4f;
    public GameObject Object;

    private Transform pos;
    private float timer, cooldown;

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
            cooldown = Random.Range(cooldownMin, cooldownMax);
            timer = 0;
        }
    }
}
