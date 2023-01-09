using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    private bool started = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private BallControler ballControler;

    private Vector3 startingPosition;

    void Start()
    {
        this.ballControler = this.ball.GetComponent<BallControler>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.started){
            return;
        }
        if(Input.GetKey(KeyCode.Space)){
            this.started = true;
            this.ballControler.Go();
        }
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("ScoreGoalLeft");
        this.scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        this.scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();

    }

    private void ResetBall()
    {
        this.ballControler.Stop();
        this.ball.transform.position = this.startingPosition;
        this.ballControler.Go();
    }
}
