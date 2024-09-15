using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    [SerializeField] private SerialController inputController;

    // Start is called before the first frame update
    void Start()
    {
        writeDamage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            health--;
            writeDamage();
        }
    }

    void writeDamage()
    {
        inputController.SendSerialMessage(health.ToString());
    }
}
