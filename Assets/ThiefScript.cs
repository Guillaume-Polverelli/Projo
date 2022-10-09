using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefScript : MonoBehaviour
{

    public int numJoueur;
    private PlayerMovement player;

    

    // Start is called before the first frame update
    void Awake()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            player = collision.gameObject.GetComponent<PlayerMovement>();
            if (GameManager.Instance.firstTry)
            {
                bool add;
                add = GameManager.Instance.RemoveScore(numJoueur);
                if (add)
                {
                    GameManager.Instance.AddScore(player.get_player());
                }
                
                GameManager.Instance.firstTry = false;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
