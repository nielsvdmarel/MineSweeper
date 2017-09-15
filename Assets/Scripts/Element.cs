using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
    public bool mine = false;
    [SerializeField]
    private Sprite[] emptyTextures;
    [SerializeField]
    private Sprite mineTextures;
    public bool isDead = false;
    public GameObject restart;
    public bool isCovered()
    
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Blok";
    }

	
	void Start ()
    {
        restart.SetActive(false);
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y =(int)transform.position.y;
        Grid.elements[x, y] = this;
	}
	
	
	void Update ()
    {
		
	}

    public void LoadTexture(int adjacentCount)
    {
        if (mine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTextures;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
        }
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("hit");
        if (mine)
        {
            isDead = true;
            Grid.uncoverMines();
            Debug.Log("You Lose");
            restart.SetActive(true);
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            LoadTexture(Grid.adjacentMines(x, y));

            Grid.FFuncover(x, y, new bool[Grid.w, Grid.h]);

            if (Grid.isFinished())
            {
                Debug.Log("You Win");
            }
        }
    }


}
