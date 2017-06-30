using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using DG.Tweening;

public class HUD : MonoBehaviour 
{
	public static HUD instance = null;    

	public Text playerScoreText;
	public Text tieScoreText;
	public Text computerScoreText;

	public StatusText statusText;
    public StatusText resultText;

    public Button restartButton;
    public GameObject resultPanel;

    void Awake()
	{
		if(instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}

	void Start()
	{
		playerScoreText.text = tieScoreText.text = computerScoreText.text = 0.ToString();
		DisableRestartButton();
        resultPanel.SetActive(false);
    }

	public void Restart()
	{
		UpdateTurnText();
		DisableRestartButton();
        resultPanel.SetActive(false);
	}

	public void DisableRestartButton()
	{
		restartButton.GetComponent<ButtonHelper>().DisableHidingImage();
	}

	public void EnableRestartButton()
	{
		restartButton.GetComponent<ButtonHelper>().EnableShowingImage();
		
	}
		
	public void UpdateTurnText()
	{
		statusText.SetTurnText();
	}

	public void PlayerWin()
	{
		playerScoreText.text = GameManager.instance.playerScore.ToString();

        resultPanel.SetActive(true);
        resultText.PlayerWin();
        

	}

	public void Tie()
	{
		tieScoreText.text = GameManager.instance.tieScore.ToString();
        resultPanel.SetActive(true);
        resultText.Tie();
	}

	public void ComputerWin()
	{
		computerScoreText.text = GameManager.instance.computerScore.ToString();
        resultPanel.SetActive(true);
        resultText.ComputerWin();
	}
}
