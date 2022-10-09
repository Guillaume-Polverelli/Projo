using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseInput : MonoBehaviour
{

    [SerializeField] private AudioSource _collision;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerMovement>().Inverse = true;

            _collision.PlayOneShot(_collision.clip, 1);

            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
