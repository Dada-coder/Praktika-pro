using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_davai.BD;
using System.Data.SqlClient;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using System;
using static MaterialDesignThemes.Wpf.Theme;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;



namespace wpf_davai
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Contecst db;
        


        public int Vibor1 = 0;
        
        public string Login;
        public string Password;
       

        public decimal chetchik = 0;

        public MainWindow()
        {
            db = new Contecst();
            InitializeComponent();
           
            db.uslugidb.Load();
            Dgauto.ItemsSource = db.uslugidb.AsEnumerable().ToList();
            Dgauto2.ItemsSource = db.uslugidb.AsEnumerable().ToList();
           

            this.Closing += Window_Closing;


        }
        public void izm_cvet (int a)
        {
            switch(a)
            {
                case 1: 
                    Btbz.Background = Brushes.MediumPurple;
                    BtVn.Background = Brushes.MediumPurple;
                    BtMv.Background = Brushes.MediumPurple;
                    break;
                case 2:
                    Btlg.Background = Brushes.MediumPurple;
                    BtVn.Background = Brushes.MediumPurple;
                    BtMv.Background = Brushes.MediumPurple;
                    break;
                case 3:
                    Btbz.Background = Brushes.MediumPurple;
                    Btlg.Background = Brushes.MediumPurple;
                    BtMv.Background = Brushes.MediumPurple;
                    break;
                case 4:
                    Btbz.Background = Brushes.MediumPurple;
                    BtVn.Background = Brushes.MediumPurple;
                    Btlg.Background = Brushes.MediumPurple;
                    break;

            }
        }
       
        
        private void Buttreg(object sender, RoutedEventArgs e)
        {
            string login = Loginbox.Text.Trim();
            string pass = Passwordbox2.Text.Trim();

            if (login == "admin" && pass == "12345")
            {
                adminpage.Visibility = Visibility.Visible;
                klientpage.Visibility = Visibility.Hidden;
                okno_auth.Visibility = Visibility.Hidden;
            }
            if(login == null){
                MessageBox.Show("NENE");
            }
            if (pass == null)
            {
                MessageBox.Show("NENE");
            }
            else
            {
                MessageBox.Show("Good man");
                Users user = new Users(login, pass);
                db.users.Add(user);
                db.SaveChanges();
            }
        }

        private void Buttvhod(object sender, RoutedEventArgs e)
        {
            string login = Loginbox.Text.Trim();
            string pass = Passwordbox2.Text.Trim();
            if (login == "admin" && pass == "12345")
            {
               adminpage.Visibility = Visibility.Visible;
               klientpage.Visibility = Visibility.Hidden;
               okno_auth.Visibility = Visibility.Hidden;
            }
            Users authuser = null;
            using (Contecst db = new Contecst())
            {
                authuser = db.users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
            }
            if (authuser != null)
            {
                VHOD.Foreground = Brushes.Green;
                Login = login;
                Password = pass;
                okno_auth.Visibility = Visibility.Hidden;
                db.Zakaz.Load();
                dgzakaz.ItemsSource = db.Zakaz.Where(d => d.Name == Login && d.Number == Password).AsEnumerable().ToList();
            }
            else
            {
                VHOD.Foreground = Brushes.Red;
            }
            
        }
        
        private void Button_big(object sender, RoutedEventArgs e)
        {
            string login = Loginbox.Text.Trim();
            string pass = Passwordbox2.Text.Trim();
            if (login == "admin" && pass == "12345")
            {
                adminpage.Visibility = Visibility.Visible;
                klientpage.Visibility = Visibility.Hidden;
                okno_auth.Visibility = Visibility.Hidden;
            }
            Users authuser = null;
            using (Contecst db = new Contecst())
            {
                authuser = db.users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
            }
            if (authuser != null)
            {
                VHOD.Foreground = Brushes.Green;
                Login = login;
                Password = pass;
                okno_auth.Visibility = Visibility.Hidden;
                db.Zakaz.Load();
                dgzakaz.ItemsSource = db.Zakaz.Where(d => d.Name == Login && d.Number == Password).AsEnumerable().ToList();
            }
            else
            {
                VHOD.Foreground = Brushes.Red;
            }
        }

        private void Loginbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtLeg(object sender, RoutedEventArgs e)
        {
            if (BtLeg != null)
            {
                Vibor1 = 1;
                Btlg.Background = Brushes.MediumOrchid;
                izm_cvet(Vibor1);
            }
            
        }

        private void Btbiz(object sender, RoutedEventArgs e)
        {
            if (Btbiz != null)
            {
                Vibor1 = 2;
                Btbz.Background = Brushes.MediumOrchid;
                izm_cvet(Vibor1);
            }
        }

        private void BtVned(object sender, RoutedEventArgs e)
        {
            if (BtVned != null)
            {
                Vibor1 = 3;
                BtVn.Background = Brushes.MediumOrchid;
                izm_cvet(Vibor1);
            }
        }

        private void BtMvan(object sender, RoutedEventArgs e)
        {
            if (BtLeg != null)
            {
                Vibor1 = 4;
                BtMv.Background = Brushes.MediumOrchid;
                izm_cvet(Vibor1);
            }
        }

        private void BtLeg_Out(object sender, RoutedEventArgs e)
        {
        //    if (Vibor1 != 1)
        //    {
        //        Btlg.Background = Brushes.Red;
        //    }
        }

        private void Btbz_Out(object sender, RoutedEventArgs e)
        {
        //    if (Vibor1 != 2)
        //    {
        //        Btbz.Background = Brushes.Red;
        //    }
        }

       private void BtVn_Out(object sender, RoutedEventArgs e)
        {
        //    if (Vibor1 != 3)
        //    {
        //        BtVn.Background = Brushes.Red;
        //    }
        }

        private void BtMv_Out(object sender, RoutedEventArgs e)
        {
        //    if (Vibor1 != 4)
        //    {
        //        BtMv.Background = Brushes.Red;
        //    }
        }

        private void Dgauto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            db.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            dgzakaz2.ItemsSource = db.Zakaz.AsEnumerable().ToList();



        }

        private void Uslug_List_ListChanged(object sender, ListChangedEventArgs e)
        {
          
        }
        public string Kuzov(int kuzov)
        {
            string a = "";
            switch (kuzov)
            {
                case 1:
                    a = "Легковая";
                    break;
                case 2:
                    a = "Бизнес седан";
                    break;
                case 3:
                    a = "Внедорожник";
                    break;
                case 4:
                    a = "Минивэн";
                    break;
            }
            return a;
        }
        public double Kuzov2(int kuzov)
        {
            double a = 0;
            switch (kuzov)
            {
                case 1:
                    a = 1;
                    break;
                case 2:
                    a = 1.1;
                    break;
                case 3:
                    a = 1.2;
                    break;
                case 4:
                    a = 1.3;
                    break;
            }
            return a;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
          
            
            string b = Kuzov(Vibor1);
            double c = Kuzov2(Vibor1);


            try
            {
                using (Contecst db = new Contecst())
                {
                    var uslugiList = db.uslugidb.Where(u => u.da == true).ToList();

                    foreach (var uslugi in uslugiList)
                    {
                        Zakazz zakaz1 = new Zakazz
                        {
                            Name = Login,
                            Number = Password,
                            Kuzov = b,
                            usluga = uslugi.usluga,
                            cena = uslugi.cena * c
                        };
                        db.Zakaz.Add(zakaz1);
                    }
                    MessageBox.Show("Vse good man");
                    db.SaveChanges();
               }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("fignya");
            }

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            db.SaveChanges();
            //db.Dispose();

        }

        private void ItemsDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

          



        }

        private void Dgauto2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void Dgauto2_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            db.SaveChanges();
        }
        double h = 0;
        private void Add(object sender, RoutedEventArgs e)
        {
            try
            {
                Uslugi usluga = new Uslugi
                {
                    usluga = Uslugatextbox.Text.ToString(),
                    cena = double.Parse(Cenatextbox.Text.ToString())
                };
                db.Add(usluga);
                MessageBox.Show("Vse good man");
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("fignya");
            }



        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Uslugi delBook = db.uslugidb.Where(x => x.usluga == Uslugatextbox.Text).FirstOrDefault();
                db.uslugidb.Remove(delBook);
                db.SaveChanges();
                MessageBox.Show("good delete man");
            }
            catch (Exception ex)
            {
                MessageBox.Show("fignya");
            }


        }

        private void Delete2(object sender, RoutedEventArgs e)
        {
            try
            {
                Zakazz delBook2 = db.Zakaz.Where(x => x.Name == Nametextbox.Text && x.usluga == Uslugatext.Text).FirstOrDefault();
                db.Zakaz.Remove(delBook2);
                db.SaveChanges();
                MessageBox.Show("good delete man");
            }
            catch (Exception ex)
            {
                MessageBox.Show("fignya");
            }
        }

        private void TabItem_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            //db.Zakaz.Load();
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            db.Zakaz.Load();
            dgzakaz.ItemsSource = db.Zakaz.Where(d => d.Name == Login && d.Number == Password).AsEnumerable().ToList();
        }
    }
}