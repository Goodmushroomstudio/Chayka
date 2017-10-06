using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BichControll : MonoBehaviour {
    public GameObject[] sand;
    public GameObject[] people;
    public GameObject[] decor;
    public GameObject[] umbrella;
    public GameObject[] peopleDown;
	// Use this for initialization
	void Start () {
        int r = Random.Range(7, 10);
        for (int i = 0;i<r;i++)
        {
            PeopleDownGeneration();
            PeopleGeneration();
            UmbrellaGeneration();
            DecorGeneration();

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void PeopleGeneration()
    {
        Vector3 coord = new Vector3(Random.Range(GetComponent<SpriteRenderer>().bounds.min.x+1, GetComponent<SpriteRenderer>().bounds.max.x-1), Random.Range(GetComponent<SpriteRenderer>().bounds.min.y+1, GetComponent<SpriteRenderer>().bounds.max.y));
        GameObject newPeeople = Instantiate(people[Random.Range(0,people.Length)], coord, Quaternion.identity, transform);
        if(!Proverka(coord))
        {
            Destroy(newPeeople.gameObject);
        }

    }
    void UmbrellaGeneration()
    {
        Vector3 coord = new Vector3(Random.Range(GetComponent<SpriteRenderer>().bounds.min.x+1, GetComponent<SpriteRenderer>().bounds.max.x-1), Random.Range(GetComponent<SpriteRenderer>().bounds.min.y + 1, GetComponent<SpriteRenderer>().bounds.max.y));
        GameObject newUmbrella = Instantiate(umbrella[Random.Range(0, umbrella.Length)], coord, Quaternion.identity, transform);
        if (!Proverka(coord))
        {
            Destroy(newUmbrella.gameObject);
        }
    }
    void DecorGeneration()
    {
        Vector3 coord = new Vector3(Random.Range(GetComponent<SpriteRenderer>().bounds.min.x, GetComponent<SpriteRenderer>().bounds.max.x),GetComponent<SpriteRenderer>().bounds.max.y - 1);
        GameObject newDecor = Instantiate(decor[Random.Range(0, decor.Length)], coord, Quaternion.identity, transform);
        if (!Proverka(coord))
        {
            Destroy(newDecor.gameObject);
        }
    }
    void PeopleDownGeneration()
    {
        Vector3 coord = new Vector3(Random.Range(GetComponent<SpriteRenderer>().bounds.min.x+1, GetComponent<SpriteRenderer>().bounds.max.x-1), Random.Range(GetComponent<SpriteRenderer>().bounds.min.y+1.5f , GetComponent<SpriteRenderer>().bounds.max.y-0.5f));
        GameObject newPeopleDown = Instantiate(peopleDown[Random.Range(0, peopleDown.Length)], coord, Quaternion.identity, transform);
        if (!Proverka(coord))
        {
            Destroy(newPeopleDown.gameObject);
        }
    }

    bool Proverka(Vector3 currentPos)
    {
        bool ret = true;
        if(transform.childCount>0)
        {
            for (int i = 0; i < transform.childCount-1; i++)
            {
                if (Vector3.Magnitude(currentPos - transform.GetChild(i).transform.position) <0.9f)
                {
                    ret = false;
                }
            }
        }
        return ret;
    }
}
