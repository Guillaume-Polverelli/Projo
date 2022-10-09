using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ralentissement_Bonus : MonoBehaviour
{

    private GameObject[] players;

    [SerializeField] private AudioSource _collision;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().ralentissement = true;

            _collision.PlayOneShot(_collision.clip, 1);

            Destroy(gameObject);
            // Animation fadeout

            
        }
    }

    void Update()
    {
        
    }

    
}
