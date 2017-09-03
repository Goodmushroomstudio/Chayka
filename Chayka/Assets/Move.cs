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
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Vector3.zero).x - 10)
        {
            switch(this.gameObject.tag)
            {
                case "Cloud":
                    transform.parent.GetComponent<World>().NewGeneration();
                    Destroy(this.gameObject);
                    return;
                case "Water":
                    transform.parent.GetComponent<World>().GenerationWater(transform.position);
                    Destroy(this.gameObject);
                    return;
            }

                transform.parent.GetComponent<World>().NewGeneration();
                Destroy(this.gameObject);

            

        }
        
	}
}
