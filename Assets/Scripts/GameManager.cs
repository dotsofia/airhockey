using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static int PlayerOneScore = 0;
    public static int PlayerTwoScore = 0;

    [SerializeField]
    GUISkin _layout;
    GameObject _ball;

    public static void Score(string wallID)
    {
        Debug.Log(wallID);
        if (wallID == "Goal1") {
            PlayerOneScore++;
        } else {
            PlayerTwoScore++;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.skin = _layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerOneScore);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerTwoScore);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            _ball.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }

        if (PlayerOneScore == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            _ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerTwoScore == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            _ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }

    }
}
