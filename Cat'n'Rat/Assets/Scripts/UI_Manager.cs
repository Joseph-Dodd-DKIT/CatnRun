using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UI_Manager : MonoBehaviour
{

    public Text TimeLive;
    public Image[] heart;
    public Image PowerTimer;

    private bool GameOn = true;
    private float _currentTime;

    public void start()
    {
        _currentTime = 0;
    }

    public void Update()
    {
        TimeRec();
    }

    public void TimeRec()
    {
        if (GameOn == true)
        {
            //Debug.Log("TIME TIME TIME");
            _currentTime = _currentTime + Time.deltaTime;
        }
        
        TimeLive.text = _currentTime.ToString();
    }


    public void UpdateLives(int Lives)
    {
        if (Lives == 3)
        {
            heart[0].enabled = true;
            heart[1].enabled = true;
            heart[2].enabled = true;
        }
        else if (Lives == 2)
        {
            heart[0].enabled = false;
            heart[1].enabled = true;
            heart[2].enabled = true;
        }
        else if (Lives == 1)
        {
            heart[0].enabled = false;
            heart[1].enabled = false;
            heart[2].enabled = true;
        }
        else if (Lives == 0)
        {
            heart[0].enabled = false;
            heart[1].enabled = false;
            heart[2].enabled = false;
        }
    }
}
