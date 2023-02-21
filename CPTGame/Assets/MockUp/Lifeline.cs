/* Author: Naddie Mathkour */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lifeline : MonoBehaviour
{
    public MockUpQA mqa;
    public QuestionHandler qh;
    bool fifty;
    bool scrape;
    bool ticket;

    private void Start()
    {
        fifty = scrape = ticket = false;
    }

    public bool FiftyFifty()
    {
        //removes 2 incorrect answers
        string temp = qh.GetCorrect(); //has value of the correct answer to current question
        int total = 2;
        for (int i = 0; i < 4; i++)
            if (temp == qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text)
            { //compare text with button
                qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "xxx";
                total--;
                if (total == 0)
                    break;
            }
        return true;
    }

    public bool Scrape()
    {
        //removes 1 incorrect answer
        string temp = qh.GetCorrect();
        for (int i = 0; i < 4; i++)
            if (temp == qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text)
            {
                qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "xxx";
                break;
            }
        return true;
    }

    public bool GoldenTicket()
    {
        //gives correct answer for the question you are on
        string temp = qh.GetCorrect();
        for (int i = 0; i < 4; i++)
            if (temp == qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text)
            {
                qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "CLICK ME"; //careful with changing text, we are using text to check answers. @@@
                break;
            }
        return true;
    }
}
