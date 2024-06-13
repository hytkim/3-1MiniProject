using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    Image fadeImg; // fade�� �� �̹���
    float fadeTime = 1.5f; //ȭ���� ���� �ð�
    public bool fadeout;
    public bool fadein;

    private bool isPlaying = false;

    private void Awake()
    {
        fadeImg = GetComponent<Image>();
    }


    /*private void Start()
    {
        fadein = true; //��ũ��Ʈ�� Ȱ��ȭ�� ���, ���̵��� ��Ŵ. �� �κ��� ���ϸ� ����
    }*/

    private void Update()
    {
        if (fadeout == true && isPlaying == false) //���̵�ƿ��� ���� ��
        {
            StartCoroutine(FadeOut());
        }
        else if (fadeout == false && fadein == true) //���̵����� ���� ��
        {
            StartCoroutine(FadeIn());
        }
    }
    IEnumerator FadeOut()
    {
        //fadeImg.gameObject.SetActive(true);
        isPlaying = true;
        Color tempColor = fadeImg.color;
        tempColor.a = 0f;
        while (tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeTime;
            fadeImg.color = tempColor;

            if (tempColor.a >= 1f)
            {
                tempColor.a = 1f;
            }
            yield return null;
        }
        fadeout = false;
        isPlaying = false;
    }
    IEnumerator FadeIn()
    {
        Color tempColor = fadeImg.color;
        while (tempColor.a > 0f)
        {
            tempColor.a -= Time.deltaTime / fadeTime;
            fadeImg.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
                fadeImg.color = tempColor;
            }
            yield return null;
        }
        fadeImg.gameObject.SetActive(false);
        fadein = false;
        isPlaying = false;
    }
}