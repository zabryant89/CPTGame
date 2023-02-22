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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !fifty)
            FiftyFifty();
        if (Input.GetKeyDown(KeyCode.S) && !scrape)
            Scrape();
        if (Input.GetKeyDown(KeyCode.D) && !ticket)
            GoldenTicket();
    }

    public void FiftyFifty()
    {
        //removes 2 incorrect answers
        string temp = qh.GetCorrect(); //has value of the correct answer to current question
        int total = 2;
        for (int i = 0; i < 4; i++)
            if (temp != qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text)
            { //compare text with button
                qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "xxx";
                total--;
                if (total == 0)
                    break;
            }
        fifty = true;
    }

    public void Scrape()
    {
        //removes 1 incorrect answer
        string temp = qh.GetCorrect();
        for (int i = 0; i < 4; i++)
            if (temp != qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text)
            {
                qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "xxx";
                break;
            }
        scrape = true;
    }

    public void GoldenTicket()
    {
        //gives correct answer for the question you are on
        string temp = qh.GetCorrect();
        for (int i = 0; i < 4; i++)
            if (temp == qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text)
            {
                //qh.buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = "CLICK ME"; //careful with changing text, we are using text to check answers. @@@
                var colors = qh.buttons[i].colors;
                colors.normalColor = Color.green;
                qh.buttons[i].colors = colors;
                break;
            }
        ticket = true;
    }
}
