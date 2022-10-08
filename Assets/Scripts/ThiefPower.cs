using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPower : MonoBehaviour
{

    private PlayerMovement player;



    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerMovement>();

            Destroy(gameObject);

            player.thief = true;

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}