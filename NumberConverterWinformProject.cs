public partial class konwerter_liczb : Form
    {

        //deklaracje zmiennych
        int liczba;
        
        //deklaracja zmiennej znakowej
        char Cyfra;
        //inne zmienne oraz zmienna tablicowa
        int i;
        int n;
        int L;
        char[] tablica_cyfr = new char[50];
      
        public konwerter_liczb()
        {
            InitializeComponent();
            //przypisanie to pierwszych indexow comba wartosc 0
            lewa_lista.SelectedIndex = 0;
            prawa_lista.SelectedIndex = 0;
        }

        //resetowanie stanu programu
        private void btnResetuj_Click(object sender, EventArgs e)
        {
            lewa_lista.Enabled = true;
            prawa_lista.Enabled = true;
            wpisz_liczbe.Enabled = true;
            //po kliknieciu resetuj naszego przyciski i pole, znowu sa aktywne
            lewa_lista.SelectedIndex = 0;
            prawa_lista.SelectedIndex = 0;
            //wylaczenie errorProvidera
            errorProvider2.Dispose();
            errorProvider1.Dispose();
            //szczyszczenie wyniku
            wynik_po_konwersji.Text = "";
            wpisz_liczbe.Text = "";

        }
        

        private void koniec_programu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void konwertuj_Click(object sender, EventArgs e)
        {
            string liczba_przed_konwersja, liczba_po_konwersji;
            //deklaracja zmiennych, w ktorych przechowywane sa opcję combo
            int lewa_podstawa, prawa_podstawa;
            switch (lewa_lista.SelectedIndex)
            {
                case 0: lewa_podstawa = 10; break;
                case 1:lewa_podstawa = 8; break;
                case 2: lewa_podstawa = 16; break;
                case 3: lewa_podstawa = 2; break;
                default: lewa_podstawa = 10; break;
            }
            switch (prawa_lista.SelectedIndex)
            {
                case 0: prawa_podstawa = 10; break;
                case 1: prawa_podstawa = 8; break;
                case 2: prawa_podstawa = 16; break;
                case 3: prawa_podstawa = 2; break;
                default: prawa_podstawa = 10; break;
            }
            //jesli pole pozostawimy puste, wyswietli sie error
            if (string.IsNullOrEmpty(wpisz_liczbe.Text))
            {
                errorProvider1.SetError(wpisz_liczbe, "Nie wpisaleś liczby");
                return;
            }
            else
            {
                errorProvider1.Dispose();
            }
            //przypisanie zawartosc textboxa o nazwie "wpisz_liczbe" do zmiennej
            //liczba_przed_konwersja
            liczba_przed_konwersja = wpisz_liczbe.Text;
            //chwilowe wylaczenie pol
            lewa_lista.Enabled = false;
            prawa_lista.Enabled = false;
            wpisz_liczbe.Enabled = false;
            //usuniecie spracji korzystajac z metody trim
            liczba_przed_konwersja = liczba_przed_konwersja.Trim();
            if (CzyLiczbaJestZapisanaPoprawnie(liczba_przed_konwersja,lewa_podstawa))
            {
                //przypisanie ilosci znakow zmiennej liczba_przed_konwersja do zmiennej
                //n
                n = liczba_przed_konwersja.Length;
                //inicjalizacja zmiennej l
                L = 0;
                //poczatek petli
                for (int i = 0; i < n; i++)
                { 
                    //przy kazdej iteracji, znak ze string jest przypisywany
                    //zmiennej cyfra
                    Cyfra = liczba_przed_konwersja[i];
                    //jesli wybierzemy opcję mniejszą niż opcja dziesietna,to...
                    if (lewa_podstawa <= 10)
                    {
                        
                        L = L * lewa_podstawa + (Cyfra - '0');//-'0'
                    }
                    else
                    {
                        if ((Cyfra >= '0') && (Cyfra <= '9'))
                            L = L * lewa_podstawa + (Cyfra-'0');//-'0'
                        else
                        {
                            Cyfra = char.ToUpper(Cyfra);
                           L=L *lewa_podstawa+((Cyfra-'A')+10);
                        }
                    }
                }
            } // koncowa klamra glownego if'a
            int index = 0;
            int wartosc_cyfry = 0;
            while (L > 0)
            {
                if (prawa_podstawa <= 10)
                {
                    Cyfra = (char)((L % prawa_podstawa) + (int)'0');
                    L = L / prawa_podstawa;
                }
                else
                {
                    wartosc_cyfry = L % prawa_podstawa;
                    L = L / prawa_podstawa;
                    if (wartosc_cyfry < 10)
                    {
                        Cyfra = (char)(wartosc_cyfry + (int)'0');
                    }
                    else
                    { 
                        Cyfra = (char)((wartosc_cyfry-10) + 'A');
                    }
                
                }
                tablica_cyfr[index] = Cyfra;
                index++;
            }
            liczba_po_konwersji = "";
            for (int i = index - 1; i >= 0; i--)
            {
                liczba_po_konwersji = liczba_po_konwersji + tablica_cyfr[i];
                wynik_po_konwersji.Text = liczba_po_konwersji.ToString();

            }
            errorProvider1.Dispose();
        }
        //zabezpieczenie przez wpisanie nieprawidłoweych wartosc
        private bool CzyLiczbaJestZapisanaPoprawnie(string lewa, int lewa_podstawa)
        {
            //po wyborze dziesietnym...
            if (lewa_podstawa == 10)
            {
                try
                {
                    liczba = Convert.ToInt32(lewa, lewa_podstawa);
                }
                catch (Exception)
                {
                    errorProvider2.SetError(wpisz_liczbe,"Zodzwolone tylko liczby dziesiętne");
                    return false;
                }
            }
            //po wyborze oktalnym...
            if (lewa_podstawa == 8)
            {
                try
                {
                    liczba = Convert.ToInt32(lewa, lewa_podstawa);
                }
                catch (Exception)
                {
                    errorProvider2.SetError(wpisz_liczbe,"Dozwolone tylko liczby oktalne");
                    return false;
                }
            }
            //po wyborze binarnym
            if (lewa_podstawa == 2)
                try
                {
                    liczba = Convert.ToInt32(lewa, lewa_podstawa);
                }
                catch (Exception)
                {
                    errorProvider2.SetError(wpisz_liczbe, "Dozwolone tylko liczby binarne");
                    return false;
                }
            //po wyborze keksadecymalnym
            if (lewa_podstawa == 16)
                try
                {
                    liczba = Convert.ToInt32(lewa, lewa_podstawa);
                }
                catch (Exception)
                {
                    errorProvider2.SetError(wpisz_liczbe, "Dozwolone tylko liczby heksadecymalne");
                    return false;
                }
            return true;
         }

        private void konwerter_liczb_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult pytanie = MessageBox.Show("Czy chcesz zakończyć?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
           if (pytanie == DialogResult.Yes)
           {
               e.Cancel = false;
           }
           else
           {
               if (pytanie == DialogResult.No)
               {
                   e.Cancel = true;
               }
           }
            
        }
    }
