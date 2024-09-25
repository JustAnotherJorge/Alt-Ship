using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 1;
    [SerializeField] private Vector3 targetScale;
    [SerializeField] private float destroyScalePersentage = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed);
        if(transform.localScale.x > targetScale.x - ((targetScale.x/ 100) * destroyScalePersentage))
        {
            despawn();
        }
    }

    void despawn()
    {
        Destroy(gameObject);
    }
}
