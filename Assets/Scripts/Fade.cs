using UnityEngine;

public class Fade : MonoBehaviour
{
	public float fadeSpeed = 1.25f;
	private int fadeDirection = -1;

	private Color colorGUI = Color.white;

	private void OnGUI()
	{
		colorGUI.a = Mathf.Clamp01(colorGUI.a + fadeDirection * fadeSpeed * Time.deltaTime);

		GUI.depth = -1000;
		GUI.color = colorGUI;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
	}

	public float BeginFade(int direction)
	{
		fadeDirection = direction;
		return (1 / fadeSpeed);
	}
}
