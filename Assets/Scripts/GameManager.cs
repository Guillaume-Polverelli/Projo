using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score1 { get; private set; }
    public int Score2 { get; private set; }
    public int Score3 { get; private set; }
    public int Score4 { get; private set; }
    private int [] _scores = new int[4];

    [SerializeField] private Image [] _imagePlayer;
    [SerializeField] private GameObject _introUI;

    [SerializeField] private float _timerDuration;
    [SerializeField] private Canvas _ui;
    [SerializeField] private GameObject [] _scoreJoueur1;
    [SerializeField] private GameObject [] _scoreJoueur2;
    [SerializeField] private GameObject [] _scoreJoueur3;
    [SerializeField] private GameObject [] _scoreJoueur4;
    [SerializeField] private Text _timerTxt;
    [SerializeField] private GameObject winCanva;
    [SerializeField] private Text winText;


    public bool firstTry = false;

    public bool playing = false;
    private bool [] _activePlayers = new bool[4];
    private int nbPlayer = 0;

    private float _timer = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        for (int i = 0; i < _activePlayers.Length; i++)
        {
            _activePlayers[i] = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _timer = _timerDuration;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!playing)   
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if (_activePlayers[0] == false)
                {
                    _imagePlayer[0].color = new Color(1f, 1f, 1f, 1f);
                    _activePlayers[0] = true;
                    nbPlayer++;
                }
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                if (_activePlayers[1] == false)
                {
                    _imagePlayer[1].color = new Color(1f, 1f, 1f, 1f);
                    _activePlayers[1] = true;
                    nbPlayer++;
                }
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button1))
            {
                if (_activePlayers[2] == false)
                {
                    _imagePlayer[2].color = new Color(1f, 1f, 1f, 1f);
                    _activePlayers[2] = true;
                    nbPlayer++;
                }
            }
            if (Input.GetKeyDown(KeyCode.Joystick4Button1))
            {
                if (_activePlayers[3] == false)
                {
                    _imagePlayer[3].color = new Color(1f, 1f, 1f, 1f);
                    _activePlayers[3] = true;
                    nbPlayer++;
                }
            }


            if (nbPlayer == 4)
            {
                StartCoroutine(PlayGame());   
            }

        }
        else
        {
            _timer -= Time.deltaTime;
            _timerTxt.text = ((int)_timer).ToString(); ;

            if (_timer <= 0)
            {
                EndTimer();
            }

            if (Score1 == 7)
            {
                EndGame(1);
            }
            else if (Score2 == 7)
            {
                EndGame(2);
            }
            else if (Score3 == 7)
            {
                EndGame(3);
            }
            else if (Score4 == 7)
            {
                EndGame(4);
            }
        }
    }

    private IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(1f);
        _introUI.SetActive(false);
        playing = true;
    }

    public void AddScore(int num_player)
    {
        switch (num_player)
        {
            case 1:
                
                _scoreJoueur1[Score1].SetActive(true);
                Score1 += 1;
                break;
            case 2:
                
                _scoreJoueur2[Score2].SetActive(true);
                Score2 += 1;
                break;
            case 3:
                
                _scoreJoueur3[Score3].SetActive(true);
                Score3 += 1;
                break;
            case 4:
                
                _scoreJoueur4[Score4].SetActive(true);
                Score4 += 1;
                break;
        }
    }



    public bool RemoveScore(int num_player)
    {
        switch (num_player)
        {
            case 1:
                if(Score1 > 0)
                {
                    Score1 -= 1;
                    _scoreJoueur1[Score1].SetActive(false);
                    
                }
                else
                {
                    return false;
                }
             
                
                break;
            case 2:
                if (Score2 > 0)
                {
                    Score2 -= 1;
                    _scoreJoueur2[Score2].SetActive(false);
                    
                }
                else
                {
                    return false;
                }

                break;
            case 3:
                if (Score2 > 0)
                {
                    Score3 -= 1;
                    _scoreJoueur3[Score3].SetActive(false);
                    
                }
                else
                {
                    return false;
                }

                break;
            case 4:
                if (Score2 > 0)
                {
                    Score4 -= 1;
                    _scoreJoueur4[Score4].SetActive(false);
                    
                }
                else
                {
                    return false;
                }

                break;

            
        }
        return true;
    }

    public void EndGame(int player)
    {
        playing = false;
        print("Joueur " + player.ToString() + "Win");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        winCanva.SetActive(true);
        winText.text = "Player " + player.ToString() + " Win";
        players[player].GetComponent<PlayerMovement>().winGate.GetComponent<Collider>().isTrigger = true;
    }

    public void EndTimer()
    {
        playing = false;

        _scores[0] = Score1;
        _scores[1] = Score2;
        _scores[2] = Score3;
        _scores[3] = Score4;

        int scoreMax = 0;
        List<int> winners = new List<int>();

        for (int i = 0; i < _scores.Length; i++)
        {
            if (_scores[i] > scoreMax)
            {
                scoreMax = _scores[i];
                winners.Clear();    
                winners.Add(i+1);
            }
            else if (_scores[i] == scoreMax)
            {
                winners.Add(i+1);
            }
        }

        // random winner
        int index = Random.Range(0, winners.Count);
        EndGame(winners[index]);

    }
}
