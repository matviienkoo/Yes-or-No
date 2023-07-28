using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
[Header("Полученный текст")]
public Text YesNo_Text;

[Header("Поинты")]
public int yes;
public Text yes_text;
public int no;
public Text no_text;

[Header("Количество попыток")]
public int attempts;
public Text attempts_text;

[Header("Инструкция")]
public GameObject TopInstruction;
public Text TopInstruction_Text;
public GameObject BottomInstruction;
public Text BottomInstruction_Text;
public GameObject LoserObject;
public Text LoserText;
private int Instruction_int;
private int RandomNumber;

[Header("Эффекты")]
public ParticleSystem ParticleEffect;
public Animation AnimationButton;
public Animation AnimationText;

[Header("Рекламнный бонус")]
public int BonusIncerauseLuck;

[Header("Гугл Консоль")]
public GoogleConsole Console;

private void Start ()
{
      Instruction_int = PlayerPrefs.GetInt("Instruction_int");

      // отключить инструкцию (если ее уже прошли)
      if (Instruction_int > 10)
      {
            TopInstruction.SetActive(false);
            BottomInstruction.SetActive(false);
      }

      // обнулить игру, если инструкция не пройдена
      if (Instruction_int < 10)
      {
            PlayerPrefs.DeleteAll();
      }


      // обнулить бонус
      BonusIncerauseLuck = 0;
      PlayerPrefs.SetInt ("BonusIncerauseLuck", BonusIncerauseLuck);
}

public void OnClickButton () 
{
      if(Input.touchCount < 20) 
      {

      // Для введения данных в консоль
      Console.ConsoleSystem();

      // Для анимации кнопки
      AnimationButton.Play();

      if (Instruction_int > 10)
      {
      RandomNumber = Random.Range(1, 100);

            //если человек ПОБЕДИЛ (БЕЗ БОНУСА)
            if (BonusIncerauseLuck == 0){
            if (RandomNumber == 1){

                  YesNo_Text.text = "Yes";
                  yes += 1;
                  attempts = 0;

                  ParticleEffect.Play();
                  AnimationText.Play();
            }
            }

            //если человек ПРОИГРАЛ (БЕЗ БОНУСА)
            if (BonusIncerauseLuck == 0){
            if (RandomNumber >= 2){

                  YesNo_Text.text = "No";
                  no += 1;
                  attempts += 1;
            }
            }

            //если человек ПОБЕДИЛ (БОНУС)
            if (BonusIncerauseLuck == 1){
            if (RandomNumber <= 3){

                  YesNo_Text.text = "Yes";
                  yes += 1;
                  attempts = 0;

                  ParticleEffect.Play();
                  AnimationText.Play();
            }
            }

            //если человек ПРОИГРАЛ (БОНУС)
            if (BonusIncerauseLuck == 1){
            if (RandomNumber >= 4){

                  YesNo_Text.text = "No";
                  no += 1;
                  attempts += 1;
            }
            }

            PlayerPrefs.SetInt ("no", no);
            PlayerPrefs.SetInt ("yes", yes);
            PlayerPrefs.SetInt ("attempts", attempts);
      }

      else

      InstuctionGame();

      }
}

private void InstuctionGame ()
{
      attempts += 1;
      Instruction_int += 1;
      PlayerPrefs.SetInt ("attempts", attempts);
      PlayerPrefs.SetInt ("Instruction_int", Instruction_int);

      if (Instruction_int == 1)
      {
            BottomInstruction_Text.text = "click here";
            no += 1;

            BottomInstruction.SetActive(true);
      }

      if (Instruction_int == 2)
      {
            BottomInstruction_Text.text = "click again";
            no += 1;
      }

      if (Instruction_int == 3)
      {
            BottomInstruction_Text.text = "click again again";
            no += 1;
      }

      if (Instruction_int == 4) 
      {
            YesNo_Text.text = "Yes";
            yes += 1;

            TopInstruction.SetActive(true);
            TopInstruction_Text.text = "you got (yes)";
            BottomInstruction_Text.text = "the more (yes) the better";

            ParticleEffect.Play ();
            AnimationText.Play();
      }

      if (Instruction_int == 5)
      {
            YesNo_Text.text = "No";
            no += 1;

            TopInstruction.SetActive(false);
            BottomInstruction_Text.text = "I'm serious";
      }

      if (Instruction_int == 6)
      {
            YesNo_Text.text = "No";
            no += 1;

            BottomInstruction_Text.text = "it's the whole game..";
      }

      if (Instruction_int == 7)
      {
            YesNo_Text.text = "No";
            no += 1;

            BottomInstruction_Text.text = "it's the whole game..";
      }

      if (Instruction_int == 8)
      {
            YesNo_Text.text = "No";
            no += 1;

            BottomInstruction_Text.text = "it's the whole game..";
      }

      if (Instruction_int == 9)
      {
            YesNo_Text.text = "No";
            no += 1;

            BottomInstruction_Text.text = "it's the whole game..";
      }

      if (Instruction_int == 10)
      {
            YesNo_Text.text = "No";
            no += 1;

            TopInstruction.SetActive(false);
            BottomInstruction.SetActive(false);
      }

      if (Instruction_int == 11)
      {
            YesNo_Text.text = "No";
            no += 1;
      }

      PlayerPrefs.SetInt ("no", no);
      PlayerPrefs.SetInt ("yes", yes);
      PlayerPrefs.SetInt ("attempts", attempts);
}

public void Update ()
{
      if (attempts < 300){
      LoserObject.SetActive(false);
      }
      if (attempts >= 300){
      LoserObject.SetActive(true);
      LoserText.text = "some more";
      }
      if (attempts >= 500){
      LoserText.text = "you're out of luck :(";  
      }
      if (attempts >= 800){
      LoserText.text = "today is not your day";  
      }
      if (attempts >= 1000){
      LoserText.text = "the game works fine, honestly :(";  
      }
      if (attempts >= 5000){
      LoserText.text = "WHAT??!!";  
      }

      yes = PlayerPrefs.GetInt("yes");
      yes_text.text = "Yes - " + yes.ToString ();

      no = PlayerPrefs.GetInt("no");
      no_text.text = "No - " + no.ToString ();

      Instruction_int = PlayerPrefs.GetInt("Instruction_int");
      BonusIncerauseLuck = PlayerPrefs.GetInt("BonusIncerauseLuck");

      attempts = PlayerPrefs.GetInt("attempts");
      attempts_text.text = "Number of attempts : " + attempts.ToString ();
}
}
