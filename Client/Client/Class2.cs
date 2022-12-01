using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class persona
{

    string nome,cognome,luogo,data_di_nascita;
   
    public persona()
    {
        nome = "";
        cognome = "";
        luogo = "";
        data_di_nascita = "";
    }
    public void setPersona(string nome, string cognome, string luogo, string data_di_nascita)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.luogo = luogo; 
        this.data_di_nascita = data_di_nascita;
    }

    public string getnome()
    {
        return nome;
    }
    public string getcognome()
    {
        return cognome;
    }
    public string getluogo()
    {
        return luogo;
    }
    public string getdata_di_nascita()
    {
        return data_di_nascita;
    }

}