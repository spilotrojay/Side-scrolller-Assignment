using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerGo : MonoBehaviour {

	
	public GameObject GameManager;
	public Text LivesUIText;
	public float speed;
	const int MaxLives = 3; //max player lives
	int lives;//current player lives
	
     
 


	public void Init()
	{
		lives = MaxLives;

		//update the lives UI text
		LivesUIText.text = lives.ToString();

		//reset player position to the center of the screen
		transform.position = new Vector2(-5.81f,-2.6f);

		//set this player game object to active
		gameObject.SetActive(true);
	}
	// Use this for initialization
	void Start () {
	
	}
	void Update(){
		float x = Input.GetAxisRaw ("Horizontal");//the value will be -1,0,1 fro left ,noinput, right
        float y = Input.GetAxisRaw ("Vertical");

        //compute a direction vector, amd we normmalise it to get a unit vector
        Vector2 direction = new Vector2(x,y).normalized;

        //call the function that conputes and sets the players position
        Move (direction);
	}
	  void Move(Vector2 direction)
    {
        //find the screen liits the player movement
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y - 0.285f;

        //get the palyers current pos
        Vector2 pos = transform.position;

        //calculate the new positiion
        pos += direction * speed * Time.deltaTime;

        //make sure the new positio n is outside the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //update the players position
        transform.position = pos;


    }

}
