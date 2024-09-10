using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    [SerializeField] private Vector3 shipPostion;
    [SerializeField] private Vector3 StartPosition = new Vector3(0,0,0);

    [SerializeField] private float YDistance;
    [SerializeField] private float XDistance;

    [SerializeField] private GameObject MessageListener;

    // Start is called before the first frame update
    void Start()
    {
        shipPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipPostion = StartPosition;
        }

        YDistance = MessageListener.GetComponent<MessageListener>().Y;
        XDistance = MessageListener.GetComponent<MessageListener>().X;

        shipPostion = new Vector3 (XDistance, YDistance, shipPostion.z);

        transform.position = Vector3.Lerp(transform.position, shipPostion, 0.01f);

        
    }
}
