using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {
    public static int w = 10; // width
    public static int h = 13; // height
    public static Element[,] elements = new Element[w, h];

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    

    public static bool mineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            return elements[x, y].mine;
        }
            
        return false;
    }

    public static void uncoverMines()
    {
        foreach (Element elem in elements)
        {
            if (elem.mine)
            {
                elem.LoadTexture(0);
            }
        }
    }



    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1)) ++count; // top
        if (mineAt(x + 1, y + 1)) ++count; // top-right
        if (mineAt(x + 1, y)) ++count; // right
        if (mineAt(x + 1, y - 1)) ++count; // bottom-right
        if (mineAt(x, y - 1)) ++count; // bottom
        if (mineAt(x - 1, y - 1)) ++count; // bottom-left
        if (mineAt(x - 1, y)) ++count; // left
        if (mineAt(x - 1, y + 1)) ++count; // top-left

        return count;
    }

    public static void FFuncover(int x, int y, bool[,] visited) {
    
    if (x >= 0 && y >= 0 && x < w && y < h) {
       
        if (visited[x, y])
            return;


            elements[x, y].LoadTexture(adjacentMines(x, y));

        
        if (adjacentMines(x, y) > 0)
            return;

      
        visited[x, y] = true;

        
        FFuncover(x-1, y, visited);
        FFuncover(x+1, y, visited);
        FFuncover(x, y-1, visited);
        FFuncover(x, y+1, visited);
    }
}
    public static bool isFinished()
    {
        // Try to find a covered element that is no mine
        foreach (Element elem in elements)
            if (elem.isCovered() && !elem.mine)
                return false;
        // There are none => all are mines => game won.
        return true;
    }

}
