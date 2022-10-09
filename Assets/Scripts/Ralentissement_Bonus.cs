using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ralentissement_Bonus : MonoBehaviour
{

    private GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().ralentissement = true;

            Destroy(gameObject);
            // Animation fadeout

            
        }
    }

    void Update()
    {
        
    }

    
}
