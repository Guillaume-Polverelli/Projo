using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseInput : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerMovement>().Inverse = true;

            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
