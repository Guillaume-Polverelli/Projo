using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiafPower : MonoBehaviour
{
    public float _delay;

    private PlayerMovement player;
    private Collider2D playerCollider;


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

            playerCollider = player.GetComponent<Collider2D>();
            playerCollider.isTrigger = true;
            //StartCoroutine(Delay(playerCollider));
        }
    }

    private IEnumerator Delay(Collider2D _playerCollider)
    {
        yield return new WaitForSeconds(_delay);
        _playerCollider.isTrigger = false;
        Debug.Log(_playerCollider);
        Debug.Log("yeah");

        /*yield return new WaitForSeconds(5);
        if (!_playerCollider.IsTouching((GameObject.FindWithTag("Map").GetComponent<EdgeCollider2D>())))
        {
            Debug.Log("yeah");
            this.transform.position = new Vector3((float)0.98, (float)-2.28, 0);
        }*/


    }


    // Update is called once per frame
    void Update()
    {

    }
}
