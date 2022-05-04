using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone : MonoBehaviour
{
    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0.5)
        {
            transform.localScale = new Vector3(transform.localScale.x - speed, transform.localScale.y, transform.localScale.z - speed);
        }
    }
}
