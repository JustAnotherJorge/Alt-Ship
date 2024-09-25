using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    [SerializeField] private float spawnCoolDown = 5;
    [SerializeField] private Vector2 bombSpawnRangeMin;
    [SerializeField] private Vector2 bombSpawnRangeMax;

    [SerializeField] private GameObject bomb;

    private LineRenderer myLine;


    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();
        StartCoroutine("attack");
    }

    // Update is called once per frame
    void Update()
    {
        myLine.SetPosition(0, transform.position);
    }

    IEnumerator attack()
    {
        yield return new WaitForSecondsRealtime(spawnCoolDown);

        Vector3 spawnPo = new Vector3(Random.Range(bombSpawnRangeMin.x, bombSpawnRangeMax.x), Random.Range(bombSpawnRangeMin.y, bombSpawnRangeMax.y), 0);

        myLine.SetPosition(1, spawnPo);

        Instantiate(bomb, spawnPo, Quaternion.identity);

        StartCoroutine("attack");
    }
}
