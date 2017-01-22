using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    private Rect playButton = new Rect(-1.1f, 12f, 2f, 0.7f);
    // Use this for initialization
    void Start () {
        ResizeSpriteToScreen();
        ScrollBackground(1000000);
    }
	
	// Update is called once per frame
	void Update () {
        ResizeSpriteToScreen();
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        ScrollBackground(scroll);
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("asd");
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Debug.Log(pos);
            Debug.Log(pos / transform.localScale.y);
            if (playButton.Contains(pos / transform.localScale.y))
            {
                SceneManager.LoadScene("asd");
            }
                
            
        }
    }

    void ScrollBackground(float amount)
    {
        if (amount == 0)
        {
            return;
        }
        amount = amount * -1;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        float top = sr.sprite.bounds.max.y * transform.localScale.y;
        float bottom = sr.sprite.bounds.min.y * transform.localScale.y;
        float worldScreenHeight = Camera.main.orthographicSize;
        float pos = transform.position.y;

        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(newPosition.y + amount * 10, bottom + worldScreenHeight, top - worldScreenHeight);
        transform.position = newPosition;

    }

    void ResizeSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null) return;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 scale = new Vector3(worldScreenWidth / width, worldScreenWidth / width);

        transform.localScale = scale;
    }
}
