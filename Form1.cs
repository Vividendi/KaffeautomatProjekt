using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaffeautomatProjekt
{
    public partial class Form1 : Form
    {
        
        public static double
            // Dessa variabler används för priskoll av drycker
            Mocka = 7, 
            Choklad = 8.5, 
            Espresso = 12.5, 
            NyponSoppa = 11, 
            FruktSoppa = 14, 
            Cappuchino = 12, 
            Kaffe = 6,

            /*De fyra första variabler här används för att räkna antalet mynt som stoppas in i automaten,
              växel och betalning används för att beräkna vad man får i växel vid betalning
              och beställt används i en if-sats så användaren inte kan slutföra beställningen innan man valt dryck eller betalat */
            tiokronor, femkronor, enkrona, femtioore, växel, betalning, beställt = 0;

        public Form1()
        {
            InitializeComponent();
        }

        //Dessa funktioner stoppar bara in ett mynt av den typ man valt och kör funktionen KollaAllaPriser

        private void btn10kr_Click(object sender, EventArgs e)
        {
            tiokronor++;
            betalning += 10;
            KollaAllaPriser();
        }

        private void btn5kr_Click(object sender, EventArgs e)
        {
            femkronor++;
            betalning += 5;
            KollaAllaPriser();
        }

        private void btn1kr_Click(object sender, EventArgs e)
        {
            enkrona++;
            betalning += 1;
            KollaAllaPriser();
        }

        private void btn50ore_Click(object sender, EventArgs e)
        {
            femtioore++;
            betalning += 0.5;
            KollaAllaPriser();
        }

        //Denna återställer programmet till hur den var från början vid slutförd beställning eller om man trycker på Reset-knappen

        public void ResetForm()
        {
            Form1.tiokronor = 0;
            Form1.femkronor = 0;
            Form1.enkrona = 0;
            Form1.femtioore = 0;
            Form1.betalning = 0;
            Form1.växel = 0;
            beställt = 0;
            lblVäxel.Text = "0";
            lblDryckval.Text = "";
            KollaAllaPriser();
            btn10kr.Enabled = true;
            btn5kr.Enabled = true;
            btn1kr.Enabled = true;
            btn50ore.Enabled = true;
            pbxKaffe.BackgroundImage = null;
        }


        //Reset-knappen
        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /*KollaAllaPriser-funktionen som uppdaterar alla siffror på automaten och skickar sedan hur mycket man betalat, 
         *priset på drycken och vilken beställningsknapp som hör till drycken till PrisKoll-funktionen*/
        private void KollaAllaPriser()
        {
            UppdateraLabels();
            
            PrisKoll(betalning, Form1.Mocka, btnMocka);
            PrisKoll(betalning, Form1.Choklad, btnChoklad);
            PrisKoll(betalning, Form1.Espresso, btnEspresso);
            PrisKoll(betalning, Form1.NyponSoppa, btnNyponSoppa);
            PrisKoll(betalning, Form1.FruktSoppa, btnFruktSoppa);
            PrisKoll(betalning, Form1.Cappuchino, btnCappuchino);
            PrisKoll(betalning, Form1.Kaffe, btnKaffe);
        }


        /*Uppdaterar mynträknarna, mätaren som visar hur mycket man betalat 
         *och ser till så att instruktionstextrutan förblir tom tills beställning sker*/
        private void UppdateraLabels()
        {
            lblBetalSumma.Text = betalning.ToString();
            lbl50ore.Text = femtioore.ToString();
            lbl1kr.Text = enkrona.ToString();
            lbl5kr.Text = femkronor.ToString();
            lbl10kr.Text = tiokronor.ToString();
            lblInstuktioner.Text = "";

        }

        /*Om man har stoppat in tillräckligt mycket pengar för en dryck så kommer denna 
         *funktion att låta användaren trycka på den knappen men gör ingenting innan man betalat tillräckligt för en dryck*/
        private void PrisKoll(double pengar, double pris, Button button)
        {
            if (pengar >= pris)
            {
                button.Enabled = true;
            }
            else
            {
                button.Enabled = false;
            }
        }


        //Beräknar växel och placerar en mugg med dricka i automaten
        private void BeräknaVäxel(double betalat, double dryckpris)
        {
            växel = betalat - dryckpris;
            lblVäxel.Text = växel.ToString();
            btn10kr.Enabled = false;
            btn5kr.Enabled = false;
            btn1kr.Enabled = false;
            btn50ore.Enabled = false;
            beställt = 1;
            lblInstuktioner.Text = "Tryck på muggen för att slutföra ert köp.";
            pbxKaffe.BackgroundImage = Properties.Resources.to_go_cup_paper_coffee_Xo66eK2_600;
        }

        /*Dessa funktioner visar dryckens namn på automaten och kör funktionen BeräknaVäxel och skickar dit hur mycket drycken kostar 
         *och hur mycket man betalat för att beräkna hur mycket man får i växel*/

        private void btnMocka_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Mocka";
            BeräknaVäxel(Form1.betalning, Form1.Mocka);
        }

        private void btnChoklad_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Choklad";
            BeräknaVäxel(Form1.betalning, Form1.Choklad);
        }

        private void btnEspresso_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Espresso";
            BeräknaVäxel(Form1.betalning, Form1.Espresso);
        }

        private void btnNyponSoppa_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Nyponsoppa";
            BeräknaVäxel(Form1.betalning, Form1.NyponSoppa);
        }

        private void btnFruktSoppa_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Fruktsoppa";
            BeräknaVäxel(Form1.betalning, Form1.FruktSoppa);
        }

        private void btnCappuchino_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Cappuchino";
            BeräknaVäxel(Form1.betalning, Form1.Cappuchino);
        }

        private void btnKaffe_Click(object sender, EventArgs e)
        {
            lblDryckval.Text = "Kaffe";
            BeräknaVäxel(Form1.betalning, Form1.Kaffe);
        }

        /*När beställningen är klar som bedöms genom if-satsen så trycker man på drycken för att ta emot den och då återställs
         programmet och den tackar även för köpet*/
        private void pbxKaffe_Click(object sender, EventArgs e)
        {
            if (beställt == 1)
            {
                ResetForm();
                lblInstuktioner.Text = "Tack för köpet.";
            }
        }

        //Funktion som avslutar programmet när Exit-knappen trycks

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
