using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
	public float force = 200f;

	public string[] keywords = new string[] {"left", "right"};
	public ConfidenceLevel confidence = ConfidenceLevel.Medium;
	protected PhraseRecognizer recognizer;

	void Start()
	{
		if (keywords != null)
		{
			recognizer = new KeywordRecognizer(keywords, confidence);
			recognizer.OnPhraseRecognized += OnKeywordRecognized;
			recognizer.Start();
		}
	}

	private void OnKeywordRecognized(PhraseRecognizedEventArgs args)
	{
		if (args.text == "left")
			TurnLeft(force * 5);
		if (args.text == "right")
			TurnRight(force * 5);
	}

	private void OnApplicationQuit()
	{
		if (recognizer != null && recognizer.IsRunning)
			recognizer.Stop();
	}

	private void TurnRight(float force)
	{
		Rigidbody player;
		player = GetComponent<Rigidbody>();

		player.AddForce(force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
	}

	private void TurnLeft(float force)
	{
		Rigidbody player;
		player = GetComponent<Rigidbody>();

		player.AddForce(-force * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
	}
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			TurnRight(force);
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			TurnLeft(force);
	}
}