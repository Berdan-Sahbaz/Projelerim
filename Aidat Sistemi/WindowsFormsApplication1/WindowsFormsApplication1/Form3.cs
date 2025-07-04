using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        //KİŞİ VE ÜCRETLERİN TUTULMASI İÇİN YENİ SÖZLÜK...
        Dictionary<string, decimal> odemelistesi = new Dictionary<string, decimal>();
        public Form3()
        {
            InitializeComponent();
            ListeyiDoldur();
            ToplamUcretiGuncelle();
        }

        private void ListeyiDoldur() 
        { 
        for (int i = 1; i <= 20; i++)
            {
                string isim = "Kişi " + i;
                decimal ucret = 950; 
                odemelistesi.Add(isim, ucret);
                listBox1.Items.Add(isim + " - " + ucret + " ₺");
            }
        }

        private void ToplamUcretiGuncelle()
        {
            decimal toplam = 0;
            foreach (var ucret in odemelistesi.Values)
            {
                toplam += ucret;
            }
            label1.Text = string.Format("Toplam: {0} ₺", toplam);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                // Satırdan isim kısmını çek
                string secilenSatir = listBox1.SelectedItem.ToString();
                string isim = secilenSatir.Split('-')[0].Trim(); // "Kişi 1"

                // Sözlükten sil
                if (odemelistesi.ContainsKey(isim))
                {
                    odemelistesi.Remove(isim);
                }
                
                // Listbox'tan sil
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

                // Toplam ücreti güncelle
                ToplamUcretiGuncelle();

                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Bu ay için ödeme kalmamıştır. Uygulama kapanıyor.", "Bilgi");
                    Application.Exit(); // Uygulamayı kapat
                }
            }
            else
            {
                MessageBox.Show("Lütfen listeden bir kişi seçin.");
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Programdan çıkış yapılsın mı?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
