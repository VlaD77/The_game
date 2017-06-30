using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Piece : MonoBehaviour 
{
	private Image component_image;
	private Button component_button;
	private ButtonHelper component_buttonHelper;
	public int gridPosition;

	void Start () 
	{
		component_image = GetComponent<Image>();
		component_button = GetComponent<Button>();
		component_buttonHelper = GetComponent<ButtonHelper>();

		component_button.onClick.AddListener(PlayerSetPiece);
	}

	public void PlayerSetPiece()
	{
		if(GameManager.instance.isPlayerTurn)
		{
			SetPiece();
			GameManager.instance.PlayerMove(this);
		}
	}

	public void SetPiece() 
	{
		SetImage();
		Disable();
	}
		
	void SetImage()
	{
		var grid = Board.instance;
		var gameManager = GameManager.instance;

		component_image.sprite = gameManager.isPlayerTurn ? grid.playerPiece : grid.computerPiece;
		component_buttonHelper.SetImageAlpha(1);
		
	}

	public void RemoveImage()
	{
		component_image.sprite = null;
		component_buttonHelper.SetImageAlpha(0);
	}

	public void Enable()
	{
		component_button.enabled = true;
	}

	public void Disable()
	{
		component_button.enabled = false;
	}
}
