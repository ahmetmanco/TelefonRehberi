using Microsoft.Data.SqlClient;
using TelefonRehberi.Models;

namespace TelefonRehberi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Liste();
        }
        TelefonRehberiContext context = new TelefonRehberiContext();

        void Liste()
        {
           lstTelRehberi.Items.Clear();
            var deger = context.Kisilers.ToList();
            foreach (var deg in deger)
            {
                ListViewItem liste = new ListViewItem(deg.KisilerId.ToString());
                liste.SubItems.Add(deg.KisiAdi.ToString());
                liste.SubItems.Add(deg.KisiSoyadi.ToString());
                liste.SubItems.Add(deg.TelefonNo.ToString());
                lstTelRehberi.Items.Add(liste);
            }
        }
        void Liste(int ID)
        {
            lstTelRehberi.Items.Clear();
            var deger = context.Kisilers.Where(x => x.KisilerId == ID).ToList();
            foreach (var deg in deger)
            {
                ListViewItem liste = new ListViewItem(deg.KisilerId.ToString());
                liste.SubItems.Add(deg.KisiAdi.ToString());
                liste.SubItems.Add(deg.KisiSoyadi.ToString());
                liste.SubItems.Add(deg.TelefonNo.ToString());
                lstTelRehberi.Items.Add(liste);
            }
        }
        void IcerigiTemizle()
        {
            foreach (Control kontrol in this.Controls)
            {
                if (kontrol is GroupBox)
                {
                    foreach (Control kontrol2 in kontrol.Controls)
                    {
                        if (kontrol2 is TextBox)
                            ((TextBox)kontrol2).Clear();
                    }
                }
            }
        }
        //private void VeritabaniYukle()
        //{
        //    baglanti = new SqlConnection("server=.;Database=TelefonRehberi;Trusted_Connection=True;");
        //}
        private void btnRehbereEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAd.Text) && !string.IsNullOrEmpty(txtSoyad.Text))
            {
                context.Kisilers.Add(new Kisiler() { KisiAdi= txtAd.Text, KisiSoyadi=txtSoyad.Text, TelefonNo=txtTelNo.Text});

                context.SaveChanges();
                MessageBox.Show("Ekleme Yapýldý", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Boþ alan kalmamalýdýr","Uyarý",MessageBoxButtons.OK, MessageBoxIcon.Warning);

            IcerigiTemizle();
            #region
            //komut = new SqlCommand("insert into Kisiler(Kisiadi,Kisisoyadi,TelefonNo) values (@kisiadi,@kisisoyadi,@telNo)");

            //komut.Parameters.AddWithValue("@kisiadi",txtAd.Text);
            //komut.Parameters.AddWithValue("@kisisoyadi", txtSoyad.Text);
            //komut.Parameters.AddWithValue("@telNo", txtTelNo.Text);
            //komut.Connection=baglanti;

            //if(baglanti.State==System.Data.ConnectionState.Closed) { baglanti.Open();}

            //try
            //{
            //    int SatirGuncelle = komut.ExecuteNonQuery();
            //    MessageBox.Show(SatirGuncelle + "Güncellendi");
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); 
            //}
            //finally { baglanti.Close(); }
            #endregion
        }
        private void btnYenile_Click(object sender, EventArgs e)
        {
            Liste();
            IcerigiTemizle();
            btnGuncelle.Enabled = false;
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            lstTelRehberi.Items.Clear();
            string ara = txtKisiAra.Text.Trim().Replace(" ", "");

            var degerler = context.Kisilers.Where(x=>(x.KisiAdi + x.KisiSoyadi).Contains(ara)).ToList();
            foreach(var deger in degerler)
            {
                ListViewItem liste = new ListViewItem(deger.KisilerId.ToString());
                liste.SubItems.Add(deger.KisiAdi.ToString());
                liste.SubItems.Add(deger.KisiSoyadi.ToString());
                liste.SubItems.Add(deger.TelefonNo.ToString());
                lstTelRehberi.Items.Add(liste);
            }
            if (degerler.Count != 0)
                btnGuncelle.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAd.Text) && !string.IsNullOrEmpty(txtSoyad.Text) && !string.IsNullOrEmpty(txtTelNo.Text))
            {
                context.Kisilers.Add(new Kisiler() 
                { 
                    KisiAdi = txtAd.Text, KisiSoyadi = txtSoyad.Text, TelefonNo = txtTelNo.Text 
                });

                context.SaveChanges();
                MessageBox.Show("Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}