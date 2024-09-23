using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class astroid : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float vertSpeed = 10;
    [SerializeField] private GameObject debris;

    [SerializeField] private int Health = 10;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * vertSpeed);
        transform.Translate(Vector3.forward * speed);



        if (transform.position.z < 0)
        {
            spawnDebris();
            Destroy(this.gameObject);
        }
    }

    void spawnDebris()
    {
        Instantiate(debris, transform.position, Quaternion.identity);
        Instantiate(debris, transform.position, Quaternion.identity);
        Instantiate(debris, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        Health--;
        
        if (Health <= 0)
        {
            spawnDebris();
            Destroy(gameObject);
        }
    }
}
