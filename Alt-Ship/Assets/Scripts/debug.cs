using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class debug : MonoBehaviour
{
    [Header("Spawn Area")]
    [SerializeField] private Vector3 cubeSize;
    [SerializeField] private Color cubeColour = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = cubeColour;
        Gizmos.DrawWireCube(new Vector3(transform.position.x + 8, transform.position.y + 4.5f, transform.position.z + (cubeSize.z / 2)), cubeSize);
    }
}
