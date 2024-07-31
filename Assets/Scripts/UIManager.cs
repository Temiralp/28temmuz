using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   
    [SerializeField] private TMP_InputField KullaniciAdi_InputField;
    [SerializeField] private TextMeshProUGUI KayitliOyuncuAdi_Text;
    [SerializeField] private Button OyunuBaslat_Button;

    [SerializeField] private Image HealtBar;
    [SerializeField] private TextMeshProUGUI oyuncuAdiText;
    [SerializeField] private TextMeshProUGUI healtText;
    [SerializeField] private GameObject Player;

    bool find = false;
    private int lastHealt = 0;
    string oyuncuAdi;
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);    
    }
    private void Start() 
    {
        if(PlayerPrefs.HasKey("oyuncuAdi"))
        {
            KullaniciAdi_InputField.gameObject.SetActive(false);
            KayitliOyuncuAdi_Text.gameObject.SetActive(true);
            KayitliOyuncuAdi_Text.text = "Oyuncu " + PlayerPrefs.GetString("oyuncuAdi") + " Olarak kayitlisiniz";
        }
    }

    public void Basla_Button()
    {
        if(KullaniciAdi_InputField.text != "" )
        {
            print("Boş ");
            oyuncuAdi = KullaniciAdi_InputField.text;
            PlayerPrefs.SetString("oyuncuAdi", oyuncuAdi);
            
            SceneManager.LoadScene(1);

            StartCoroutine(FindUIElements());
            StartCoroutine(HealtControl());

        }
        else
        {
            
            
            SceneManager.LoadScene(1);

            StartCoroutine(FindUIElements());
            StartCoroutine(HealtControl());
        }
    }
    private void Update() 
    {
    }
    
    
    private IEnumerator FindUIElements()
    {
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
