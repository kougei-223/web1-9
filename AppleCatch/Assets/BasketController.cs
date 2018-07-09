using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource and;
    GameObject director;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.and = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Apple") {
            this.director.GetComponent<Gamedirector>().GetApple();
            this.and.PlayOneShot(this.appleSE);
        } else {
            this.director.GetComponent<Gamedirector>().GetBomb();
            this.and.PlayOneShot(this.bombSE);
        }
        Destroy(other.gameObject);
    }

    // Use this for initialization
  
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
	}
}
