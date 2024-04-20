using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    
    public List<FruitsSlot> slotsList;


    private int x, y = 3;




    public int getX()
    {
        x = slotsList.Count;
        return x;
    }

    public int getY()
    {
        return y;
    }



    public void ganarateDataResultSlots(FruitData[,] table)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                table[i, j] = slotsList[i].fruitDatas[slotsList[i].IndexSpin + j];
            }

        }
    }

    public void prepareSlotsToSpin()
    {
        for (int i = 0; i < slotsList.Count; i++)
        {
            slotsList[i].prepareFruits();
        }
    }





}
