using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private Animator _animator;
    public Text scoreText;
    private int score = 0;
    public bool acceleration = false;
    public bool thief = false;
    private float _speedMultiplier = 2f;
    public bool isSlowed = false;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _smoothing = 0.005f * _speed;
        
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

        if (acceleration)
        {
            StartCoroutine(accelerationPlayer());
            acceleration = false;
        }

        if (thief)
        {
            StartCoroutine(thiefPower());
            thief = false;
        }
    }

    private IEnumerator accelerationPlayer()
    {
        this.set_speed(this.get_speed() * _speedMultiplier);
        this.set_smoothing(this.get_speed() * 0.01f);
        yield return new WaitForSeconds(1.5f);



        this.set_speed(this.get_speed() / _speedMultiplier);
        this.set_smoothing(this.get_speed() * 0.01f);



    }

    private IEnumerator thiefPower()
    {
       
        Collider2D playerCollider = GetComponent<Collider2D>();
        playerCollider.isTrigger = true;
        
        yield return new WaitForSeconds(15);
        playerCollider.isTrigger = false;
     

        yield return new WaitForSeconds(5);
        if (!playerCollider.IsTouching((GameObject.FindWithTag("Map").GetComponent<PolygonCollider2D>())))
        {
            this.transform.position = new Vector3((float)0.98, (float)-2.28, 0);
        }
    }

private void FixedUpdate()
    {
        MovePlayer(_input_horiz * _speed * Time.deltaTime, _input_verti * _speed * Time.deltaTime);
       
        AnimatePlayer();
    }

    private void MovePlayer(float mouvement_horiz, float mouvement_verti)
    {
        if(Mathf.Abs(mouvement_horiz * 10f) > 0.03 && Mathf.Abs(mouvement_verti * 10f) > 0.03)
        {
            var newVelocity = new Vector2(mouvement_horiz * 7f, mouvement_verti * 7f);
            _rb.velocity = Vector2.SmoothDamp(_rb.velocity, newVelocity, ref _velocity, _smoothing);
        }
        else
        {
            var newVelocity = new Vector2(mouvement_horiz * 10f, mouvement_verti * 10f);
            _rb.velocity = Vector2.SmoothDamp(_rb.velocity, newVelocity, ref _velocity, _smoothing);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("LeDrapeau"))
        {
            collision.gameObject.SetActive(false);
            score = score + 1;
            scoreText.text = score.ToString();


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



    private void AnimatePlayer()
    {
        _animator.SetFloat("Speed_Horizontal", _input_horiz);
        _animator.SetFloat("Speed_Vertical", _input_verti);
    }

}
