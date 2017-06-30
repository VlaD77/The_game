using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board : MonoBehaviour 
{
	public const int empty_value = 0;
	public const int player_piece = 1;
	public const int computer_piece = 2;

	public static Board instance = null;    

	public int[,] winConfigs = new int[,]
	{
		{ 0, 1, 2 },
		{ 3, 4, 5 },
		{ 6, 7, 8 },
		{ 0, 3, 6 },
		{ 1, 4, 7 },
		{ 2, 5, 8 },
		{ 0, 4, 8 },
		{ 2, 4, 6 }
	};

	[HideInInspector]
	public Piece[] pieces;

	[HideInInspector]
	public int[] cells = new int[9];

	public Sprite playerPiece;
	public Sprite computerPiece;
    public Sprite[] swapSprite;
	void Awake()
	{
		if(instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
	}

	void Start()
	{
		pieces = transform.Find("Cells").GetComponentsInChildren<Piece>();
	}
		
	public void SetPiece(int piecePosition) 
	{
		cells[piecePosition] = GameManager.instance.isPlayerTurn ? player_piece : computer_piece;
	}
		
	public bool CheckForWinner()
	{
		return GameManager.instance.isPlayerTurn ? CheckPlayerWin() : CheckComputerWin();
	}

	public bool CheckPlayerWin() { return CheckWin(player_piece); }

	public bool CheckComputerWin()	{ return CheckWin(computer_piece); }

	private bool CheckWin(int piece)
	{
		for (int i = 0; i < winConfigs.GetLength(0); i++)
		{
			if(cells[winConfigs[i, 0]] == piece && cells[winConfigs[i, 1]] == piece && cells[winConfigs[i, 2]] == piece)
				return true;
		}

		return false;
	}
		
	public void DisableAllPieces()
	{
		foreach(var piece in pieces)
			piece.Disable();
	}
		
	public void RemoveAllPieces()
	{
		cells = new int[9];

		foreach(var piece in pieces)
		{
			piece.Enable();
			piece.RemoveImage();
		}
	}

	public Piece[] EmptyPieces()
	{
		var emptyPieces = new List<Piece>();

		for (int i = 0; i < cells.Length; ++i) 
		{
			if(cells[i] == empty_value)
				emptyPieces.Add(pieces[i]);
		}

		return emptyPieces.ToArray();
	}

    public void setPlayerX() {


        playerPiece = swapSprite[0];
        computerPiece = swapSprite[1];
} 

    public void setComputerX()
    {
        computerPiece = swapSprite[0];
        playerPiece = swapSprite[1];
        
    }

}
