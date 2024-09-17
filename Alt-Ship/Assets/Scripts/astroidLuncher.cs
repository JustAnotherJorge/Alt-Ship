using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroidLuncher : MonoBehaviour
{
    [SerializeField] private GameObject astroid;

    [SerializeField] private Vector2 shootDelay = new Vector2(1, 2);


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator shoot()
    {
        yield return new WaitForSecondsRealtime(Random.Range(shootDelay.x, shootDelay.y));
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Random.Range(0, 360));
        Instantiate(astroid, transform.position, transform.rotation);
        StartCoroutine("shoot");
    }
}
