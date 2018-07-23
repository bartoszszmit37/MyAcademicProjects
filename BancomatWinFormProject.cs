public partial class Form1 : Form
    {
        //definiowanie ziennych
        Label DolnaGranicaPrzedzialu = new Label();
        Label GornaGrafnicaPrzedzialu = new Label();
        TextBox txtDolnaGranicaPrzedzialu = new TextBox();
        TextBox txtGornaGranicaPrzedzialu = new TextBox();
        Label komunikat_wartosci_losowe = new Label();
        int dolna_granica;
        int gorna_granica;
        Button los_lista = new Button();
        Button btnAkceptacjaNominalow = new Button();
        int[,] NominalyBankomatu = {
        {25,200},{25,100},{25,50},{25,20},{25,10},
        {25,5},{25,2},{25,1}};
        
        int wyplacona_wartosc;
        bool[] StanTabPage = { true, false, false };
        int i = 0;
       //definicja stałej 
        const int NajmniejszyBanknot=10;
        int pieniadze_do_wyplaty;
        int ilosc_nominalow;
        //definicja zmiennej losowej
        Random rnd1 = new Random();
        public Form1()
        {
            InitializeComponent();
            cmbRodzajWaluty.SelectedIndex = 0;
            this.tabControl1.SelectedTab = tabPage1;
            this.radioSt25.Checked = false;
            this.radioUstawieniaLosowe.Checked = false;
        }

        
        //**************************************************************
        //ustawienie właściwość dla obiektow dynamicznych
        private void radioUstawieniaLosowe_CheckedChanged(object sender, EventArgs e)
        {
            
            DolnaGranicaPrzedzialu.Text = "Etykieta dolnej granicy przedzialu";
            DolnaGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif,10,FontStyle.Italic);
            DolnaGranicaPrzedzialu.TextAlign = ContentAlignment.MiddleCenter;
            DolnaGranicaPrzedzialu.Location = new Point(140,170);
                DolnaGranicaPrzedzialu.Size = new System.Drawing.Size(200,70);
            this.tabControl1.SelectedTab.Controls.Add(DolnaGranicaPrzedzialu);
            txtDolnaGranicaPrzedzialu.BackColor = Color.White;
            txtDolnaGranicaPrzedzialu.ForeColor = Color.Black;
            txtDolnaGranicaPrzedzialu.Text = "";
            txtDolnaGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif,12.52f,FontStyle.Regular);
            txtDolnaGranicaPrzedzialu.TextAlign = HorizontalAlignment.Center;
                txtDolnaGranicaPrzedzialu.Location = new Point(190,240);
            txtDolnaGranicaPrzedzialu.Size = new System.Drawing.Size(100,70);
            xtDolnaGranicaPrzedzialu.BorderStyle = BorderStyle.FixedSingle;
            this.tabControl1.SelectedTab.Controls.Add(txtDolnaGranicaPrzedzialu);

            
            GornaGrafnicaPrzedzialu.Text = "Górna granica przedziału nominałów";
            GornaGrafnicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 10.25f, FontStyle.Italic);
            GornaGrafnicaPrzedzialu.TextAlign = ContentAlignment.MiddleCenter;
            GornaGrafnicaPrzedzialu.Location = new Point(400,170);
            GornaGrafnicaPrzedzialu.Size = new System.Drawing.Size(200,70);
            this.tabControl1.SelectedTab.Controls.Add(bs_GornaGrafnicaPrzedzialu);


            
            txtGornaGranicaPrzedzialu.BackColor = Color.White;
            txtGornaGranicaPrzedzialu.ForeColor = Color.Black;
           txtGornaGranicaPrzedzialu.Text = "";
           txtGornaGranicaPrzedzialu.Font = new Font(FontFamily.GenericSansSerif, 10.25f, FontStyle.Italic);
            txtGornaGranicaPrzedzialu.TextAlign = HorizontalAlignment.Center;
            txtGornaGranicaPrzedzialu.Location = new Point(460, 240);
            txtGornaGranicaPrzedzialu.Size = new System.Drawing.Size(100,70);
            txtGornaGranicaPrzedzialu.BorderStyle = BorderStyle.FixedSingle;
            this.tabControl1.SelectedTab.Controls.Add(txtGornaGranicaPrzedzialu);

            los_lista.BackColor = Color.White;
            los_lista.ForeColor = Color.Black;
            los_lista.Text = "Przejdź do tabeli";
            los_lista.Font = new Font(FontFamily.GenericSansSerif,10.25f,FontStyle.Italic);
            los_lista.Size = new System.Drawing.Size(200,30);
            los_lista.Location = new Point(270,270);
            this.tabControl1.SelectedTab.Controls.Add(bs_los_lista);
            los_lista.Click += new EventHandler(bs_los_lista_Click);

            komunikat_wartosci_losowe.BackColor = Color.White;
            komunikat_wartosci_losowe.ForeColor = Color.Black;
            komunikat_wartosci_losowe.Text = "";
            komunikat_wartosci_losowe.Font = new Font(FontFamily.GenericSansSerif,12,FontStyle.Regular);
            komunikat_wartosci_losowe.Size = new System.Drawing.Size(300,30);
            komunikat_wartosci_losowe.Location = new Point(250,300);
            this.tabControl1.SelectedTab.Controls.Add(komunikat_wartosci_losowe);
            }

        //funkcja obsługujace opcję domyslna
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab.Controls.Remove(DolnaGranicaPrzedzialu);
            this.tabControl1.SelectedTab.Controls.Remove(GornaGrafnicaPrzedzialu);
            this.tabControl1.SelectedTab.Controls.Remove(txtDolnaGranicaPrzedzialu);
            this.tabControl1.SelectedTab.Controls.Remove(txtGornaGranicaPrzedzialu);

            
            for (i = 0; i < NominalyBankomatu.GetLength(0);i++ )
            {
                dgwListaWyplaty.Rows.Add();
                dgwListaWyplaty.Rows[i].Cells[0].Value = NominalyBankomatu[i,0];
                dgwListaWyplaty.Rows[i].Cells[1].Value = NominalyBankomatu[i,1];

                
                if (NominalyBankomatu[bs_i,1]>=NajmniejszyBanknot)
                {
                    dgwListaWyplaty.Rows[bs_i].Cells[2].Value = "Banknot";
                }
                else
                {
                    dgwListaWyplaty.Rows[bs_i].Cells[2].Value= "Moneta";
                }
                if (cmbRodzajWaluty.SelectedIndex==0)
                {
                    
                    dgwListaWyplaty.Rows[i].Cells[3].Value = "PLN";
                }
                else if (cmbRodzajWaluty.SelectedIndex==1) 
                {

                    dgwListaWyplaty.Rows[i].Cells[3].Value = "USD";
                } 
            }
            StanTabPage[2] = true;
            StanTabPage[1] = false;
            StanTabPage[0] = false;


            //bs_nowa_wyplata.Visible = false;
            tabControl1.SelectedTab = tabPage3;
        }

        

        //funkcja do przechodzenie miedzy zakladkami i blokowania ich
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabControl1.TabPages[0])
            {
                e.Cancel = true;
            }
            else if (e.TabPage == tabControl1.TabPages[1])
            {
                if (StanTabPage[1])
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else if (e.TabPage == tabControl1.TabPages[2])
            {
                if (StanTabPage[2])
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }
               
        }

        private void rezygnacja_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //funkcja wykonujaca wyplate
        private void akceptacja_Click(object sender, EventArgs e)
        {
            try
            {
                pieniadze_do_wyplaty = Convert.ToInt32(kwota_do_wyplaty.Text);
            }
            catch
            {
                komunikat.Text = "Wprowadzono nieprawidłowe dane";
                kwota_do_wyplaty.ForeColor = Color.Red;
                return;
            }
            if (pieniadze_do_wyplaty <= 0)
            {
                komunikat.Text = "Wartości ujemne lub równe zero - zabronione";
                kwota_do_wyplaty.ForeColor = Color.Red;
                return;
            }
            while (pieniadze_do_wyplaty > 0)
            {
                
                    for (i = 0; i < NominalyBankomatu.GetLength(0); bs_i++)
                    {
                        ilosc_nominalow = Convert.ToInt16(pieniadze_do_wyplaty / NominalyBankomatu[i, 1]);
                        if (ilosc_nominalow > (NominalyBankomatu[i, 0]))
                        {
                            ilosc_nominalow = Convert.ToInt32(NominalyBankomatu[i, 0]);

                        }
                        else
                        {
                            NominalyBankomatu[i, 0] = ilosc_nominalow;
                        }
                        dgwListaWyplaty.Rows.Add();
                        dgwListaWyplaty.Rows[i].Cells[0].Value = NominalyBankomatu[bs_i, 0];
                        dgwListaWyplaty.Rows[i].Cells[1].Value = NominalyBankomatu[bs_i, 1];
                        pieniadze_do_wyplaty = pieniadze_do_wyplaty - NominalyBankomatu[i, 0] * NominalyBankomatu[bs_i, 1];
                        if (ilosc_nominalow != 0)
                        {
                            wyplacona_wartosc = wyplacona_wartosc + ilosc_nominalow * NominalyBankomatu[i, 1]; 
                        }
                        
                    }
               }            

            tanTabPage[0] = false;
            StanTabPage[1] = false;
            StanTabPage[2] = true;

            tabControl1.SelectedTab = tabPage3;
            
            koniec.Visible = true;
            wyplac.Visible = false;
            komunikat_koncowy.Visible = true;
            wyplacona_kwota_komunikat.Text = Convert.ToString(wyplacona_wartosc);
            wyplacona_kwota_left.Visible = true;
            wyplacona_kwota_komunikat.Visible = true;
           }

        //funkcja przekierowujaca do zaladki z wyplacaniem
        private void resetuj_Click(object sender, EventArgs e)
        {
            for (i = 0; i < NominalyBankomatu.GetLength(0); i++)
            {
                dgwListaWyplaty.Rows.Add();
                dgwListaWyplaty.Rows[i].Cells[0].Value = NominalyBankomatu[i, 0];
                dgwListaWyplaty.Rows[i].Cells[1].Value = NominalyBankomatu[i, 1];
                if (NominalyBankomatu[i, 1] >= NajmniejszyBanknot)
                {
                    dgwListaWyplaty.Rows[i].Cells[2].Value = "Banknot";
                }
                else
                {
                    dgwListaWyplaty.Rows[i].Cells[2].Value = "Moneta";
                }
                
            }
            StanTabPage[0] = false;
            StanTabPage[1] = true;
            StanTabPage[2] = false;
            tabControl1.SelectedTab = tabPage2;
        }
        
        //funkcja losujaca ilosc nominalow
        private void los_lista_Click(object sender, EventArgs e)
        {
            try
            {
                dolna_granica = Convert.ToInt32(txtDolnaGranicaPrzedzialu.Text);
            }
            catch
            {
                komunikat_wartosci_losowe.Text = "Wprowadzono nie prawidłowe watości";
                txtDolnaGranicaPrzedzialu.ForeColor = Color.Red;
                return;
                
            }
            try
            {
                gorna_granica = Convert.ToInt32(txtGornaGranicaPrzedzialu.Text);
            }
            catch
            {
                komunikat_wartosci_losowe.Text = "Wprowadzono nie prawidłowe wartości";
                txtGornaGranicaPrzedzialu.ForeColor = Color.Red;
                return;
            }
                      
            for (i = 0; i < NominalyBankomatu.GetLength(0); i++)
            {
                NominalyBankomatu[i, 0] = rnd1.Next(dolna_granica,gorna_granica);

                dgwListaWyplaty.Rows.Add();
                dgwListaWyplaty.Rows[i].Cells[0].Value = NominalyBankomatu[i, 0];
                dgwListaWyplaty.Rows[i].Cells[1].Value = NominalyBankomatu[i, 1];


                if (NominalyBankomatu[i, 1] >= NajmniejszyBanknot)
                {
                    dgwListaWyplaty.Rows[i].Cells[2].Value = "Banknot";
                }
                else
                {
                    dgwListaWyplaty.Rows[i].Cells[2].Value = "Moneta";
                }
                if (cmbRodzajWaluty.SelectedIndex == 0)
                {

                    dgwListaWyplaty.Rows[i].Cells[3].Value = "PLN";
                }
                else if (cmbRodzajWaluty.SelectedIndex == 1)
                {

                    dgwListaWyplaty.Rows[i].Cells[3].Value = "USD";
                }
            }
            StanTabPage[2] = true;
            StanTabPage[1] = false;
           StanTabPage[0] = false;



            tabControl1.SelectedTab = tabPage3;


        }

        //funkcja do zerowania pol
        private void wyzeruj_Click(object sender, EventArgs e)
        {
            kwota_do_wyplaty.Text = "";
            kwota_do_wyplaty.Enabled = true;
            kwota_do_wyplaty.Focus();
        }

        //funkcja zieniajaca kolor tekstu w polu
        private void kwota_do_wyplaty_TextChanged(object sender, EventArgs e)
        {
            kwota_do_wyplaty.ForeColor = Color.Black;
            komunikat.Text = "";
        }
        
        //funkcja obslugujaca zamykanie programu
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult pytanie = MessageBox.Show("Czy chcesz zakończyć?",this.Text,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
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
                else
                {
                    e.Cancel = true;
                }
            }
        }

        //funkcja sluzaca do zamykania programu
        private void koniec_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
