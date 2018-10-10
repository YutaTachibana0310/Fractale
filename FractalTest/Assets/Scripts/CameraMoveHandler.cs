using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveHandler : MonoBehaviour
{
	private const float moveSpeed = 0.1f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.position += new Vector3(0, 0, moveSpeed);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.position -= new Vector3(0, 0, moveSpeed);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= new Vector3(moveSpeed, 0, 0);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3(moveSpeed, 0, 0);
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += new Vector3(0, moveSpeed, 0f);
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= new Vector3(0, moveSpeed, 0);
		}
	}
}
