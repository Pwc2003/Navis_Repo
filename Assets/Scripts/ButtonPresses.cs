using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresses : MonoBehaviour
{
    public bool W()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return true;
        }
        return false;
    }

    public bool S()
    {
        if (Input.GetKey(KeyCode.S))
        {
            return true;
        }
        return false;
    }

    public bool A()
    {
        if (Input.GetKey(KeyCode.A))
        {
            return true;
        }
        return false;
    }

    public bool D()
    {
        if (Input.GetKey(KeyCode.D))
        {
            return true;
        }
        return false;
    }

    public bool E()
    {
        if (Input.GetKey(KeyCode.E))
        {
            return true;
        }
        return false;
    }

    public bool Q()
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

    public bool Shift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            return true;
        }
        return false;
    }

    public bool ShiftQ()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
        {
            return true;
        }
        return false;
    }

    public bool LeAr()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return true;
        }
        return false;
    }

    public bool RiAr()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    } 
}
