using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Sprite[] _stockSprites;
    [SerializeField]
    private Image _stocksImage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateStocks(int currentStocks)
    {

        _stocksImage.sprite = _stockSprites[currentStocks];

    }
}
