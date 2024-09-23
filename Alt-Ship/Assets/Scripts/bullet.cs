using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float lifeTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("despawn", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void despawn()
    {
        Destroy(gameObject);
    }
}
