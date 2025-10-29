using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public int Throw;

    public bool canMove = true;
    public bool canJump = true;
    public bool canLook = true;
}
