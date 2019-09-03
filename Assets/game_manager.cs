using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class game_manager : MonoBehaviour

{
    public Text text_window;
    public Scrollbar Bar;
    public Slider hp1;
    public Slider hp2;

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


    public int _atk = 0;

    List<Dictionary<string, object>> data;

    // Start is called before the first frame update
    void Start()
    {
        data = CSVReader.Read("save");

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log("index " + (i).ToString() + " : " + data[i]["name"] + " " + data[i]["atk"] + " " + data[i]["def"] + " " + data[i]["tec"]);
        }

    }

    void load(int num)
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
    void time()
    {
        Debug.Log("시간지연");
    }
    void battle()
    {
        int hab = 0;
        while (true)
        {
            Invoke("time", 1f);
            hp1.value = (float)player1_hp / 100;
            hp2.value = (float)player2_hp / 100;
            hab++;
            if (hab>5 && Bar.value>0.1)
            {
                Bar.value= Bar.value-0.01f;
            }

            Debug.Log("1hp : "+player1_hp);

            int first_attack;
            string print_text = "";
            while (true)
            {
                int p1_first_attack = Random.Range(0, player1_tec);
                int p2_first_attack = Random.Range(0, player2_tec);

                if (p1_first_attack > p2_first_attack)
                {
                    first_attack = 1;
                    break;
                }
                if (p1_first_attack < p2_first_attack)
                {
                    first_attack = 2;
                    break;
                }
            }

            if (first_attack == 1)
            {
                int damage = Random.Range(0, player1_atk) - Random.Range(0, player2_def);
                if (damage < 0)
                {
                    damage = 0;
                }
                if (damage == 0)
                {
                    print_text = player1_name + "의 공격 그러나 " + player2_name + "에게 막혔다.";
                }
                else
                {
                    print_text = player1_name + "의 공격 " + player2_name + "는 " + damage + "데미지를 입었다.";
                    player2_hp = player2_hp - damage;
                }
            }
            if (first_attack == 2)
            {
                int damage = Random.Range(0, player2_atk) - Random.Range(0, player1_def);
                if (damage < 0)
                {
                    damage = 0;
                }
                if (damage == 0)
                {
                    print_text = player2_name + "의 공격 그러나 " + player1_name + "에게 막혔다.";
                }
                else
                {
                    print_text = player2_name + "의 공격 " + player1_name + "는 " + damage + "데미지를 입었다.";
                    player1_hp = player1_hp - damage;
                }
            }
            text_window.text += (print_text+"\n");
            Debug.Log(print_text);

            if (player1_hp < 1)
            {
                print_text = player1_name + "이(가) 쓰러졌다.";
                text_window.text += (print_text + "\n");
                hp1.value = 0;
                Debug.Log(print_text);
                break;
            }
            if (player2_hp < 1)
            {
                print_text = player2_name + "이(가) 쓰러졌다.";
                text_window.text += (print_text + "\n");
                Debug.Log(print_text);
                hp2.value = 0;
                break;
            }

            
        }
    }


    public void On_click()
    {
        status_setting();
        battle();

    }
}