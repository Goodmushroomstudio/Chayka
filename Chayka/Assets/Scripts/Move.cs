using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        transform.position -= new Vector3(GameData.gd.f_speed, 0, 0);
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 15)
        {
            switch(this.gameObject.tag)
            {
                case "Cloud":
                    transform.parent.GetComponent<World>().NewGeneration();
                    Destroy(this.gameObject);
                    return;
                case "Water":
                    transform.position += new Vector3(50,0,0);
                    return;
                case "lodka":
                    transform.position += new Vector3(50, 0, 0);
                    return;
                case "fish":
                    transform.position += new Vector3(50, 0, 0);
                    return;


            }

               
            

        }
        
	}
}
