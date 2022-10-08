using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int Score1 { get; private set; }
    public int Score2 { get; private set; }
    public int Score3 { get; private set; }
    public int Score4 { get; private set; }

    [SerializeField] private float _timerDuration;
    [SerializeField] private Canvas _ui;
    [SerializeField] private TMP_Text _score1Txt;
    [SerializeField] private TMP_Text _score2Txt;
    [SerializeField] private TMP_Text _score3Txt;
    [SerializeField] private TMP_Text _score4Txt;
    [SerializeField] private TMP_Text _timerTxt;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        _timer = _timerDuration;
    }

    // Update is called once per frame
    private void Update()
    {
        _timer -= Time.deltaTime;
        _timerTxt.text = ((int)_timer).ToString(); ;

        if (_timer < 0)
        {
            EndGame();
        }
    }

    public void AddScore(int num_player)
    {
        switch (num_player)
        {
            case 1:
                Score1 += 1;
                _score1Txt.text = Score1.ToString();
                break;
            case 2:
                Score2 += 1;
                _score2Txt.text = Score2.ToString();
                break;
            case 3:
                Score3 += 1;
                _score3Txt.text = Score3.ToString();
                break;
            case 4:
                Score4 += 1;
                _score4Txt.text = Score4.ToString();
                break;
        }
    }

    public void EndGame()
    {
        print("Win");
    }
}
