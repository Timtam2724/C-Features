using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variable
{
	// This script depends on the SpriteRender component attached to the same GameObject
	[RequireComponent(typeof(SpriteRenderer))]
public class ScreenWrap : MonoBehaviour {
		//Sprite
		private SpriteRenderer spriteRenderer;
		//Camera
		private Bounds camBounds;
		private float camWidth;
		private float camHeight;

	void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer> ();
		}
			
	void UpdateCameraBounds () 
	{
	  // Calculate camera bounds
			Camera cam = Camera.main;
			camHeight = 2f * cam.orthographicSize;
			camWidth = camHeight * cam.aspect;
			camBounds = new Bounds (cam.transform.position, new Vector2 (camWidth, camHeight));
	}
	// Use Late Update since we are using the camera to wrap objects back around
	void LateUpdate () 
		{
			UpdateCameraBounds ();
			//store position and size in shorter variable names
			Vector3 pos = transform.position; // position of our enemy
			Vector3 size = spriteRenderer.bounds.size; // the size of the enemy
			// caculate the sprites half width and height
			float halfWidth = size.x / 2f;
			float halfHeight = size.y / 2f;
			float halfCamWidth = camWidth / 2f;
			float halfCamHeight = camHeight / 2f;
			// Check Left
			if(pos.x + halfWidth < camBounds.min.x)
			{
				pos.x = camBounds.max.x + halfWidth;
			}
			// Check Right
			if(pos.x - halfWidth > camBounds.max.x)
			{
				pos.x = camBounds.min.x - halfWidth;
			}
			// Check Top
			if(pos.y - halfHeight > camBounds.max.y)
			{
				pos.y = camBounds.min.y - halfHeight;	
			}
			// Check Bottom
			if(pos.y + halfHeight < camBounds.min.y)
			{
				pos.y = camBounds.max.y + halfHeight;	
			}
			// set new position
			transform.position = pos;
	    }
}
}
