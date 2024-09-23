using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debris : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float lifeTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0, 360));
        Invoke("despawn", lifeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed);
    }

    void despawn()
    {
        Destroy(gameObject);
    }
}
