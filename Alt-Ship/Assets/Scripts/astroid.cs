using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class astroid : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float vertSpeed = 10;
    [SerializeField] private float attackSpeed = 0.1f;
    [SerializeField] private GameObject[] debris;
    
    private Transform player;

    private bool targetReached = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Target").transform;

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetReached == false) 
        {
            transform.Translate(Vector3.up * vertSpeed);
            transform.Translate(Vector3.forward * speed);
        }
        else
        {
            transform.Translate(Vector3.forward * attackSpeed);
        }

        

        if (transform.position.z < 0 && targetReached == false)
        {
            transform.LookAt(player.position);
            targetReached = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       // Destroy(gameObject);
    }
}
