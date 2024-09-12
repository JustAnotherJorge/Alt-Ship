using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject messageListener;

    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (messageListener.GetComponent<MessageListener>().doShoot == true) 
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
            messageListener.GetComponent<MessageListener>().doShoot = false;
        }
    }
}
