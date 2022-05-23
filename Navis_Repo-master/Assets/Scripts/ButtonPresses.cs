using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresses : MonoBehaviour
{
    public bool Up()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return true;
        }
        return false;
    }

    public bool Down()
    {
        if (Input.GetKey(KeyCode.S))
        {
            return true;
        }
        return false;
    }

    public bool Left()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return true;
        }
        return false;
    }

    public bool Right()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }

    public bool RotRight()
    {
        if (Input.GetKey(KeyCode.E))
        {
            return true;
        }
        return false;
    }

    public bool RotLeft()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            return true;
        }
        return false;
    }

    public bool Reset()
    {
        if (Input.GetKey(KeyCode.R))
        {
            return true;
        }
        return false;
    }
}
