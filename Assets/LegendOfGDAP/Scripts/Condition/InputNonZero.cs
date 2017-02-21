using UnityEngine;
using System.Collections;

public class InputNonZero : Condition {

    public enum axis
    {
        movement,
        attack,
        item
    }

    public axis Axis;
	override public bool Eval()
    {
        if(Axis == axis.movement)
        {
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(Axis == axis.attack)
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (Axis == axis.item)
        {
            if (Input.GetAxis("Fire2") != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
}
