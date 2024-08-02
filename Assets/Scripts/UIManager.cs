using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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

    [SerializeField] private GameObject FinishPanel;    
    [SerializeField] private Image FinishPanel_Image;    
    [SerializeField] private TextMeshProUGUI Finis_Text;

    [SerializeField] private GameObject DuraklatmaEkran_Panel;
    [SerializeField] private GameObject DuraklatmaEkrani;
    [SerializeField] private Button DevamEt_Button;
    [SerializeField] private Button Cikis_Button;


    private bool find = false;
    private bool finish = false;
    public bool Finish {get { return finish;}} 

    private bool duraklatmaEkrani = false;

    private float playerHealt = 0;
    string oyuncuAdi;
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);    
    }
    private void Start()
    {
        PlayerPrefsControl();

        InvokeRepeating("FinishControl", 0, 0.1f);

    }

    private void PlayerPrefsControl()
    {
        if (PlayerPrefs.HasKey("oyuncuAdi"))
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
            oyuncuAdi = KullaniciAdi_InputField.text;
            PlayerPrefs.SetString("oyuncuAdi", oyuncuAdi);
            
            SceneManager.LoadScene(1);

            StartCoroutine(FindUIElements());
            StartCoroutine(HealtControl());

        }
        else
        {
            if(PlayerPrefs.HasKey("oyuncuAdi"))
            {
                SceneManager.LoadScene(1);

                StartCoroutine(FindUIElements());
                StartCoroutine(HealtControl());

            }

            
        }
    }
    private void Update() 
    {
        UI_InputControl();
    }
    
    
    private IEnumerator FindUIElements()
    {
        while (true && !find)
        {
            yield return new WaitForSeconds(.1f);
            if(!find)
            {
                HealtBar = GameObject.FindWithTag("HealtBar").GetComponent<Image>();
                oyuncuAdiText = GameObject.FindWithTag("OyuncuAdiText").GetComponent<TextMeshProUGUI>();
                oyuncuAdiText.text = PlayerPrefs.GetString("oyuncuAdi");
                healtText = GameObject.FindWithTag("CanDegeriText").GetComponent<TextMeshProUGUI>();
                Finis_Text = GameObject.FindWithTag("Finish_Text").GetComponent<TextMeshProUGUI>();
                FinishPanel = GameObject.FindWithTag("FinishPanel");

                DuraklatmaEkran_Panel = GameObject.FindWithTag("DuraklatmaEkran_Panel");
                DuraklatmaEkrani = DuraklatmaEkran_Panel.transform.GetChild(0).gameObject;
            }
            else 
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
            yield return new WaitForSeconds(0.01f);
            if(Player != null && HealtBar != null)
            {
                playerHealt =   Player.GetComponent<Player>().health;

                HealtBar.fillAmount = playerHealt / 100;
                healtText.text = Player.GetComponent<Player>().health.ToString();
            }
        }
    }

    public void FinishControl()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            if(Player != null)
            {
                if(Player.GetComponent<Player>().health <= 0)
                {
                    FinishPanel_Image= FinishPanel.transform.GetChild(0).GetComponent<Image>();

                    CancelInvoke("FinishControl");
                    
                    StartCoroutine(FinishScreenAnimation());

                }
            }
            
        }
    }

    private IEnumerator FinishScreenAnimation()
    {
        float a = 0;
        while (true && !finish)
        {   
            yield return new WaitForSeconds(1);
            if(FinishPanel_Image.color.a < .5f)
            {
                
                a += .1f;
                FinishPanel_Image.color = new Color(FinishPanel_Image.color.r,FinishPanel_Image.color.g ,FinishPanel_Image.color.b ,a);
            }
            else if(FinishPanel_Image.color.a >= .5f)
            {
                Finis_Text.text = "Oyuncu " + PlayerPrefs.GetString("oyuncuAdi") + " kaybetti";
                finish = true;
                StopCoroutine(FinishScreenAnimation());
            }
        }
    }

    private void UI_InputControl()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(DuraklatmaEkrani != null)
            {
                duraklatmaEkrani  = !duraklatmaEkrani;
                DuraklatmaEkrani.gameObject.SetActive(duraklatmaEkrani);
                if(DuraklatmaEkrani.activeSelf)
                {
                    if(DevamEt_Button == null && Cikis_Button == null)
                    {
                        print("Calisiyor");
                        DevamEt_Button = GameObject.FindWithTag("DevamEt_Button").GetComponent<Button>();
                        Cikis_Button = GameObject.FindWithTag("Cikis_Button").GetComponent<Button>();

                        DevamEt_Button.onClick.AddListener (()=>DevamEtButton_Function());
                        Cikis_Button.onClick.AddListener(()=> CikisButton_Function());
                    }
                
                }
            }
        }
    }

    
    public void DevamEtButton_Function()
    {
        DuraklatmaEkrani.gameObject.SetActive(false);
    }

    public void CikisButton_Function()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }   


}
