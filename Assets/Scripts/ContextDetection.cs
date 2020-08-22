﻿using System.Collections.Generic;
using UnityEngine;

public class ContextDetection : MonoBehaviour
{
	TextMesh msgFace;
	TextMesh msgVoice;
	public int num_faces;
	public List<List<int>> faces_box;
	public bool isTalking;

	bool test;

	private void Start()
	{
		isTalking = false;
		msgFace = GameObject.Find("MessageFace").GetComponent<TextMesh>();
		msgVoice = GameObject.Find("MessageVoice").GetComponent<TextMesh>();
		faces_box = new List<List<int>>();

		test = true;
	}
	 private void drawLineRenderer()
	{
		//LineRenderer axisRenderer;
		//if (test)
		//	axisRenderer = gameObject.AddComponent<LineRenderer>();
		//else
		//	axisRenderer = GetComponent<LineRenderer>();

		//axisRenderer.material = new Material(Shader.Find("Unlit/Texture"));
		//axisRenderer.startWidth = 0.02f;
		//axisRenderer.endWidth = 0.02f;
		//axisRenderer.positionCount = 4;

		//axisRenderer.startColor = Color.cyan;
		//axisRenderer.endColor = Color.cyan;
		//axisRenderer.material.color = Color.cyan;
		//axisRenderer.SetPosition(0, new Vector3( Screen.width - faces_box[0][0], Screen.height - faces_box[0][1]));
		//axisRenderer.SetPosition(1, new Vector3(Screen.width - faces_box[0][0], Screen.height - faces_box[0][3]));
		//axisRenderer.SetPosition(2, new Vector3(Screen.width - faces_box[0][2], Screen.height - faces_box[0][3]));
		//axisRenderer.SetPosition(3, new Vector3(Screen.width - faces_box[0][2], Screen.height - faces_box[0][1]));
		test = false;
	}

	private void Update()
	{
		// Update text 
		msgFace.text = "Number of faces: " + num_faces.ToString();
		msgVoice.text = "Ongoing conversation: " + isTalking; 

	}

	public bool InConversation()
	{
		if (num_faces > 0 && isTalking)
		{
			// Extras////////////////////////
			drawLineRenderer();
			return true;
		}
		return false;
	}
}
