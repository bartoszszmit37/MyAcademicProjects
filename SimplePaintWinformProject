public partial class pulpit_paint : Form
    {
        //pioro, czyli narzedzie do rysowania
        Pen pioro = new Pen(Color.Blue, 2);
        
        //zmienna, ktorej uzyjemy w megodzie drawline
        Point Punkt = new Point();
        
        //zmienna referencyjna dla powierzchni graficznej
        Graphics refRysownica;
        
        SolidBrush pedzel = new SolidBrush(Color.Red);
        public pulpit_paint()
        {
            InitializeComponent();
            

            
            //ustawienie wymiarow formularza
            this.Left = 20;
            this.Top = 20;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width*0.8F);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Height*0.8F);
            
            //uniemozliwienie zmiany szerokosci i wysokosci
            this.SetAutoSizeMode(System.Windows.Forms.AutoSizeMode.GrowAndShrink);

            //wylaczenie maxymalizacji i minimalizacji
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            /*rysownica.Location = new Point(30,50);
            rysownica.Width = (int)(this.Width*0.65F);
            rysownica.Height = (int)(this.Height*0.65F);*/
            
            //ustalenie koloru tla dla rysownicy
            rysownica.BackColor = Color.LightYellow;
            
            //ustalenie obramowanie dla rysownicy
            rysownica.BorderStyle = BorderStyle.Fixed3D;

            //obiekt powierzchni graficznej w postaci bitmapy
            rysownica.Image = new Bitmap(rysownica.Width,rysownica.Height);
            
            //zapisanie bitmapowej powierzchni bitmapowej do zmiennej referencyjnej
            refRysownica = Graphics.FromImage(rysownica.Image);
            

        }

        //funkcja obslugujaca suwak grubosc linii
        private void suwak_grubosci_Scroll(object sender, EventArgs e)
        {
            //synchronizacja 
            numeric_grubosci.Value = suwak_grubosci.Value;
            pioro.Width = suwak_grubosci.Value;
            wziernik.Invalidate();
            
        }

        private void wziernik_Paint(object sender, PaintEventArgs e)
        {
            //narysowanie linii we wzierniku
            Point _pt1 = new Point(1,10);
            Point pt2 = new Point(150,10);
            e.Graphics.DrawLine(pioro,pt1,pt2);
        }

        //funkcja obslugujaca numeryczna zmiane grubosci linii
        private void numeric_grubosci_ValueChanged(object sender, EventArgs e)
        {
            
            //synchronizacja
            suwak_grubosci.Value = (int)numeric_grubosci.Value;
            pioro.Width = suwak_grubosci.Value;
            wziernik.Invalidate();
        }

        private void rysownica_MouseDown(object sender, MouseEventArgs e)
        {
            //rozpoznanie polorzenia kursora myszy przy kliknieciu lewym klawiszem myszy
            wspolrzedna_x.Text = e.Location.X.ToString();
           wspolrzedna_y.Text = e.Location.Y.ToString();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                Punkt = e.Location;
        }

        private void rysownica_MouseUp(object sender, MouseEventArgs e)
        {
            //rozpoznanie polorzenia kursowa myszy
            wspolrzedna_x.Text = e.Location.X.ToString();
            wspolrzedna_y.Text = e.Location.Y.ToString();
            
            //zmienne, ktore wykorzystamy do resowania figur
            int lewy_naroznik_x, lewy_naroznik_y;
            int szer, wys;
            
                      
            //jesli punkt poczatkowy jest wiekszy od kocowej lokalizacji, to
            if (Punkt.X > e.Location.X)
            {
                //przypisanie ostatecznej lokalicacji z do zmiennej lewy_naroznik_x
                lewy_naroznik_x = e.Location.X;
            }
            else
            {
                //w przeciwnym razie przypisa punkt poczatkowy do lewego naroznika
                lewy_naroznik_x = Punkt.X;
            }
            //to samo co u gory, tylko dla y
            if (Punkt.Y > e.Location.Y)
            {
                lewy_naroznik_y = e.Location.Y;
            }
            else
            {
                lewy_naroznik_y = Punkt.Y;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //jesli wybralismy olowek, to rysuje sie prosta linia
                if (olowek.Checked)
                {
                    refRysownica.DrawLine(pioro,Punkt,e.Location);
                    rysownica.Invalidate();
                }
                //jesli wybralismy okrat, to rysuje sie okrag
                if (okrag.Checked)
                {
                    szer = Math.Abs(e.Location.X - Punkt.X);
                    wys = szer;
                    refRysownica.DrawEllipse(pioro,new Rectangle(lewy_naroznik_x,lewy_naroznik_y,szer,wys));
                    rysownica.Invalidate();
                }
                
                //jesli wybralismy prostokat, to rysuje sie prostokat
                if (prostokat.Checked)
                {
                    szer = Math.Abs(e.Location.X - Punkt.X);
                    wys = Math.Abs(e.Location.Y - Punkt.Y);
                    refRysownica.DrawRectangle(pioro,new Rectangle(lewy_naroznik_x,lewy_naroznik_y,szer,wys));
                    rysownica.Invalidate();
                }
                
            }


        }

        private void rysownica_MouseMove(object sender, MouseEventArgs e)
        {
            //rozpoznanie polozeniamszy
            wspolrzedna_x.Text = e.Location.X.ToString();
            wspolrzedna_y.Text = e.Location.Y.ToString();
        }

        //mozliwosc ustawienia koloru linii
        private void color_linii_Click(object sender, EventArgs e)
        {
            //delkaracja zmiennej zarzadzania kolorami
            ColorDialog okno_zkolorami = new ColorDialog();
            if (okno_zkolorami.ShowDialog() == DialogResult.OK)
            {
                //zapisanie wyboru koloru
                pioro.Color = okno_zkolorami.Color;
                wziernik.Invalidate();
            }
        }

        //mozliwosc zapisania rysunku na dysku
        private void zapisz_rysunek_Click(object sender, EventArgs e)
        {
            //deklaracja zmiennej zapisu
            SaveFileDialog okno_zapisu = new SaveFileDialog();
            
            //wybor rodzaju rozszerzenia i zapisanie go w zmiennej
            okno_zapisu.Filter = "bmp|*.bmp";
            if (okno_zapisu.ShowDialog() == DialogResult.OK)
            {
                if (okno_zapisu.FileName != "")
                {
                    //polecenie zapisania bitmapy
                    rysownica.Image.Save(okno_zapisu.FileName);
                }
            }
        }

       //mozliwosc otwarcia rysunku
        private void otworz_rysunek_Click(object sender, EventArgs e)
        {
            //deklaracja zmiennej do otwarcia pliku
            OpenFileDialog otwieranie = new OpenFileDialog();
            if (otwieranie.ShowDialog() == DialogResult.OK)
            {
                //zmienna string, w ktorej przechowywac bedziemy nazwe pliku
                string nazwa_pliku = otwieranie.FileName;
                Bitmap bitmapa = new Bitmap(nazwa_pliku);
                refRysownica.DrawImage(bitmapa,rysownica.Left,rysownica.Top);
                rysownica.Refresh();
            }
        }

        

        //mozliwosc zmiany koloru tla rysownicy
        private void kolor_tla_Click(object sender, EventArgs e)
        {
            ColorDialog okno_kolorow = new ColorDialog();
            if (okno_kolorow.ShowDialog() == DialogResult.OK)
            {
                refRysownica.Clear(okno_kolorow.Color);
                rysownica.Invalidate();
            }
        }
        
        //mozliwosc wyboru rodzaju linii
        private System.Drawing.Drawing2D.DashStyle stylLinii(int i)
        {
            switch (i)
            { 
                case 0:
                    return System.Drawing.Drawing2D.DashStyle.Dash;
                    
                case 1:
                    return System.Drawing.Drawing2D.DashStyle.DashDot;
                case 2:
                    return System.Drawing.Drawing2D.DashStyle.DashDotDot;
                case 3:
                    return System.Drawing.Drawing2D.DashStyle.Dot;
                case 4:
                    return System.Drawing.Drawing2D.DashStyle.Solid;
                default:
                    MessageBox.Show("Nie ma takiego stylu");
                    return System.Drawing.Drawing2D.DashStyle.Solid;
            }
        }

        //w tej metodzie wykorzystujemy funkcję wyrzej
        private void style_linii_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prypisanie do zmiennej z wlasciwoscia dashstyle naszego wyboru linii
            pioro.DashStyle = stylLinii(style_linii.SelectedIndex);
            wziernik.Invalidate();
        }
        
    }
