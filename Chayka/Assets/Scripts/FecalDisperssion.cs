using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FecalDisperssion : MonoBehaviour {
    public GameObject[] kakashki;
    public float f_value;
    public GameObject canvas;
    public bool people;


    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("WorldCanvas");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)


    {
        if (collision.gameObject.CompareTag("kak"))
        {
            GameData.gd.f_currentScore += f_value;
            Instantiate(collision.gameObject.GetComponent<Cacula>() .shlep, collision.contacts[0].point, Random.rotation,transform);
            GameObject fecal = Instantiate(kakashki[Random.Range(0, kakashki.Length)], collision.contacts[0].point, Quaternion.identity, transform);
            if (GetComponent<SpriteRenderer>() != null)
            {
                fecal.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder+1;
            }
            Destroy(collision.gameObject);
            transform.parent.GetComponent<Mob>().hitCount += 1;
            ScoreText(collision.contacts[0].point, collision);
            if (people&&GameData.gd.i_currentMission == 4 && !GameData.gd.b_m_missions[GameData.gd.i_currentMission, GameData.gd.i_currentMissionLvl])
            {
                GameData.gd.f_currentmissionResult++;
            }





        }
    }
    public void ScoreText(Vector2 point, Collision2D collision)
    {
        GameObject textred = Instantiate(collision.gameObject.GetComponent<Cacula>().textMesh, point, Quaternion.identity, canvas.transform);
        textred.GetComponent<Text>().text = f_value.ToString();
    }
}
