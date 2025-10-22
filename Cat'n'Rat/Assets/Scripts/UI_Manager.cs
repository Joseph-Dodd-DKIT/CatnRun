using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Text TimeLive;
    public Image[] heart;
    public Image PowerTimer;

    public void update()
    {
        Debug.Log("TIME TIME TIME");
        TimeRec();
    }

    public void TimeRec()
    {
        TimeLive.text = Time.deltaTime.ToString();
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
