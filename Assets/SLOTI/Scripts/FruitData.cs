using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Fruit
{
    Cavun,
    GreenPear,
    Orange,
    Pinaple,
    RedOrange,
    YeallowPear,

}

public class FruitData : MonoBehaviour
{
    
    [SerializeField] private float prize = 0;
    [SerializeField] private int indexFruit = 0; 
    [SerializeField] private GameObject greenSquad;
    
    public GameObject mainParticle;
    public Fruit fruit;


    public float Prize { get => prize;}
    public int IndexFruit { get => indexFruit;}


    public void fruitWin()
    {
        if (mainParticle != null)
        {
            mainParticle.SetActive(true);
        }
        
    }

    public void redyToSpin() 
    {
        if (mainParticle != null)
        {
            mainParticle.SetActive(false);
        }
    }


}
