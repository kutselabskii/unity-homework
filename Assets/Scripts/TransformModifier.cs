using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformModifier : MonoBehaviour
{
	void Start()
	{
		
	}

	void Update()
	{
		transform.Rotate(new Vector3(30f, 15f, 10f) * Time.deltaTime);
	}
}
