using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{

    public Text TimeRecord;
    public Image[] heart;

    public void update()
    {
        float TimeNum = Time.deltaTime;
        Debug.Log("TIME TIME TIME");
    }

    public void TimeRec(float TimeNum)
    {
        TimeRecord.text = TimeNum.ToString();
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
