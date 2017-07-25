using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public float audioVolume = 0.5f;
	public GameObject smoke;

	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print (breakableCount);
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();	
		timesHit = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision) {		
		AudioSource.PlayClipAtPoint(crack, transform.position, audioVolume);
		if (isBreakable) {
			HandleHits();
		}
		
	}
	
	void HandleHits() {
	
		timesHit++;		
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {
			breakableCount--;
			puffSmoke();
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void puffSmoke() {
		// on peut aussi écrire : 
		// GameObject smokePuff = Instantiate  (smoke, gameObject.transform.position, Quaternion.identity) as GameObject
		// point syntaxe C#
		GameObject smokePuff = (GameObject) Instantiate  (smoke, gameObject.transform.position, Quaternion.identity);
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("No Sprite to render. Brick sprite missing.");
		}
	}
	
}
