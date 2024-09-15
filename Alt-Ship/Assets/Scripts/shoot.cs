using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject inputListener;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float shootRate = 0.5f;

    private bool hasShot = false;

    [SerializeField] private SerialController inputController;

    // Start is called before the first frame update
    void Start()
    {
        inputController = inputListener.GetComponent<SerialController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputListener.GetComponent<inputListener>().doShoot == true) 
        {
            if (hasShot == false) 
            {
                StartCoroutine("shootBullet");
            }
            
        }
    }

    IEnumerator shootBullet()
    {
        hasShot = true;
        Instantiate(bullet, transform.position, bullet.transform.rotation);
        inputController.SendSerialMessage("n");
        yield return new WaitForSecondsRealtime(shootRate);
        inputController.SendSerialMessage("f");
        hasShot = false;
    }

   
}
