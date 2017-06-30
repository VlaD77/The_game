using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public const int MIN_TURNS_TO_WIN = 4;
	public const int MAX_TURNS = 9;

	public static GameManager instance = null;    
	
	public int turnCount = 0;
	public bool isPlayerTurn = true;

	public int playerScore = 0;
	public int tieScore = 0;
	public int computerScore = 0;

    private HUD hud;
	private Board board;
	private AI ai;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}

	void Start()
	{
		hud = HUD.instance;
		board = Board.instance;
		ai = GetComponent<AI>();
	}

	public void PlayerMove(Piece piece)
	{
		Move(piece);
	}

	public void Move(Piece piece)
	{
		board.SetPiece(piece.gridPosition);
		SoundManager.instance.PlayRandomSetPieceSFX();

		if(CheckForWinner())
		{
			Win();
			return;
		}

		PassTurn();
        
        if (TurnsEnded())
		{
			Tie();
			return;
		}
		else
		{
			ToggleTurnPlayer();

			if(!isPlayerTurn)
				StartCoroutine(AIMove());
		}

	}

	private bool CheckForWinner()
	{
		var hasMinTurnsToCheckForWinner = (turnCount >= MIN_TURNS_TO_WIN);
		return hasMinTurnsToCheckForWinner && board.CheckForWinner();
	}

	private void Win()
	{
		if(isPlayerTurn) 
			PlayerWin();
		else
			AIWin();

		EndMatch();
	}

	private void PlayerWin()
	{
		playerScore++;
		hud.PlayerWin();
	}

	private void AIWin()
	{
		computerScore++;
		hud.ComputerWin();
	}

    private void Tie()
    {
        ToggleTurnPlayer();
        tieScore++;
        hud.Tie();
        EndMatch();
    }

    private void EndMatch()
	{
		board.DisableAllPieces();
		hud.EnableRestartButton();
	}
	
	private void PassTurn()
	{
		turnCount++;
	}

	private bool TurnsEnded() 
	{
		return turnCount == MAX_TURNS;
	}

	private void ToggleTurnPlayer()
	{
		isPlayerTurn = !isPlayerTurn;
		hud.UpdateTurnText();
	}
		
	IEnumerator AIMove(float delayTime = 1f)
	{
		yield return new WaitForSeconds(delayTime);
		Piece aiPiece = ai.MovePiece();
		Move(aiPiece);
	}

	public void RestartGame()
	{
		turnCount = 0;
		hud.Restart();
		board.RemoveAllPieces();

        if (!isPlayerTurn)
        {
            board.setComputerX();
            StartCoroutine(AIMove(.4f));
        }
        else { board.setPlayerX(); }
	}

	public void BackToMenu()
	{
        ResetData();
        SceneManager.LoadScene("Menu");

    }
    public void ResetData() {

        turnCount = 0;
        playerScore = 0;
        tieScore = 0;
        computerScore = 0;

        hud.Restart();
        board.RemoveAllPieces();

    }
}
