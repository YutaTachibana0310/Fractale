using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal1 : MonoBehaviour
{
	class Point
	{
		public float x;
		public float height;

		public Point(float x, float height)
		{
			this.x = x;
			this.height = height;
		}
	}

	private const float A = 0f, B = 8f;
	public GameObject cube;
	private const float r = 2f;

	// Use this for initialization
	void Start()
	{
		Initialize(A, B);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//Fractal(A, B, 10.0f);
		}
	}

	void Initialize(float Start, float End)
	{
		Point center = new Point(Start + (End - Start) / 2, 8f);

		//中心にキューブ作成
		GameObject go = Instantiate(cube);
		Vector3 scale = go.transform.localScale;
		scale.y = center.height * 0.1f;
		go.transform.localScale = scale;
		go.transform.position = new Vector3(center.x, scale.y / 2, 0f);

		Create(new Point(Start, 0), center, 2f);
		Create(center, new Point(End, 0), 2f);
	}

	void Create(Point Start, Point End, float randomRange)
	{
		if(Mathf.Abs(End.x - Start.x) < cube.transform.localScale.x)
		{
			return;
		}

		Point c = new Point(Start.x + (End.x - Start.x) / 2, Start.height + (End.height - Start.height) / 2);

		c.height += Random.Range(-randomRange, randomRange);

		GameObject go = Instantiate(cube);
		Vector3 scale = go.transform.localScale;
		scale.y = c.height * 0.1f;
		go.transform.localScale = scale;
		go.transform.position = new Vector3(c.x, scale.y / 2, 0f);

		Create(Start, c, randomRange / 2);
		Create(c, End, randomRange / 2);

		return;
	}
}
