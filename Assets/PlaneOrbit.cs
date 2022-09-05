using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneOrbit : MonoBehaviour
{
	public float xSpread;
	public float zSpread;
	public float yOffset;
	public Transform centerPoint;

	public float rotSpeed;
	public bool rotateClockwise;

	public float objRotationSpeed;

	float timer = 0;

	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime * rotSpeed;
		Rotate();
	}

	void Rotate()
	{
		if (rotateClockwise)
		{
			float x = -Mathf.Cos(timer) * xSpread;
			float z = Mathf.Sin(timer) * zSpread;
			Vector3 pos = new Vector3(x, yOffset, z);
			transform.position = pos + centerPoint.position;
			transform.Rotate(Vector3.up * Time.deltaTime * objRotationSpeed);
		}
		else
		{
			float x = Mathf.Cos(timer) * xSpread;
			float z = Mathf.Sin(timer) * zSpread;
			Vector3 pos = new Vector3(x, yOffset, z);
			transform.position = pos + centerPoint.position;
			transform.Rotate(new Vector3(0, objRotationSpeed, 0) * Time.deltaTime);
		}
	}
}
