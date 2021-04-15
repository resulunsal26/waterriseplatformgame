using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verticalwater : MonoBehaviour
{
    [SerializeField] float scrollrate = 0.2f;
    // Update is called once per frame
    void Update()
    {
        float ymove = scrollrate * Time.deltaTime;
        transform.Translate(new Vector2(0f, ymove));
    }
}
