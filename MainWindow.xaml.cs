using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Title = e.Key.ToString();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == true)
            {
                //テキストファイルを開く
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                byte[] bs = new byte[fs.Length];
                //byte配列に読み込む
                fs.Read(bs, 0, bs.Length);
                fs.Close();

                //文字コードを取得する
                Encoding enc = CodeSetting.GetCode(bs);
                
                //文字コードを表示する
                stbEnc.Content = enc.EncodingName;

                //デコードして表示する
                textBox1.Text = enc.GetString(bs);
            }
            
        }

        private void AppExit(object sender, RoutedEventArgs e)
        {
            //ウィンドウを閉じる
            this.Close();
        }

        private void SearchText(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("search");

        }

    }

}
