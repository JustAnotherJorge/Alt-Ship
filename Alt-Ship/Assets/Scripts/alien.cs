using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    [SerializeField] private float spawnCoolDown = 5;
    [SerializeField] private Vector2 bombSpawnRangeMin;
    [SerializeField] private Vector2 bombSpawnRangeMax;
    [SerializeField] private float shootSpeed = 0.1f;

    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform beam;

    private Vector3 _spawnPo;

    private float _distToSpawnPo;

    private bool attackStarted;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("attack");
    }

    // Update is called once per frame
    void Update()
    {       

        if (attackStarted == true)
        {
            beam.transform.localScale = Vector3.Lerp(beam.localScale, new Vector3(beam.localScale.x, _distToSpawnPo, beam.localScale.z), shootSpeed * Time.deltaTime);

            float spawnPerentile = _distToSpawnPo - ((_distToSpawnPo / 100) * 10);
            if (beam.localScale.y > spawnPerentile)
            {
                Instantiate(bomb, _spawnPo, Quaternion.identity);

                _spawnPo = Vector3.zero;
                beam.transform.localScale = new Vector3(beam.localScale.x, 0, beam.localScale.z);
                attackStarted = false;
                StartCoroutine("attack");
            }
        }  
    }

    void startAttack()
    {
        _spawnPo = new Vector3(Random.Range(bombSpawnRangeMin.x, bombSpawnRangeMax.x), Random.Range(bombSpawnRangeMin.y, bombSpawnRangeMax.y), 0);
        _distToSpawnPo = Vector3.Distance(transform.position, _spawnPo);
        _distToSpawnPo = _distToSpawnPo / 2;
        beam.LookAt(_spawnPo);
        beam.eulerAngles = new Vector3(beam.eulerAngles.x + 90, beam.eulerAngles.y, beam.eulerAngles.z);

        attackStarted = true;
    }

    IEnumerator attack()
    {
        yield return new WaitForSecondsRealtime(spawnCoolDown);
        startAttack();
    }
}
