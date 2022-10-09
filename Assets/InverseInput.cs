using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseInput : MonoBehaviour
{

    private bool Inverse = false;
    private int player;
    private GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            player = collision.gameObject.GetComponent<PlayerMovement>().get_player();

            Destroy(gameObject);

            Inverse = true;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Inverse)
        {
            StartCoroutine(InverseCor());
        }
    }

    private IEnumerator InverseCor()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < 4; i++)
        {
            if(players[i].GetComponent<PlayerMovement>().get_player() != player)
            {
                string Axis = players[i].GetComponent<PlayerMovement>().AxisX;
                players[i].GetComponent<PlayerMovement>().AxisX = players[i].GetComponent<PlayerMovement>().AxisY;
                players[i].GetComponent<PlayerMovement>().AxisY = Axis;
            }
        }
        
        yield return new WaitForSeconds(3);

        for(int i = 0; i< 4; i++)
            {
                if(players[i].GetComponent<PlayerMovement>().get_player() != player)
                {
                    string Axis = players[i].GetComponent<PlayerMovement>().AxisX;
                    players[i].GetComponent<PlayerMovement>().AxisY = players[i].GetComponent<PlayerMovement>().AxisX;
                    players[i].GetComponent<PlayerMovement>().AxisX = Axis;
                }
            }
    }
}
