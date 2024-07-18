using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public int value;
    public Text[] m_text;
    public Text[] m_asdext;

    private void Start()
    {
        foreach (var item in m_text)
        {
            item.text = value.ToString();
        }


    }

    private void Update()
    {

        value += 1;
        foreach (var item in m_text)
        {
            item.text = value.ToString();
        }
    }

    IEnumerator AddTime()
    {
        yield return new WaitForSeconds(1f);

    }

    public void clickbutton()
    {
        Debug.Log("버튼 클릭");
    }
}
