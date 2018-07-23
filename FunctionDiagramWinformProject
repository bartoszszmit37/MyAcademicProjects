public partial class Form1 : Form
    {
        //deklaracja zmiennych globalnych
        int wspolczynnik_a, wspolczynnik_b,wspolczynnik_c,wspolczynnik_d, wartosc_x, wartosc_y;
        public Form1()
        {
            InitializeComponent();
        }

        //ta funkcja aktywuje dostep do pol textowych funkcji liniowej
        private void aktywuj_funkcje_liniowa_Click(object sender, EventArgs e)
        {
            liniowy_wspolczynnik_a.Enabled = true;
            liniowy_wspolczynnik_b.Enabled = true;
            aktywuj_funkcje_kwadratowa.Enabled = false;
            aktywuj_funkcje_wielomianowa.Enabled = false;
            rysuj_funkcje_liniowa.Enabled = true;
        }

        //ta funkcja aktywuje dostep do pol tekstowych funkcji kwadratowej
        private void aktywuj_funkcje_kwadratowa_Click(object sender, EventArgs e)
        {
            wspolczynnik_kwadratowy_a.Enabled = true;
            wspolczynnik_kwadratowy_b.Enabled = true;
            wspolczynnik_kwadratowy_c.Enabled = true;
            aktywuj_funkcje_liniowa.Enabled = false;
            aktywuj_funkcje_wielomianowa.Enabled = false;
            rysuj_funkcje_kwadratowa.Enabled = true;
        }

        //ta funkcja aktywuje dostep do pol tekstowych funkcji wielomianowej
        private void aktywuj_funkcje_wielomianowa_Click(object sender, EventArgs e)
        {
            wspolczynnik_wielomianowy_a.Enabled = true;
            wspolczynnik_wielomianowy_b.Enabled = true;
            wspolczynnik_wielomianowy_c.Enabled = true;
            wspolczynnik_wielomianowy_d.Enabled = true;
            aktywuj_funkcje_liniowa.Enabled = false;
            aktywuj_funkcje_kwadratowa.Enabled = false;
            rysuj_funkcje_wielomianowa.Enabled = true;
        }

        //ta funkcja odpowiada za rysowanie wykresu f. liniowej
        private void rysuj_funkcje_liniowa_Click(object sender, EventArgs e)
        {
            //jesli jedno z pol jest puste, pojawia sie stosowny komunikat
            if (string.IsNullOrEmpty(liniowy_wspolczynnik_a.Text) || string.IsNullOrEmpty(liniowy_wspolczynnik_b.Text))
            {
                error.SetError(tresc_bledu, "Każde pole musi mieć wartość");
                return;
            }
            else
            {
                error.Dispose();
            }

            //jesli wpiszemy znaki lub ciagi znakow, pojawi sie stosowny komunikat o bledzie
            try
            {
                wspolczynnik_a = Convert.ToInt32(liniowy_wspolczynnik_a.Text);
                wspolczynnik_b = Convert.ToInt32(liniowy_wspolczynnik_b.Text);
            }
            catch (Exception)
            {
                error.SetError(tresc_bledu,"Znaki i ciągi znaków niedozwolone");
                return;
            }
                //glowna petla, ktora wylicza wartosc funkcji
                //rysuje wykres i nadaje mu odpowiedni kolor i grubosc
                    for (wartosc_x = -10; wartosc_x < 10; wartosc_x++)
                    {
                        wartosc_y = wspolczynnik_a * wartosc_x + wspolczynnik_b;
                        this.pole_wykresu.Series["wykres"].Points.AddXY(wartosc_x, wartosc_y);
                        this.pole_wykresu.ChartAreas["pozycja_osi"].AxisX.Crossing = 0;
                        this.pole_wykresu.ChartAreas["pozycja_osi"].AxisY.Crossing = 0;
                        this.pole_wykresu.Series["wykres"].Color = Color.Red;
                        this.pole_wykresu.Series["wykres"].BorderWidth = 3;
                    }
                    rysuj_funkcje_liniowa.Enabled = false;

         }

        private void rysuj_funkcje_kwadratowa_Click(object sender, EventArgs e)
        {
            //jesli jedno z pol jest puste, pojawia sie stosowny komunikat
            if (string.IsNullOrEmpty(wspolczynnik_kwadratowy_a.Text) || string.IsNullOrEmpty(wspolczynnik_kwadratowy_b.Text) || string.IsNullOrEmpty(wspolczynnik_kwadratowy_c.Text))
            {
                error.SetError(tresc_bledu, "Każde pole musi mieć wartość");
                return;
            }
            else
            {
                error.Dispose();
            }
            //jesli wpiszemy znaki lub ciagi znakow, pojawi sie stosowny komunikat o bledzie
            try
            {
                wspolczynnik_a = Convert.ToInt32(wspolczynnik_kwadratowy_a.Text);
                wspolczynnik_b = Convert.ToInt32(wspolczynnik_kwadratowy_b.Text);
                wspolczynnik_c = Convert.ToInt32(wspolczynnik_kwadratowy_c.Text);
            }
            catch (Exception)
            {
                error.SetError(tresc_bledu,"Znaki i ciągi znaków niedozwolone");
                return;
            }
            //glowna petla, ktora wylicza wartosc funkcji
            //rysuje wykres i nadaje mu odpowiedni kolor i grubosc
            for (wartosc_x = -10; wartosc_x < 10; wartosc_x++)
            {
                wartosc_y = wspolczynnik_a * (int)Math.Pow(wartosc_x, 2) + wspolczynnik_b * wartosc_x + wspolczynnik_c;
                this.pole_wykresu.Series["wykres"].Points.AddXY(wartosc_x,wartosc_y);
                this.pole_wykresu.ChartAreas["pozycja_osi"].AxisX.Crossing = 0;
                this.pole_wykresu.ChartAreas["pozycja_osi"].AxisY.Crossing = 0;
                
                this.pole_wykresu.Series["wykres"].Color = Color.Red;
                this.pole_wykresu.Series["wykres"].BorderWidth = 3;
            }
            rysuj_funkcje_kwadratowa.Enabled = false;
        }
        private void rysuj_funkcje_wielomianowa_Click(object sender, EventArgs e)
        {
            //jesli jedno z pol jest puste, pojawia sie stosowny komunikat
            if (string.IsNullOrEmpty(wspolczynnik_wielomianowy_a.Text)
                || string.IsNullOrEmpty(wspolczynnik_wielomianowy_b.Text)
                || string.IsNullOrEmpty(wspolczynnik_wielomianowy_c.Text)
                || string.IsNullOrEmpty(wspolczynnik_wielomianowy_d.Text))
            {
                error.SetError(tresc_bledu, "Każde pole musi mieć wartość");
                return;
            }
            else
            {
                error.Dispose();
            }

            //jesli wpiszemy znaki lub ciagi znakow, pojawi sie stosowny komunikat o bledzie
            try
            {
                wspolczynnik_a = Convert.ToInt32(wspolczynnik_wielomianowy_a.Text);
                wspolczynnik_b = Convert.ToInt32(wspolczynnik_wielomianowy_b.Text);
                wspolczynnik_c = Convert.ToInt32(wspolczynnik_wielomianowy_c.Text);
                wspolczynnik_d = Convert.ToInt32(wspolczynnik_wielomianowy_d.Text);
            }
            catch (Exception)
            {
                error.SetError(tresc_bledu, "Znaki i ciągi znaków niedozwolone");
                return;
            }
            //glowna petla, ktora wylicza wartosc funkcji
            //rysuje wykres i nadaje mu odpowiedni kolor i grubosc
            for (wartosc_x = -10; wartosc_x < 10; wartosc_x++)
            {
                wartosc_y = wspolczynnik_a * (int)Math.Pow(wartosc_x, 3) + wspolczynnik_b * (int)Math.Pow(wartosc_x, 2) + wspolczynnik_c * wartosc_x + wspolczynnik_d;
                this.pole_wykresu.Series["wykres"].Points.AddXY(wartosc_x, wartosc_y);
                this.pole_wykresu.ChartAreas["pozycja_osi"].AxisX.Crossing = 0;
                this.pole_wykresu.ChartAreas["pozycja_osi"].AxisY.Crossing = 0;

                this.pole_wykresu.Series["wykres"].Color = Color.Red;
                this.pole_wykresu.Series["wykres"].BorderWidth = 3;
            }
            rysuj_funkcje_wielomianowa.Enabled = false;
        }

        //ta funkcja resetuje wszystkie dane,pola i wykres
        private void resetuj_Click(object sender, EventArgs e)
        {
            this.pole_wykresu.Series["wykres"].Points.Clear();
            error.Dispose();
            rysuj_funkcje_liniowa.Enabled = false;
            rysuj_funkcje_kwadratowa.Enabled = false;
            rysuj_funkcje_wielomianowa.Enabled = false;
            aktywuj_funkcje_liniowa.Enabled = true;
            aktywuj_funkcje_kwadratowa.Enabled = true;
            aktywuj_funkcje_wielomianowa.Enabled = true;
            liniowy_wspolczynnik_a.Enabled = false;
            liniowy_wspolczynnik_a.Text = "";
            liniowy_wspolczynnik_b.Enabled = false;
            liniowy_wspolczynnik_b.Text = "";
            wspolczynnik_kwadratowy_a.Enabled = false;
            wspolczynnik_kwadratowy_a.Text = "";
            wspolczynnik_kwadratowy_b.Enabled = false;
            wspolczynnik_kwadratowy_b.Text = "";
            wspolczynnik_kwadratowy_c.Enabled = false;
            wspolczynnik_kwadratowy_c.Text = "";
            wspolczynnik_wielomianowy_a.Enabled = false;
            wspolczynnik_wielomianowy_a.Text = "";
            wspolczynnik_wielomianowy_b.Enabled = false;
            wspolczynnik_wielomianowy_b.Text = "";
            wspolczynnik_wielomianowy_c.Enabled = false;
            wspolczynnik_wielomianowy_c.Text = "";
            wspolczynnik_wielomianowy_d.Enabled = false;
            wspolczynnik_wielomianowy_d.Text = "";
        }

        
    }
