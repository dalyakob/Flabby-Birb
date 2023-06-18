using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePhysics : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deadZone = -30f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.left * moveSpeed) * Time.deltaTime);

        if(transform.position.x < deadZone)
        {
            Destroy(gameObject);
            Debug.Log("Pipe Destroyed");
        }
        
    } 
}
