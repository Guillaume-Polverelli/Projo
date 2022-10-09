using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPower : MonoBehaviour
{

    private PlayerMovement player;
    public AudioSource _collision;



    // Start is called before the first frame update
    void Awake()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.firstTry = true;
            player = collision.gameObject.GetComponent<PlayerMovement>();

            _collision.PlayOneShot(_collision.clip, 1);

            Destroy(gameObject);

            player.thief = true;

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}