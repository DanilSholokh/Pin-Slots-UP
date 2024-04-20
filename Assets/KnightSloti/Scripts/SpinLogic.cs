using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinLogic : MonoBehaviour
{
    public Button spinButton;
    public SlotsManager slotsManager;



    public float spinDuration = 3f;
    public float delayBetweenRows = 0.5f;

    private float step = 260f;
    private bool isSpinning = false;

    [SerializeField] Slider _sliderDopContent;
    [SerializeField] private GoldGanarate goldGanarate;
    [SerializeField] private BowWallLogic dopPrize;

    private EconomicaLogic economica;

    private float sliderProgressStep = 0.1f;

    private void Start()
    {
        economica = GetComponent<EconomicaLogic>();
        spinButton.onClick.AddListener(Spin);

    }

    private void Spin()
    {
        if (economica.DecrementCurrency(goldGanarate.Stavka))
        {
            if (isSpinning)
                return;

            StartCoroutine(SpinCoroutine());
        }

    }

    private IEnumerator SpinCoroutine()
    {

        isSpinning = true;
        slotsManager.prepareSlotsToSpin();


        foreach (FruitsSlot row in slotsManager.slotsList)
        {

            StartCoroutine(MoveRow(row, -1)); // Вращаем вниз

            yield return new WaitForSeconds(delayBetweenRows);
        }

        // Остановить вращение
        yield return new WaitForSeconds(spinDuration); // Пауза для визуального эффекта

        //prize
        goldGanarate.combinacia();
        UpdateDopContentBar();
        isSpinning = false;
    }

    private IEnumerator MoveRow(FruitsSlot row, int direction)
    {
        int countSpin = 0;
        int r_num = Random.Range(10, 26);
        float elapsedTime = 0f;
        Vector3 startPosition = row.transform.localPosition;
        Vector3 endPosition = startPosition;

        while (countSpin < r_num)
        {
            row.IndexSpin++;
            countSpin++;
            endPosition = startPosition + new Vector3(0, step) * direction; // Движение вверх или вниз

            while (elapsedTime < delayBetweenRows)
            {
                // Изменяем позицию на каждой итерации с помощью Lerp
                row.transform.localPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / delayBetweenRows);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            // Проверяем, прошло ли уже 6 итераций
            if (row.IndexSpin == 6)
            {
                startPosition = row.StartPosSlot; // Возвращаемся к исходной позиции
                elapsedTime = 0f;
                row.IndexSpin = 0;
            }
            else
            {
                startPosition = endPosition;
                elapsedTime = 0f;
            }
        }

        row.transform.localPosition = startPosition;
    }


    private void UpdateDopContentBar()
    {

        _sliderDopContent.value += sliderProgressStep;

        if (_sliderDopContent.value >= 1)
        {
            _sliderDopContent.value = 1;
            dopPrize.openDopContent();
            _sliderDopContent.value = 0;
        }


    }


}