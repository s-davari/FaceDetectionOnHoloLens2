﻿using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Manager : MonoBehaviour
{
	// Textbox Management
	TextMesh msgVoice;
	TextMesh msgFace;

	// Context Management
	public bool isTalking;
	private MySpeechContext speechContext;
	public int num_faces;
	public List<List<int>> faces_box;

//#if UNITY_EDITOR
	//private void Awake()
	//{

		//PlayerSettings.MTRendering = true;
		//PlayerSettings.graphicsJobs = true;
		//PlayerSettings.graphicsJobMode = GraphicsJobMode.Legacy;
		//SystemInfo.renderingthread
	//}
//#endif
	private void Start()
	{
		speechContext = MySpeechContext.None;
		// Textbox Management
		msgFace = GameObject.Find("MessageFace").GetComponent<TextMesh>();
		msgVoice = GameObject.Find("MessageVoice").GetComponent<TextMesh>();
		msgFace.text = "Connect Face detection to the IP Address: " + MyPhotoCapture.ipEndPoint;

		// Context Management
		faces_box = new List<List<int>>();
		isTalking = false;
		num_faces = 0;

	}


	private void Update()
	{

		// Update the text boxes
		if (num_faces > 0)
			AppManager.GetChildWithName(Camera.main.gameObject, "incommingConvo").SetActive( true);
		else
			AppManager.GetChildWithName(Camera.main.gameObject, "incommingConvo").SetActive(false);
		msgFace.text = "Number of faces: " + num_faces.ToString();

		if(!isTalking || speechContext == MySpeechContext.None)
			msgVoice.text = "Speech: " + isTalking;
		else 
			msgVoice.text = "Speech about " + speechContext;

	}


	public void Set_SpeechContext(int context)
	{
		speechContext = (MySpeechContext)context;
		int n = (int)speechContext;
		print(speechContext + n.ToString());
	}
	public string Get_SpeechContext()
	{
		int n = (int)speechContext;
		return speechContext + n.ToString();
	}

	internal void SetFaces(int n_faces, List<List<int>> faces)
	{
		num_faces = n_faces;
		faces_box = faces;
	}
}

