using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x>transform.position.x)
        {
            Debug.Log("fasf");
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else if (player.position.x < transform.position.x)
        {
            Debug.Log("fasf");
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
