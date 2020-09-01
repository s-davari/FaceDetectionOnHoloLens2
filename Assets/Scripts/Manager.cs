﻿using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	// Textbox Management
	TextMesh msgFace;
	TextMesh msgVoice;
	bool showIP;

	// Context Management
	public bool isTalking;
	public int num_faces;
	public List<List<int>> faces_box;

	// PhotoCapture Variables
	public byte[] imageBufferBytesArray;
	public Matrix4x4 cameraToWorldMatrix;
	public Matrix4x4 projectionMatrix;

	// Test
	bool test;

	private void Start()
	{
		// Textbox Management
		showIP = true;
		msgFace = GameObject.Find("MessageFace").GetComponent<TextMesh>();
		msgVoice = GameObject.Find("MessageVoice").GetComponent<TextMesh>();
		msgFace.text = "Connect Face detection to the IP Address: " + GetComponent<NetworkCon>().ipEndPoint;

		// Context Management
		faces_box = new List<List<int>>();
		isTalking = false;
		num_faces = 0;

		// Test
		test = true;
	}

	private void Update()
	{
		UpdateTestboxes();
	}

	private void UpdateTestboxes()
	{
		if (showIP)
		{
			if (num_faces == 0)
			{
				msgFace.text = "Connect Face detection to the IP Address: " + GetComponent<NetworkCon>().ipEndPoint.Substring(0, GetComponent<NetworkCon>().ipEndPoint.Length - 5);
			}
			else
			{
				msgFace.text = "Number of faces: " + num_faces.ToString();
				showIP = false;
			}
		}
		// Update text 
		else
			msgFace.text = "Number of faces: " + num_faces.ToString();
		msgVoice.text = "Ongoing conversation: " + isTalking;
	}


	// Used in App manager
	public bool InConversation()
	{
		if (num_faces > 0 && isTalking)
		{
			return true;
		}
		return false;
	}

	//private void drawLineRenderer()
	//{
	//	LineRenderer axisRenderer;
	//	if (test)
	//		axisRenderer = gameObject.AddComponent<LineRenderer>();
	//	else
	//		axisRenderer = GetComponent<LineRenderer>();

	//	axisRenderer.material = new Material(Shader.Find("Unlit/Texture"));
	//	axisRenderer.startWidth = 0.02f;
	//	axisRenderer.endWidth = 0.02f;
	//	axisRenderer.positionCount = 4;

	//	axisRenderer.startColor = Color.cyan;
	//	axisRenderer.endColor = Color.cyan;
	//	axisRenderer.material.color = Color.cyan;
	//	axisRenderer.SetPosition(0, new Vector3(Screen.width - faces_box[0][0], Screen.height - faces_box[0][1]));
	//	axisRenderer.SetPosition(1, new Vector3(Screen.width - faces_box[0][0], Screen.height - faces_box[0][3]));
	//	axisRenderer.SetPosition(2, new Vector3(Screen.width - faces_box[0][2], Screen.height - faces_box[0][3]));
	//	axisRenderer.SetPosition(3, new Vector3(Screen.width - faces_box[0][2], Screen.height - faces_box[0][1]));
	//	test = false;
	//}
}