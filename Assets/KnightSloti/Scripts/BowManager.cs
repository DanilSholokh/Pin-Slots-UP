using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowManager : MonoBehaviour
{

    private ArrowController currentArrow;

    [SerializeField] BowWallLogic bowWallLogic;

    public ArrowController CurrentArrow { get => currentArrow;}

    public void shoot()
    {
        if (CurrentArrow != null)
        {
            CurrentArrow.MoveUp.IsUp = true;
            createArrow();
        }

    }


    public void createArrow()
    {
        if (bowWallLogic.isCountArrow())
        {
            currentArrow = Instantiate(bowWallLogic.getArrow(), gameObject.transform);
            CurrentArrow.BowManager = this;
            CurrentArrow.BowWallLogic = bowWallLogic;
        }
        else
        {
            currentArrow = null;
        }

    }    

}
