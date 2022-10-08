using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration_Bonus : MonoBehaviour
{

    [SerializeField] private float _delay;
    [SerializeField] private float _speedMultiplier;

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
            StartCoroutine(Timer(player));
            Destroy(gameObject);

            player.set_speed(player.get_speed() * _speedMultiplier);
            player.set_smoothing(player.get_speed() * 0.01f);
            
        }
    }

    private IEnumerator Timer(PlayerMovement _playerMovement)
    {
        Debug.Log("yeah");
        

        _playerMovement.set_speed(player.get_speed() / _speedMultiplier);
        _playerMovement.set_smoothing(player.get_speed() * 0.01f);
        yield return new WaitForSeconds(2);

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
