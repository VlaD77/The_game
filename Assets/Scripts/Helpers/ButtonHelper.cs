using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHelper : MonoBehaviour 
{
	private Button _button;
	private Image _image;

	void Start()
	{
		_button = GetComponent<Button>();
		_image = GetComponent<Image>();
	}

	public void EnableShowingImage() 
	{
		_button.enabled = true;
		SetImageAlpha(1);
	}
	
	public void DisableHidingImage() 
	{
		_button.enabled = false;
		SetImageAlpha(0);
	}

	public void SetImageAlpha(int alpha)
	{
		var currentColor = _image.color;
		currentColor.a = alpha;
		_image.color = currentColor;
	}
}
