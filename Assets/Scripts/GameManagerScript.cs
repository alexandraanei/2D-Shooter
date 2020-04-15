using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{   
    private int scor;
    private TextMeshProUGUI Text;
    private GameObject MainMenu;
    private int scormax;
    private string eticheta;
    private string etichetamax;
    public GameObject deathScreen;
    public Text texty;
    public GameObject aux;

    // Start is called before the first frame update
    void Start()
    {   
        //retimen scorul maxim si numele jucatorului care l-a atins
        scormax = PlayerPrefs.GetInt("scormax");
        etichetamax = PlayerPrefs.GetString("eticheta");

        
        //Retinem Obiectul din scena care reprezinta meniul
        //Retinem si Obiectul responsabil cu afisarea textului
        MainMenu = GameObject.Find("ImagineMeniu");
        Text = GameObject.Find("TextScor").GetComponent<TextMeshProUGUI>();
        scor = 0;
        Text.SetText("scor: {0}", scor);
        //Punem pauza jocului pentru a nu se derula in timp ce meniul este activ
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

            PressPlay();
        }

        //Secret
        if(Input.GetKeyDown(KeyCode.L)){

            Destroy(aux);
        }

    }

    public int getScor(){
        return scor;
    }

    //Pentru afisarea scorului curent
    void updateScor(int valoare){

        scor+= valoare;
        Text.SetText("scor: {0}", scor);
    }    

    //Se pune auza sau se rezuma jocul aici
    //In acelasi timp se activeaza/dezactiveaza meniul
    public void PressPlay(){

        Time.timeScale = 1 - Time.timeScale;
        MainMenu.SetActive(Time.timeScale == 0);
    }

    //Se afiseaza ce corespunde mortii playerului
    //Ecranul invita playerului sa isi introduca numele pentru cazul in care playerul a batut scorul maxim
    public void PlayerDied(){

        texty.text = "Best: " + scormax + " " + etichetamax;
        Debug.Log(etichetamax);
        deathScreen.SetActive(true);
    
    }

    public void acceptaNume(string param){
        
        Debug.Log("!!!!!!!!!");
        Debug.Log(param);
       eticheta = param; 
    }

    //Daca scorul depaseste scorul maxim sa actualizeaza
    //Apoi se reseteaza scena
    public void acceptaScor(){
        
        
        if(scor > scormax){
            
            PlayerPrefs.SetInt("scormax", scor);
            PlayerPrefs.SetString("eticheta", eticheta);

        }

        SceneManager.LoadSceneAsync(0);

    }

}

