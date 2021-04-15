using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinpickup : MonoBehaviour
{
    [SerializeField] AudioClip coinsvoice;
    [SerializeField] int point=100;
    gamesession gamesession;
    private void Awake()
    {
        point = 100;
        gamesession = Object.FindObjectOfType<gamesession>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
            gamesession.addtoscore(point);
            AudioSource.PlayClipAtPoint(coinsvoice, Camera.main.transform.position);
            Destroy(gameObject);
        
       
    }
}
