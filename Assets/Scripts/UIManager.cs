using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    [SerializeField] private TMP_InputField KullaniciAdi_InputField;
    [SerializeField] private Button OyunuBaslat_Button;

    [SerializeField] private Image HealtBar;
    [SerializeField] private TextMeshProUGUI oyuncuAdiText;
    [SerializeField] private TextMeshProUGUI healtText;
    [SerializeField] private GameObject Player;

    bool find = false;
    private int lastHealt = 0;
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);    
    }
    private void Start() 
    {
    }

    public void Basla_Button()
    {
        if(KullaniciAdi_InputField.text != "")
        {
            string oyuncuAdi = KullaniciAdi_InputField.text;
            PlayerPrefs.SetString("oyuncuAdi", oyuncuAdi);
            
            SceneManager.LoadScene(1);
            StartCoroutine(FindUIElements());
            StartCoroutine(HealtControl());
        }
    }

    private void Update() 
    {
        
    }
    //HealtBar
    //OyuncuAdiText
    private IEnumerator FindUIElements()
    {
        print("FindHealtBar");
        while (true && !find)
        {
            yield return new WaitForSeconds(.1f);
            if(HealtBar == null && oyuncuAdiText == null && healtText == null)
            {
                HealtBar = GameObject.FindWithTag("HealtBar").GetComponent<Image>();
                oyuncuAdiText = GameObject.FindWithTag("OyuncuAdiText").GetComponent<TextMeshProUGUI>();
                oyuncuAdiText.text = PlayerPrefs.GetString("oyuncuAdi");
                healtText = GameObject.FindWithTag("CanDegeriText").GetComponent<TextMeshProUGUI>();
            }
            else if(HealtBar != null && oyuncuAdiText != null && healtText != null)
            {
                print("buldu");
                find = true;
                StopCoroutine(FindUIElements());
            }
        }
        
    }

    private IEnumerator HealtControl()
    {
        while(true)
        {
            Player = GameObject.Find("Player");
            yield return new WaitForSeconds(1f);
            if(Player != null && HealtBar != null)
            {
                float newHealt =   Player.GetComponent<Player>().health;

                HealtBar.fillAmount = newHealt / 100;
                healtText.text = Player.GetComponent<Player>().health.ToString();
            }
        }
    }
}
