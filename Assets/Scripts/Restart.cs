﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {
    

   public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
