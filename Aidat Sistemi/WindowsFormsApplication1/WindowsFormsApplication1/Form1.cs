using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //ATAMALARIN BÜTÜN KODDA GEÇERLİLİĞİ...
        private string kayitlikullaniciadi = "";
        private string kayitlisifre = "";
        private string tckimlik = "";
        private string dosyayolu = "kullanıcı.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ATAMALAR KODU...
            
            string kayitlikullaniciadi = textBox1.Text;
            string kayitlisifre = textBox2.Text;
            string tckimlik = textBox5.Text;

            //TEXTBOXLARIN DOLULUĞU...
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox5.Text.Trim()=="")
            {
                MessageBox.Show("Lütfen kullanıcı adı , şifre ve TC giriniz.");
                return;
            }
            else
            {
                //KULLANICI ADI VE ŞİFREYİ TEXTBOXLARA EŞİTLEME...
                kayitlikullaniciadi = textBox1.Text;
                kayitlisifre = textBox2.Text;
                tckimlik = textBox5.Text;
                //MessageBox.Show("Kayıt Başarılı...");
                textBox1.Clear();
                textBox2.Clear();
                textBox5.Clear();
            }
            //DOSYA YOLUNU BULDURMA KODU...
            if (File.Exists(dosyayolu))
            {
                string[] satirlar = File.ReadAllLines(dosyayolu);
                foreach (string satir in satirlar)
                {
                    string[] parca = satir.Split(';');
                    if (parca[0] == tckimlik)
                    {
                        MessageBox.Show("Bu TC numarası zaten kayıtlı!");
                        return;
                    }
                }
            }
            //DOSYAYA KAYIT KODU...
            File.AppendAllText(dosyayolu, kayitlikullaniciadi + ";" + kayitlisifre + ";" + tckimlik +Environment.NewLine);
            MessageBox.Show("Kayıt Başarılı...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string girisadi = textBox3.Text.Trim();
            string girissifre = textBox4.Text.Trim();
            string giristc = textBox6.Text.Trim();

            //Belirtilen kullanici.txt dosyasının var olup olmadığını kontrol eder.
            if (!File.Exists(dosyayolu))
        {
            MessageBox.Show("Hiçbir kullanıcı kaydı yok!");
            return;
        }
            //Girişin doğruluğunu kontrol eder eğer doğruysa false-ı true çevirir...
        bool girisBasarili = false;
            //Satırların hepsini okur..
        string[] satirlar = File.ReadAllLines(dosyayolu);
        //Bu bölüm kullanıcı adı ve şifreyi satır satır kontrol eder...
        foreach (string satir in satirlar)
        {
            string[] parca = satir.Split(';');
            if (parca.Length == 3)
            {
                if (parca[0] == girisadi && parca[1] == girissifre && parca[2]==giristc)
                {
                    girisBasarili = true;
                    break;
                }
            }
        }
            //Giriş başarılıysa form2yi açar...
        if (girisBasarili)
        {
            MessageBox.Show("Giriş başarılı!");
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Kullanıcı adı veya şifre yanlış!");
        }
    }
        }
    }

