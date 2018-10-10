using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal2 : MonoBehaviour
{
	class Point
	{
		public Vector2 pos;
		public float height;

		public Point(Vector2 pos, float hight)
		{
			this.pos = pos;
			this.height = hight;
		}

		public Point()
		{

		}
	}

	private Vector2 A = new Vector2(0, 0);
	private Vector2 B = new Vector2(4, 0);
	private Vector2 C = new Vector2(0, 4);
	private Vector2 D = new Vector2(4, 4);

	public GameObject cube;
	private const float r = 2f;

	// Use this for initialization
	void Start()
	{
		Initialize(A, B, C, D);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void Initialize(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
	{
		Point center = new Point(new Vector2(a.x + (b.x - a.x) / 2, a.y + (c.y - a.y) / 2), 8f);

		GameObject go = Instantiate(cube);
		Vector3 scale = go.transform.localScale;
		scale.y = center.height * 0.1f;
		go.transform.localScale = scale;
		go.transform.position = new Vector3(center.pos.x, scale.y / 2, center.pos.y);

		Point topL = new Point(c, Random.Range(4f, 8f));
		Point topR = new Point(d, Random.Range(4f, 8f));
		Point bottomL = new Point(a, Random.Range(4f, 8f));
		Point bottomR = new Point(b, Random.Range(4f, 8f));

		Point top = new Point();
		top.pos = new Vector2(center.pos.x, c.y);
		top.height = (topL.height + topR.height) / 2;

		Point bottom = new Point();
		bottom.pos = new Vector2(center.pos.x, a.y);
		bottom.height = (bottomL.height + bottomR.height) / 2;

		Point left = new Point();
		left.pos = new Vector2(a.x, center.pos.y);
		left.height = (topL.height + bottomR.height) / 2;

		Point right = new Point();
		right.pos = new Vector2(b.x, center.pos.y);
		right.height = (topR.height + bottomR.height) / 2;

		Create(top, topL, center, left, 4f);
		Create(topR, top, right, center, 4f);
		Create(center, left, bottom, bottomL, 4f);
		Create(right, center, bottomR, bottom, 4f);

	}

	void Create(Point tr, Point tl, Point br, Point bl, float randomRange)
	{
		if(Mathf.Abs(tr.pos.x - tl.pos.x) < cube.transform.localScale.x)
		{
			return;
		}

		Point c = new Point();
		c.pos = new Vector2(tl.pos.x + (tr.pos.x - tl.pos.x) / 2, bl.pos.y + (tl.pos.y - bl.pos.y) / 2);
		c.height = (tl.height + tr.height + bl.height + br.height) / 4 + Random.Range(-randomRange, randomRange);

		GameObject go = Instantiate(cube);
		Vector3 scale = go.transform.localScale;
		scale.y = c.height * 0.1f;
		go.transform.localScale = scale;
		go.transform.position = new Vector3(c.pos.x, scale.y / 2, c.pos.y);

		Point t = new Point();
		t.pos = new Vector2(c.pos.x, tr.pos.y);
		t.height = (tr.height + tl.height) / 2;

		Point b = new Point();
		b.pos = new Vector2(c.pos.x, br.pos.y);
		b.height = (br.height + bl.height) / 2;

		Point l = new Point();
		l.pos = new Vector2(bl.pos.x, c.pos.y);
		l.height = (bl.height + tl.height) / 2;

		Point r = new Point();
		r.pos = new Vector2(br.pos.x, c.pos.y);
		r.height = (br.height + tr.height) / 2;

		Create(t, tl, c, l, randomRange / 2);
		Create(tr, t, r, c, randomRange / 2);
		Create(c, l, b, bl, randomRange / 2);
		Create(r, c, br, b, randomRange / 2);

		return;
	}
}
