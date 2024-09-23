using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManagerInstance;
    public int WrongsBalls;
    private void Start()
    {
        if(levelManagerInstance == null)
        {
            levelManagerInstance = new LevelManager();
        }
    }
}
