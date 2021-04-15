using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    Rigidbody2D enemyrb;
    // Start is called before the first frame update
    private void Awake()
    {
        enemyrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isfacingright())
        {
            enemyrb.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            enemyrb.velocity = new Vector2(-movespeed , 0f);
        }
    }
    public bool isfacingright()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-transform.localScale.x, 1f);
    }
}
