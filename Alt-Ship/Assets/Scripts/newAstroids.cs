using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAstroids : MonoBehaviour
{
    [SerializeField] private Vector2 minTargetRange;
    [SerializeField] private Vector2 maxTargetRange;

    [SerializeField] private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
