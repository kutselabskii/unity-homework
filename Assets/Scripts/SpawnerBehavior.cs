using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
	public GameObject Object;
	public int Count = 1000;
	public int CountPerFrame = 100;

	void Start()
	{
		StartCoroutine(InstanceObjects());
	}

	void Update()
	{
		
	}

	IEnumerator InstanceObjects()
	{
		const float min = 0;
		const float max = 50f;

		Vector3 position;

		for (var i = 0; i < Count; ++i) {
			if (i % CountPerFrame == 0) {
				yield return new WaitForEndOfFrame();
			}
			position = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
			Instantiate(Object, position, new Quaternion());
		}
	}
}
