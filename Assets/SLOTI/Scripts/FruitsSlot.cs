using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSlot : MonoBehaviour
{

    [SerializeField] private int indexSpin = 0;
    Vector3 startPosSlot;

    public List<FruitData> fruitDatas;


    public Vector3 StartPosSlot { get => startPosSlot; set => startPosSlot = value; }
    public int IndexSpin { get => indexSpin; set => indexSpin = value; }


    private void Start()
    {
        initStartPos();
    }

    public void initStartPos()
    {
        StartPosSlot = transform.localPosition;

    }

    public void prepareFruits()
    {
        for (int i = 0; i < fruitDatas.Count; i++)
        {
            fruitDatas[i].redyToSpin();
        }
    }


}
