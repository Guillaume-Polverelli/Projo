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

    [SerializeField] private Image [] _imagePlayer;
    [SerializeField] private GameObject _introUI;

    [SerializeField] private float _timerDuration;
    [SerializeField] private Canvas _ui;
    [SerializeField] private GameObject [] _scoreJoueur1;
    [SerializeField] private GameObject [] _scoreJoueur2;
    [SerializeField] private GameObject [] _scoreJoueur3;
    [SerializeField] private GameObject [] _scoreJoueur4;
    [SerializeField] private Text _timerTxt;


    public bool firstTry = false;

    private bool playing = false;
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
            for(int joystickId = 1; joystickId < 4; joystickId++)
            {
                for (int buttonId = 0; buttonId < 4; buttonId++)
                {
                    if (Input.GetKeyDown("Joystick" + joystickId + "Button" + buttonId))
                    {
                        if(_activePlayers[joystickId - 1] == false)
                        {
                            _imagePlayer[joystickId - 1].color = new Color(1f, 1f, 1f, 1f);
                            _activePlayers[joystickId - 1] = true;
                            nbPlayer++;
                        }
                    }
                }
            }

            if (nbPlayer == 4)
            {
                _introUI.SetActive(false);
                playing = true;
            }
            
        }
        else
        {
            _timer -= Time.deltaTime;
            _timerTxt.text = ((int)_timer).ToString(); ;

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
        print("Joueur " + player.ToString() + "Win");
    }
}
