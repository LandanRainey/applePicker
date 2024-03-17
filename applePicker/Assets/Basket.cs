using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get current screen pos of mouse from input
		Vector3 mousePos2D = Input.mousePosition;
		
		//Camera's z position sets how far to puse the mouse into 3D
		// if this line causes NullPointerRef, select Main Camera
		// in hierarchy and set its tag to MainCamerae in the  Inspector
		mousePos2D.z = -Camera.main.transform.position.z;
		
		//convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
		
		// move x position of basket to x position of mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
    }
	
	void OnCollisionEnter(Collision coll)
	{
			// find out what hit basket
			GameObject collidedWith = coll.gameObject;
			
			if(collidedWith.CompareTag("Apple")){
				Destroy(collidedWith);
			}
	}
}
