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
using System.Xml.Linq;
using System.Threading;

namespace MK7_KCL_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static XElement Sub_Flags;
        public string k1;
        public string k2;
        public string k3;
        public string k4;

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            string[] Path = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (Path.Length <= 0)
            {
                return;
            }

            TextBox PathText = sender as TextBox;
            if (PathText == null)
            {
                return;
            }

            PathText.Text = Path[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //configファイルからKCLFlag.xmlのパスを取得
            textBox3.Text = Properties.Settings.Default.KCLFlagXml_FilePath;

            //XMLからフラグリストを読み込み
            var KCLFlagList = XDocument.Load(textBox3.Text);
            XElement ROOT = KCLFlagList.Element("KCLFlags");
            XElement Main_Flags = ROOT.Element("Main_0x1");
            //読み込んだ物をコレクションにする
            IEnumerable<XElement> MainFlagName = Main_Flags.Elements("Name");
            //foreachで読み込み
            foreach (XElement Main in MainFlagName)
            {
                comboBox1.Items.Add(Main.Value);
            }
            //comboBox1のインデックスを0にしてバグを防ぐ
            comboBox1.SelectedIndex = 0;

            //comboBox3の読み込み
            XElement Shadow_Flags = ROOT.Element("Shadow_0x3");
            IEnumerable<XElement> ShadowFlagName = Shadow_Flags.Elements("num");
            //foreachで読み込み
            foreach (XElement Shadow in ShadowFlagName)
            {
                comboBox3.Items.Add(Shadow.Value);
            }
            comboBox3.SelectedIndex = 0;

            //comboBox4の読み込み
            XElement SP_Flags = ROOT.Element("SP_0x4");
            IEnumerable<XElement> SPFlagName = SP_Flags.Elements("num");
            //foreachで読み込み
            foreach (XElement SP in SPFlagName)
            {
                comboBox4.Items.Add(SP.Value);
            }
            comboBox4.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //同じようにXmlを読み込む
            var KCLFlagList = XDocument.Load(textBox3.Text);
            XElement ROOT = KCLFlagList.Element("KCLFlags");
            //Sub_0x2を読み込み
            XElement Sub_Flags = ROOT.Element("Sub_0x2");
            if (comboBox1.SelectedIndex == 0)
            {
                //comboBox2のアイテムをクリア
                comboBox2.Items.Clear();
                //Sub_0x2->f_XXを読み込む
                XElement f0 = Sub_Flags.Element("f_0x00");
                //ここでコレクションに変換
                IEnumerable<XElement> f0_N = f0.Elements("Name");
                //foreachでcomboBox2に読み込ませる
                foreach (XElement i0 in f0_N)
                {
                    //アイテムを追加
                    comboBox2.Items.Add(i0.Value);
                    //必ずインデックスを0にする
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "0";

            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.Items.Clear();
                XElement f1 = Sub_Flags.Element("f_0x01");
                IEnumerable<XElement> f1_N = f1.Elements("Name");
                foreach (XElement i1 in f1_N)
                {
                    comboBox2.Items.Add(i1.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "1";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.Items.Clear();
                XElement f2 = Sub_Flags.Element("f_0x02");
                IEnumerable<XElement> f2_N = f2.Elements("Name");
                foreach (XElement i2 in f2_N)
                {
                    comboBox2.Items.Add(i2.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "2";
            }
            if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.Items.Clear();
                XElement f3 = Sub_Flags.Element("f_0x03");
                IEnumerable<XElement> f3_N = f3.Elements("Name");
                foreach (XElement i3 in f3_N)
                {
                    comboBox2.Items.Add(i3.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "3";
            }
            if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.Items.Clear();
                XElement f4 = Sub_Flags.Element("f_0x04");
                IEnumerable<XElement> f4_N = f4.Elements("Name");
                foreach (XElement i4 in f4_N)
                {
                    comboBox2.Items.Add(i4.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "4";
            }
            if (comboBox1.SelectedIndex == 5)
            {
                comboBox2.Items.Clear();
                XElement f5 = Sub_Flags.Element("f_0x05");
                IEnumerable<XElement> f5_N = f5.Elements("Name");
                foreach (XElement i5 in f5_N)
                {
                    comboBox2.Items.Add(i5.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "5";
            }
            if (comboBox1.SelectedIndex == 6)
            {
                comboBox2.Items.Clear();
                XElement f6 = Sub_Flags.Element("f_0x06");
                IEnumerable<XElement> f6_N = f6.Elements("Name");
                foreach (XElement i6 in f6_N)
                {
                    comboBox2.Items.Add(i6.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "6";
            }
            if (comboBox1.SelectedIndex == 7)
            {
                comboBox2.Items.Clear();
                XElement f7 = Sub_Flags.Element("f_0x07");
                IEnumerable<XElement> f7_N = f7.Elements("Name");
                foreach (XElement i7 in f7_N)
                {
                    comboBox2.Items.Add(i7.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "7";
            }
            if (comboBox1.SelectedIndex == 8)
            {
                comboBox2.Items.Clear();
                XElement f8 = Sub_Flags.Element("f_0x08");
                IEnumerable<XElement> f8_N = f8.Elements("Name");
                foreach (XElement i8 in f8_N)
                {
                    comboBox2.Items.Add(i8.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "8";
            }
            if (comboBox1.SelectedIndex == 9)
            {
                comboBox2.Items.Clear();
                XElement f9 = Sub_Flags.Element("f_0x09");
                IEnumerable<XElement> f9_N = f9.Elements("Name");
                foreach (XElement i9 in f9_N)
                {
                    comboBox2.Items.Add(i9.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "9";
            }
            if (comboBox1.SelectedIndex == 10)
            {
                comboBox2.Items.Clear();
                XElement fA = Sub_Flags.Element("f_0x0A");
                IEnumerable<XElement> fA_N = fA.Elements("Name");
                foreach (XElement iA in fA_N)
                {
                    comboBox2.Items.Add(iA.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "A";
            }
            if (comboBox1.SelectedIndex == 11)
            {
                comboBox2.Items.Clear();
                XElement fB = Sub_Flags.Element("f_0x0B");
                IEnumerable<XElement> fB_N = fB.Elements("Name");
                foreach (XElement iB in fB_N)
                {
                    comboBox2.Items.Add(iB.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "B";
            }
            if (comboBox1.SelectedIndex == 12)
            {
                comboBox2.Items.Clear();
                XElement fC = Sub_Flags.Element("f_0x0C");
                IEnumerable<XElement> fC_N = fC.Elements("Name");
                foreach (XElement iC in fC_N)
                {
                    comboBox2.Items.Add(iC.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "C";
            }
            if (comboBox1.SelectedIndex == 13)
            {
                comboBox2.Items.Clear();
                XElement fD = Sub_Flags.Element("f_0x0D");
                IEnumerable<XElement> fD_N = fD.Elements("Name");
                foreach (XElement iD in fD_N)
                {
                    comboBox2.Items.Add(iD.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "D";
            }
            if (comboBox1.SelectedIndex == 14)
            {
                comboBox2.Items.Clear();
                XElement fE = Sub_Flags.Element("f_0x0E");
                IEnumerable<XElement> fE_N = fE.Elements("Name");
                foreach (XElement iE in fE_N)
                {
                    comboBox2.Items.Add(iE.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "E";
            }
            if (comboBox1.SelectedIndex == 15)
            {
                comboBox2.Items.Clear();
                XElement fF = Sub_Flags.Element("f_0x0F");
                IEnumerable<XElement> fF_N = fF.Elements("Name");
                foreach (XElement iF in fF_N)
                {
                    comboBox2.Items.Add(iF.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "F";
            }

            //
            if (comboBox1.SelectedIndex == 16)
            {
                comboBox2.Items.Clear();
                XElement f10 = Sub_Flags.Element("f_0x10");
                IEnumerable<XElement> f10_N = f10.Elements("Name");
                foreach (XElement i10 in f10_N)
                {
                    comboBox2.Items.Add(i10.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "0";
            }
            if (comboBox1.SelectedIndex == 17)
            {
                comboBox2.Items.Clear();
                XElement f11 = Sub_Flags.Element("f_0x11");
                IEnumerable<XElement> f11_N = f11.Elements("Name");
                foreach (XElement i11 in f11_N)
                {
                    comboBox2.Items.Add(i11.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "1";
            }
            if (comboBox1.SelectedIndex == 18)
            {
                comboBox2.Items.Clear();
                XElement f12 = Sub_Flags.Element("f_0x12");
                IEnumerable<XElement> f12_N = f12.Elements("Name");
                foreach (XElement i12 in f12_N)
                {
                    comboBox2.Items.Add(i12.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "2";
            }
            if (comboBox1.SelectedIndex == 19)
            {
                comboBox2.Items.Clear();
                XElement f13 = Sub_Flags.Element("f_0x13");
                IEnumerable<XElement> f13_N = f13.Elements("Name");
                foreach (XElement i13 in f13_N)
                {
                    comboBox2.Items.Add(i13.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "3";
            }
            if (comboBox1.SelectedIndex == 20)
            {
                comboBox2.Items.Clear();
                XElement f14 = Sub_Flags.Element("f_0x14");
                IEnumerable<XElement> f14_N = f14.Elements("Name");
                foreach (XElement i14 in f14_N)
                {
                    comboBox2.Items.Add(i14.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "4";
            }
            if (comboBox1.SelectedIndex == 21)
            {
                comboBox2.Items.Clear();
                XElement f15 = Sub_Flags.Element("f_0x15");
                IEnumerable<XElement> f15_N = f15.Elements("Name");
                foreach (XElement i15 in f15_N)
                {
                    comboBox2.Items.Add(i15.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "5";
            }
            if (comboBox1.SelectedIndex == 22)
            {
                comboBox2.Items.Clear();
                XElement f16 = Sub_Flags.Element("f_0x16");
                IEnumerable<XElement> f16_N = f16.Elements("Name");
                foreach (XElement i16 in f16_N)
                {
                    comboBox2.Items.Add(i16.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "6";
            }
            if (comboBox1.SelectedIndex == 23)
            {
                comboBox2.Items.Clear();
                XElement f17 = Sub_Flags.Element("f_0x17");
                IEnumerable<XElement> f17_N = f17.Elements("Name");
                foreach (XElement i17 in f17_N)
                {
                    comboBox2.Items.Add(i17.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "7";
            }
            if (comboBox1.SelectedIndex == 24)
            {
                comboBox2.Items.Clear();
                XElement f18 = Sub_Flags.Element("f_0x18");
                IEnumerable<XElement> f18_N = f18.Elements("Name");
                foreach (XElement i18 in f18_N)
                {
                    comboBox2.Items.Add(i18.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "8";
            }
            if (comboBox1.SelectedIndex == 25)
            {
                comboBox2.Items.Clear();
                XElement f19 = Sub_Flags.Element("f_0x19");
                IEnumerable<XElement> f19_N = f19.Elements("Name");
                foreach (XElement i19 in f19_N)
                {
                    comboBox2.Items.Add(i19.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "9";
            }
            if (comboBox1.SelectedIndex == 26)
            {
                comboBox2.Items.Clear();
                XElement f1A = Sub_Flags.Element("f_0x1A");
                IEnumerable<XElement> f1A_N = f1A.Elements("Name");
                foreach (XElement i1A in f1A_N)
                {
                    comboBox2.Items.Add(i1A.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "A";
            }
            if (comboBox1.SelectedIndex == 27)
            {
                comboBox2.Items.Clear();
                XElement f1B = Sub_Flags.Element("f_0x1B");
                IEnumerable<XElement> f1B_N = f1B.Elements("Name");
                foreach (XElement i1B in f1B_N)
                {
                    comboBox2.Items.Add(i1B.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "B";
            }
            if (comboBox1.SelectedIndex == 28)
            {
                comboBox2.Items.Clear();
                XElement f1C = Sub_Flags.Element("f_0x1C");
                IEnumerable<XElement> f1C_N = f1C.Elements("Name");
                foreach (XElement i1C in f1C_N)
                {
                    comboBox2.Items.Add(i1C.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "C";
            }
            if (comboBox1.SelectedIndex == 29)
            {
                comboBox2.Items.Clear();
                XElement f1D = Sub_Flags.Element("f_0x1D");
                IEnumerable<XElement> f1D_N = f1D.Elements("Name");
                foreach (XElement i1D in f1D_N)
                {
                    comboBox2.Items.Add(i1D.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "D";
            }
            if (comboBox1.SelectedIndex == 30)
            {
                comboBox2.Items.Clear();
                XElement f1E = Sub_Flags.Element("f_0x1E");
                IEnumerable<XElement> f1E_N = f1E.Elements("Name");
                foreach (XElement i1E in f1E_N)
                {
                    comboBox2.Items.Add(i1E.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "E";
            }
            if (comboBox1.SelectedIndex == 31)
            {
                comboBox2.Items.Clear();
                XElement f1F = Sub_Flags.Element("f_0x1F");
                IEnumerable<XElement> f1F_N = f1F.Elements("Name");
                foreach (XElement i1F in f1F_N)
                {
                    comboBox2.Items.Add(i1F.Value);
                    comboBox2.SelectedIndex = 0;
                }
                k1 = "F";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //k2
            //判定1(comboBox1のインデックスが16以下の場合)
            if (comboBox1.SelectedIndex <= 15)
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    k2 = "0";
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    k2 = "2";
                }
                if (comboBox2.SelectedIndex == 2)
                {
                    k2 = "4";
                }
                if (comboBox2.SelectedIndex == 3)
                {
                    k2 = "6";
                }
                if (comboBox2.SelectedIndex == 4)
                {
                    k2 = "8";
                }
                if (comboBox2.SelectedIndex == 5)
                {
                    k2 = "A";
                }
                if (comboBox2.SelectedIndex == 6)
                {
                    k2 = "C";
                }
                if (comboBox2.SelectedIndex == 7)
                {
                    k2 = "E";
                }

            }
            else
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    k2 = "1";
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    k2 = "3";
                }
                if (comboBox2.SelectedIndex == 2)
                {
                    k2 = "5";
                }
                if (comboBox2.SelectedIndex == 3)
                {
                    k2 = "7";
                }
                if (comboBox2.SelectedIndex == 4)
                {
                    k2 = "9";
                }
                if (comboBox2.SelectedIndex == 5)
                {
                    k2 = "B";
                }
                if (comboBox2.SelectedIndex == 6)
                {
                    k2 = "D";
                }
                if (comboBox2.SelectedIndex == 7)
                {
                    k2 = "F";
                }
            }

            //k3
            if (comboBox3.SelectedIndex == 0)
            {
                k3 = "0";
            }
            if (comboBox3.SelectedIndex == 1)
            {
                k3 = "1";
            }
            if (comboBox3.SelectedIndex == 2)
            {
                k3 = "2";
            }
            if (comboBox3.SelectedIndex == 3)
            {
                k3 = "3";
            }
            if (comboBox3.SelectedIndex == 4)
            {
                k3 = "4";
            }
            if (comboBox3.SelectedIndex == 5)
            {
                k3 = "5";
            }
            if (comboBox3.SelectedIndex == 6)
            {
                k3 = "6";
            }
            if (comboBox3.SelectedIndex == 7)
            {
                k3 = "7";
            }
            if (comboBox3.SelectedIndex == 8)
            {
                k3 = "8";
            }
            if (comboBox3.SelectedIndex == 9)
            {
                k3 = "9";
            }
            if (comboBox3.SelectedIndex == 10)
            {
                k3 = "A";
            }
            if (comboBox3.SelectedIndex == 11)
            {
                k3 = "B";
            }
            if (comboBox3.SelectedIndex == 12)
            {
                k3 = "C";
            }
            if (comboBox3.SelectedIndex == 13)
            {
                k3 = "D";
            }
            if (comboBox3.SelectedIndex == 14)
            {
                k3 = "E";
            }
            if (comboBox3.SelectedIndex == 15)
            {
                k3 = "F";
            }

            //k4
            if (comboBox4.SelectedIndex == 0)
            {
                k4 = "0";
            }
            if (comboBox4.SelectedIndex == 1)
            {
                k4 = "1";
            }
            if (comboBox4.SelectedIndex == 2)
            {
                k4 = "2";
            }
            if (comboBox4.SelectedIndex == 3)
            {
                k4 = "3";
            }
            if (comboBox4.SelectedIndex == 4)
            {
                k4 = "4";
            }
            if (comboBox4.SelectedIndex == 5)
            {
                k4 = "5";
            }
            if (comboBox4.SelectedIndex == 6)
            {
                k4 = "6";
            }
            if (comboBox4.SelectedIndex == 7)
            {
                k4 = "7";
            }
            if (comboBox4.SelectedIndex == 8)
            {
                k4 = "8";
            }
            if (comboBox4.SelectedIndex == 9)
            {
                k4 = "9";
            }
            if (comboBox4.SelectedIndex == 10)
            {
                k4 = "A";
            }
            if (comboBox4.SelectedIndex == 11)
            {
                k4 = "B";
            }
            if (comboBox4.SelectedIndex == 12)
            {
                k4 = "C";
            }
            if (comboBox4.SelectedIndex == 13)
            {
                k4 = "D";
            }
            if (comboBox4.SelectedIndex == 14)
            {
                k4 = "E";
            }
            if (comboBox4.SelectedIndex == 15)
            {
                k4 = "F";
            }


            string o = k4 + k3 + k2 + k1;
            textBox1.Text = o;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text +" : " + textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch(System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("削除する要素が選択されていません");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //listboxに存在する複数のアイテムを取得
            string str = "";
            ListBox.ObjectCollection KclFlagList = listBox1.Items;
            foreach (object liststr in KclFlagList)
            {
                str = str + liststr.ToString() + "\r\n";
            }
            //listboxの内容をtxtファイルに書き込み
            File.WriteAllText("kclFlag.txt", str);
        }

        //スレッド
        Thread t1;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //パスの保存
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("パスを入力してください");
                //パスが空のためスレッドの実行を停止
                t1.Abort();
            }
            else
            {
                //パスの保存を開始
                Properties.Settings.Default.KCLFlagXml_FilePath = textBox3.Text;
                Properties.Settings.Default.Save();
            }
        }
    }
}
