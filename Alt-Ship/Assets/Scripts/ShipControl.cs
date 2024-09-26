using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    [SerializeField] private bool useMousePo;
    [SerializeField] protected Camera Cam;

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
        if (useMousePo == false)
        {
            YDistance = positionListener.GetComponent<positionListener>().Y;

            XDistance = positionListener.GetComponent<positionListener>().X;

            shipPostion = new Vector3(XDistance, YDistance, shipPostion.z) /*- StartPosition*/;
            shipPostion -= StartPosition;
            shipPostion = shipPostion / 2;

            if (Input.GetKeyDown(KeyCode.Space))
                calabratePosition();
        }
        else
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                shipPostion = hitInfo.point;
            }
        }

        
        transform.position = Vector3.Lerp(transform.position, shipPostion, movmentSmoothing * Time.deltaTime);

        Vector3 dir = Cam.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(-dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10 * Time.deltaTime);

        
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
