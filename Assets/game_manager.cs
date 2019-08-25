using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class game_manager : MonoBehaviour

{
    public Text player1_name_input;
    public Text player1_atk_input;
    public Text player1_def_input;
    public Text player1_tec_input;

    public string player1_name;
    public int player1_atk;
    public int player1_def;
    public int player1_tec;


    public Text player2_name_input;
    public Text player2_atk_input;
    public Text player2_def_input;
    public Text player2_tec_input;
    public string player2_name;
    public int player2_atk;
    public int player2_def;
    public int player2_tec;

    public int player1_hp;
    public int player2_hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void status_setting()
    {
        player1_hp = 100;
        player2_hp = 100;

        player1_name = player1_name_input.text;
        player1_atk = int.Parse(player1_atk_input.text);
        player1_def = int.Parse(player1_def_input.text);
        player1_tec = int.Parse(player1_tec_input.text);
        

        player2_name = player2_name_input.text;
        player2_atk = int.Parse(player2_atk_input.text);
        player2_def = int.Parse(player2_def_input.text);
        player2_tec = int.Parse(player2_tec_input.text);

    }
    

    public void On_click()
    {
        status_setting();
        
    }
}
