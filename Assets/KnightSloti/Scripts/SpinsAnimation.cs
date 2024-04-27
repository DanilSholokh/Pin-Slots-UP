using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinsAnimation : MonoBehaviour
{

    [SerializeField] private BowWallLogic winPrize;
    [SerializeField] private GoldCombinaciaLogic goldCombinacia;
    [SerializeField] Slider _sliderPrizeContent;
    
    private EconomicaLogic _economica;
    
    private bool isSpin = false;
    
    private float stepAround = 260f;
    private float _sliderStep = 0.1f;

    public Button _spinButton;
    public SlotsManager slotsManager;

    public float _spinDuration = 3f;
    public float delayRows = 0.5f;

    public SlotsManager dopSlot;


    private void Start()
    {
        _economica = GetComponent<EconomicaLogic>();
        _spinButton.onClick.AddListener(spinSlots);

    }

    private void spinSlots()
    {
        if (_economica.DecrementCurrency(goldCombinacia.Stavka))
        {
            if (isSpin)
                return;

            StartCoroutine(spinEnuminator());
        }

    }

    private IEnumerator spinEnuminator()
    {

        isSpin = true;
        slotsManager.prepareSlotsToSpin();


        foreach (FruitsSlot row in slotsManager.slotsList)
        {

            StartCoroutine(aroundRowEnuminator(row, -1)); 
            yield return new WaitForSeconds(delayRows);
        }

        yield return new WaitForSeconds(_spinDuration); 

        goldCombinacia.combinacia();
        updatePrizeContentBar();
        isSpin = false;
    }

    private IEnumerator aroundRowEnuminator(FruitsSlot row, int direction)
    {
        int countSpin = 0;
        int r_num = Random.Range(10, 26);
        float time = 0f;
        Vector3 startPos = row.transform.localPosition;
        Vector3 endPos = startPos;

        while (countSpin < r_num)
        {
            row.IndexSpin++;
            countSpin++;
            endPos = startPos + new Vector3(0, stepAround) * direction; 

            while (time < delayRows)
            {
                row.transform.localPosition = Vector3.Lerp(startPos, endPos, time / delayRows);
                time += Time.deltaTime;

                yield return null;
            }

            if (row.IndexSpin == 6)
            {
                startPos = row.StartPosSlot;
                time = 0f;
                row.IndexSpin = 0;
            }
            else
            {
                startPos = endPos;
                time = 0f;
            }
        }

        row.transform.localPosition = startPos;
    }

    public IEnumerator SlotSpinCoroutine(int direction)
    {

        int spinCount = 0;
        int randomSpin = Random.Range(10, 26);
        float timer = 0f;

        Vector2 start = Vector2.zero;

        while (spinCount < randomSpin)
        {

            spinCount++;


            while (direction < 0)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            if (timer >= 6)
            {
                timer = 0f;
            }
            else
            {
                timer = 10f;
            }
        }

        dopSlot.transform.localPosition = start;
    }

    private void updatePrizeContentBar()
    {

        _sliderPrizeContent.value += _sliderStep;

        if (_sliderPrizeContent.value >= 1)
        {
            _sliderPrizeContent.value = 1;
            winPrize.openDopContent();
            _sliderPrizeContent.value = 0;
        }


    }




}