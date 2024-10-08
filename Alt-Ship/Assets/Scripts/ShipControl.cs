using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    [SerializeField] private Vector3 shipPostion;
    [SerializeField] private Vector3 StartPosition;

    [SerializeField] private float YDistance;
    [SerializeField] private float XDistance;

    [SerializeField] private GameObject positionListener;

    private int calabrationFase;

    [SerializeField] private Vector3 furthestPo = new Vector3(16, 9, 0);
    [SerializeField] private Vector3 screenBounds;

    [SerializeField] private float movmentSmoothing = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        shipPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        YDistance = positionListener.GetComponent<positionListener>().Y;

        XDistance = positionListener.GetComponent<positionListener>().X;

        shipPostion = new Vector3 (XDistance, YDistance, shipPostion.z) /*- StartPosition*/;
        shipPostion -= StartPosition;
        shipPostion = shipPostion / 2;

        transform.position = Vector3.Lerp(transform.position, shipPostion, movmentSmoothing * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            calabratePosition();
    }


    void calabratePosition()
    {
        if (calabrationFase == 0)
        {
            //gets position relative to the bottem right of the screen.
            StartPosition = new Vector3(XDistance, YDistance, shipPostion.z);
            //calabrationFase++;
        }
        else if (calabrationFase == 1)
        {
            screenBounds = furthestPo - StartPosition;
            calabrationFase++;
        }
        

        
    }
}
