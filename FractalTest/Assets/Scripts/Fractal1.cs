using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal1 : MonoBehaviour
{
	class Point1
	{
		public float x;
		public float height;

		public Point1(float x, float height)
		{
			this.x = x;
			this.height = height;
		}
	}

	private const float A = 0f, B = 8f;
	public GameObject cube;
	private const float r = 2f;

	// Use this for initialization
	public void CreateFractale1()
	{
		Initialize(A, B);
	}

	void Initialize(float Start, float End)
	{
		Point1 center = new Point1(Start + (End - Start) / 2, 8f);

		//中心にキューブ作成
		GameObject go = Instantiate(cube);
		Vector3 scale = go.transform.localScale;
		scale.y = center.height * 0.1f;
		go.transform.localScale = scale;
		go.transform.position = new Vector3(center.x, scale.y / 2, 0f);
		go.transform.parent = transform;

		Create(new Point1(Start, 0), center, 2f);
		Create(center, new Point1(End, 0), 2f);
	}

	void Create(Point1 Start, Point1 End, float randomRange)
	{
		if(Mathf.Abs(End.x - Start.x) < cube.transform.localScale.x)
		{
			return;
		}

		Point1 c = new Point1(Start.x + (End.x - Start.x) / 2, Start.height + (End.height - Start.height) / 2);

		c.height += Random.Range(-randomRange, randomRange);

		GameObject go = Instantiate(cube);
		Vector3 scale = go.transform.localScale;
		scale.y = c.height * 0.1f;
		go.transform.localScale = scale;
		go.transform.position = new Vector3(c.x, scale.y / 2, 0f);
		go.transform.parent = transform;

		Create(Start, c, randomRange / 2);
		Create(c, End, randomRange / 2);

		return;
	}
}
