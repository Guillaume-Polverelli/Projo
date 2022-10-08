using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _player;

    private float _smoothing;
    private Rigidbody2D _rb;
    //private BoxCollider2D _collider;
    private float _input_horiz;
    private float _input_verti;
    private Vector2 _velocity;
    private bool test_collision = false;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _smoothing = 0.01f * _speed;
        //_collider = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private  void Update()
    {
        _input_horiz = Input.GetAxis("Horizontal");
        _input_verti = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        MovePlayer(_input_horiz * _speed * Time.deltaTime, _input_verti * _speed * Time.deltaTime);
    }

    private void MovePlayer(float mouvement_horiz, float mouvement_verti)
    {
        var newVelocity = new Vector2(mouvement_horiz * 10f, mouvement_verti * 10f);
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, newVelocity, ref _velocity, _smoothing);
    }

    public float get_speed()
    {
        return _speed;
    }

    public int get_player()
    {
        return _player;
    }

    public void set_speed(float speed)
    {
        _speed = speed;
    }

    public void set_smoothing(float smoothing)
    {
        _smoothing = smoothing;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<PlayerMovement>().get_player() < _player && test_collision == false)
            {
                test_collision = true;
                float tmp = _speed;
                float tmp_s = 0.01f * tmp;
                _speed = collision.gameObject.GetComponent<PlayerMovement>().get_speed();
                _smoothing = 0.01f * _speed;

                collision.gameObject.GetComponent<PlayerMovement>().set_speed(tmp);
                collision.gameObject.GetComponent<PlayerMovement>().set_smoothing(tmp_s);

            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerMovement>().get_player() < _player && test_collision == true)
            {
                test_collision = false;
            }

        }
    }

}