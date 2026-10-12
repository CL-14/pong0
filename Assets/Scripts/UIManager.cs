using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{
    public Text score1;
    public Text score2;
    public Text winner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winner.GetComponent<UnityEngine.UI.Text>().text = "PONG";// Set the initial text of the winner Text component to "PONG"
    }

    // Update is called once per frame
    void Update()
    {

        score1.GetComponent<UnityEngine.UI.Text>().text = "PLAYER ONE" + Ball.p1Score.ToString();// Set the text of the score1 Text component to "PLAYER ONE"
        score2.GetComponent<UnityEngine.UI.Text>().text = "PLAYER TWO" + Ball.p2Score.ToString();
        PlayerWins();
    }

    void PlayerWins()
    {
        if (Ball.p1Score >= Ball.maxScore)
        {
            winner.GetComponent<UnityEngine.UI.Text>().text = "PLAYER ONE WINS!";
        }
        else if (Ball.p2Score >= Ball.maxScore)
        {
            winner.GetComponent<UnityEngine.UI.Text>().text = "PLAYER TWO WINS!";
        }
    }
}
