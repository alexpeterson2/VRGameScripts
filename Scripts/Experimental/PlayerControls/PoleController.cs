using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class PoleController : MonoBehaviour
{
	// Used to instantiate or destroy new particles to make rope longer or shorter
	public ObiRopeCursor cursor;
	// Obi rope used as the fishing line
	public ObiRope rope;

	// Use this for initialization
	void Start()
	{
		cursor = GetComponentInChildren<ObiRopeCursor>();
		rope = cursor.GetComponent<ObiRope>();
	}

	// Update is called once per frame
	void Update()
	{
        // Shortens the rope when A is held down
		if (OVRInput.Get(OVRInput.RawButton.A) || Input.GetKey(KeyCode.W))
		{
			if (rope.restLength > 2.5f)
				cursor.ChangeLength(rope.restLength - 1f * Time.deltaTime);
		}

        // Lengthens the rope when B is held down
		if (OVRInput.Get(OVRInput.RawButton.B) || Input.GetKey(KeyCode.S))
			cursor.ChangeLength(rope.restLength + 1f * Time.deltaTime);
	}
}
