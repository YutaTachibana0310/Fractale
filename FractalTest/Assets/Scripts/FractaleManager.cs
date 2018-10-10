using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreateMode
{
	Fractal1,
	Fractal2
}

public class FractaleManager : MonoBehaviour
{
	private Fractal1 f1;
	private Fractal2 f2;
	public CreateMode mode = CreateMode.Fractal2;

	// Use this for initialization
	void Start()
	{
		f1 = GetComponent<Fractal1>();
		f2 = GetComponent<Fractal2>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			for(int i = 0; i < transform.childCount; i++)
			{
				Destroy(transform.GetChild(i).gameObject);
			}

			if(mode == CreateMode.Fractal1)
			{
				f1.CreateFractale1();
			}
			else
			{
				f2.CreateFractale2();
			}
		}
	}
}
