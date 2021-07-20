using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Intel8086
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Random random = new Random();
        private string[] _memory;
        private string[] _stack;

        public MainWindow()
        {


            InitializeComponent();
            _stack = new string[64 * 1024];
            _memory = new string[64 * 1024];
            AX.Content = "0000";
            BX.Content = "0000";
            CX.Content = "0000";
            DX.Content = "0000";
            SI.Content = "0000";
            DI.Content = "0000";
            BX.Content = "0000";
            BP.Content = "0000";
            SP.Content = "0000";
            DISP.Content = "0000";



        }

        private void tb_PressEnter2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                var temp = sender as TextBox;
                if (temp.Text.Length != 2) return;

                switch (temp.Name[0])
                {
                    case 'A':
                        {
                            if (temp.Name[1] == 'L') AX.Content = String.Format("{0}{1}{2}", AX.Content.ToString().ToUpper()[0], AX.Content.ToString().ToUpper()[1], temp.Text.ToUpper());
                            if (temp.Name[1] == 'H') AX.Content = String.Format("{0}{1}{2}", temp.Text.ToUpper(), AX.Content.ToString().ToUpper()[2], AX.Content.ToString().ToUpper()[3]);
                            temp.Text = String.Empty;
                            break;
                        }
                    case 'B':
                        {
                            if (temp.Name[1] == 'L') BX.Content = String.Format("{0}{1}{2}", BX.Content.ToString().ToUpper()[0], BX.Content.ToString().ToUpper()[1], temp.Text.ToUpper());
                            if (temp.Name[1] == 'H') BX.Content = String.Format("{0}{1}{2}", temp.Text.ToUpper(), BX.Content.ToString().ToUpper()[2], BX.Content.ToString().ToUpper()[3]);
                            temp.Text = String.Empty;
                            break;
                        }
                    case 'C':
                        {
                            if (temp.Name[1] == 'L') CX.Content = String.Format("{0}{1}{2}", CX.Content.ToString().ToUpper()[0], CX.Content.ToString().ToUpper()[1], temp.Text.ToUpper());
                            if (temp.Name[1] == 'H') CX.Content = String.Format("{0}{1}{2}", temp.Text.ToUpper(), CX.Content.ToString().ToUpper()[2], CX.Content.ToString().ToUpper()[3]);
                            temp.Text = String.Empty;
                            break;
                        }
                    case 'D':
                        {
                            if (temp.Name[1] == 'L') DX.Content = String.Format("{0}{1}{2}", DX.Content.ToString().ToUpper()[0], DX.Content.ToString().ToUpper()[1], temp.Text.ToUpper());
                            if (temp.Name[1] == 'H') DX.Content = String.Format("{0}{1}{2}", temp.Text.ToUpper(), DX.Content.ToString().ToUpper()[2], DX.Content.ToString().ToUpper()[3]);
                            temp.Text = String.Empty;
                            break;
                        }
                }


            }
        }

        private void tb_PressEnter4(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                var temp = sender as TextBox;
                if (temp.Text.Length != 4) return;
                switch (temp.Name)
                {
                    case "SI_i":
                        SI.Content = temp.Text.ToUpper();
                        temp.Text = String.Empty;
                        break;
                    case "DI_i":
                        DI.Content = temp.Text.ToUpper();
                        temp.Text = String.Empty;
                        break;
                    case "BX_i":
                        BX.Content = temp.Text.ToUpper();
                        temp.Text = String.Empty;
                        break;
                    case "BP_i":
                        BP.Content = temp.Text.ToUpper();
                        temp.Text = String.Empty;
                        break;
                    case "Disp_i":
                        DISP.Content = temp.Text.ToUpper();
                        temp.Text = String.Empty;
                        break;
                    case "SP_i":
                        SP.Content = temp.Text.ToUpper();
                        temp.Text = String.Empty;
                        break;
                }
            }
        }

        private void btn_mov_Click(object sender, RoutedEventArgs e)
        {
            if (regreg.IsChecked == true)
            {
                switch (cb_From.Text)
                {
                    case "AX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        break;
                                    }
                                case "BX":
                                    {
                                        BX.Content = AX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "CX":
                                    {
                                        CX.Content = AX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "DX":
                                    {
                                        DX.Content = AX.Content.ToString().ToUpper();
                                        break;
                                    }
                            }

                            break;
                        }
                    case "BX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        AX.Content = BX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "BX":
                                    {

                                        break;
                                    }
                                case "CX":
                                    {
                                        CX.Content = BX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "DX":
                                    {
                                        DX.Content = BX.Content.ToString().ToUpper();
                                        break;
                                    }
                            }

                            break;
                        }

                    case "CX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        AX.Content = CX.Content.ToString().ToUpper();

                                        break;
                                    }
                                case "BX":
                                    {
                                        BX.Content = CX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "CX":
                                    {

                                        break;
                                    }
                                case "DX":
                                    {
                                        DX.Content = CX.Content.ToString().ToUpper();
                                        break;
                                    }
                            }

                            break;
                        }
                    case "DX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        AX.Content = DX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "BX":
                                    {
                                        BX.Content = DX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "CX":
                                    {
                                        CX.Content = DX.Content.ToString().ToUpper();
                                        break;
                                    }
                                case "DX":
                                    {

                                        break;
                                    }
                            }

                            break;
                        }
                }
            }

            if (regmem.IsChecked == true)
            {
                if (index.IsChecked == true)
                {
                    if (si.IsChecked == true)
                    {
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_si + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_si + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_si + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_si + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                    if (di.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_di + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_di + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_di + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_di + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                }
                if (@base.IsChecked == true)
                {
                    if (bx.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bx + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_bx + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_bx + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_bx + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                    if (bp.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bp + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_bp + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_bp + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_bp + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                }
                if (indexbase.IsChecked == true)
                {
                    if (bx.IsChecked == true && si.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bx + _si + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_bx + _si + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_bx + _si + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_bx + _si + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                    if (di.IsChecked == true && bx.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_di + _bx + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_di + _bx + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_di + _bx + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_di + _bx + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                    if (bp.IsChecked == true && si.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bp + _si + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_bp + _si + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_bp + _si + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_bp + _si + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                    if (di.IsChecked == true && bp.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_di + _bp + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                break;

                            case "BX":
                                _memory[_di + _bp + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                break;

                            case "CX":
                                _memory[_di + _bp + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                break;

                            case "DX":
                                _memory[_di + _bp + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                break;
                        }
                    }
                }
            }

            if (memreg.IsChecked == true)
            {

                if (index.IsChecked == true)
                {
                    if (si.IsChecked == true)
                    {
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_si + _disp + 1] + _memory[_si + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_si + _disp + 1] + _memory[_si + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_si + _disp + 1] + _memory[_si + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_si + _disp + 1] + _memory[_si + _disp];
                                break;
                        }
                    }
                    if (di.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_di + _disp + 1] + _memory[_di + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_di + _disp + 1] + _memory[_di + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_di + _disp + 1] + _memory[_di + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_di + _disp + 1] + _memory[_di + _disp];
                                break;
                        }
                    }
                }
                if (@base.IsChecked == true)
                {
                    if (bx.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_bx + _disp + 1] + _memory[_bx + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_bx + _disp + 1] + _memory[_bx + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_bx + _disp + 1] + _memory[_bx + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_bx + _disp + 1] + _memory[_bx + _disp];
                                break;
                        }
                    }
                    if (bp.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_bp + _disp + 1] + _memory[_bp + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_bp + _disp + 1] + _memory[_bp + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_bp + _disp + 1] + _memory[_bp + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_bp + _disp + 1] + _memory[_bp + _disp];
                                break;
                        }
                    }
                }
                if (indexbase.IsChecked == true)
                {
                    if (si.IsChecked == true && bx.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_bx + _si + _disp + 1] + _memory[_bx + _si + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_bx + _si + _disp + 1] + _memory[_bx + _si + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_bx + _si + _disp + 1] + _memory[_bx + _si + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_bx + _si + _disp + 1] + _memory[_bx + _si + _disp];
                                break;
                        }
                    }
                    if (bx.IsChecked == true && di.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_bx + _di + _disp + 1] + _memory[_bx + _di + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_bx + _di + _disp + 1] + _memory[_bx + _di + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_bx + _di + _disp + 1] + _memory[_bx + _di + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_bx + _di + _disp + 1] + _memory[_bx + _di + _disp];
                                break;
                        }
                    }
                    if (si.IsChecked == true && bp.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_bp + _si + _disp + 1] + _memory[_bp + _si + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_bp + _si + _disp + 1] + _memory[_bp + _si + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_bp + _si + _disp + 1] + _memory[_bp + _si + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_bp + _si + _disp + 1] + _memory[_bp + _si + _disp];
                                break;
                        }
                    }
                    if (bp.IsChecked == true && di.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        switch (cb_To.Text)
                        {
                            case "AX":
                                AX.Content = _memory[_bp + _di + _disp + 1] + _memory[_bp + _di + _disp];
                                break;
                            case "BX":
                                BX.Content = _memory[_bp + _di + _disp + 1] + _memory[_bp + _di + _disp];
                                break;
                            case "CX":
                                CX.Content = _memory[_bp + _di + _disp + 1] + _memory[_bp + _di + _disp];
                                break;
                            case "DX":
                                DX.Content = _memory[_bp + _di + _disp + 1] + _memory[_bp + _di + _disp];
                                break;
                        }
                    }
                }
            }

        }

        private void Swap(ref Label x, ref Label y)
        {
            string temp = x.Content.ToString();
            x.Content = y.Content;
            y.Content = temp;
        }

        private void btn_xchn_Click(object sender, RoutedEventArgs e)
        {
            if (regreg.IsChecked == true)
            {
                switch (cb_From.Text)
                {
                    case "AX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        break;
                                    }
                                case "BX":
                                    {
                                        Swap(ref AX, ref BX);
                                        break;
                                    }
                                case "CX":
                                    {
                                        Swap(ref AX, ref CX);
                                        break;
                                    }
                                case "DX":
                                    {
                                        Swap(ref AX, ref DX);
                                        break;
                                    }
                            }

                            break;
                        }
                    case "BX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        Swap(ref BX, ref AX);
                                        break;
                                    }
                                case "BX":
                                    {

                                        break;
                                    }
                                case "CX":
                                    {
                                        Swap(ref BX, ref CX);
                                        break;
                                    }
                                case "DX":
                                    {
                                        Swap(ref BX, ref DX);
                                        break;
                                    }
                            }

                            break;
                        }

                    case "CX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        Swap(ref CX, ref AX);

                                        break;
                                    }
                                case "BX":
                                    {
                                        Swap(ref CX, ref BX);
                                        break;
                                    }
                                case "CX":
                                    {

                                        break;
                                    }
                                case "DX":
                                    {
                                        Swap(ref CX, ref DX);
                                        break;
                                    }
                            }

                            break;
                        }
                    case "DX":
                        {
                            switch (cb_To.Text)
                            {
                                case "AX":
                                    {
                                        Swap(ref DX, ref AX);
                                        break;
                                    }
                                case "BX":
                                    {
                                        Swap(ref DX, ref BX);
                                        break;
                                    }
                                case "CX":
                                    {
                                        Swap(ref DX, ref CX);
                                        break;
                                    }
                                case "DX":
                                    {

                                        break;
                                    }
                            }

                            break;
                        }
                }
            }

            if (regmem.IsChecked == true || memreg.IsChecked == true)
            {
                if (index.IsChecked == true)
                {
                    if (si.IsChecked == true)
                    {
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_si + _disp + 1] + _memory[_si + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_si + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_si + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_si + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_si + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_si + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                    if (di.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_di + _disp + 1] + _memory[_di + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_di + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_di + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_di + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_di + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_di + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                }
                if (@base.IsChecked == true)
                {
                    if (bx.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_bx + _disp + 1] + _memory[_bx + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bx + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_bx + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_bx + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_bx + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                    if (bp.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_bp + _disp + 1] + _memory[_bp + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bp + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_bp + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_bp + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_bp + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                }
                if (indexbase.IsChecked == true)
                {
                    if (bx.IsChecked == true && si.IsChecked == true)
                    {
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_bx + _si + _disp + 1] + _memory[_bx + _si + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bx + _si + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_bx + _si + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_bx + _si + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_bx + _si + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bx + _si + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                    if (di.IsChecked == true && bx.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _bx = int.Parse(BX.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_bx + _di + _disp + 1] + _memory[_bx + _di + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_di + _bx + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_di + _bx + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_di + _bx + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_di + _bx + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bx + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                    if (bp.IsChecked == true && si.IsChecked == true)
                    {
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _si = int.Parse(SI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_bp + _si + _disp + 1] + _memory[_bp + _si + _disp];
                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_bp + _si + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_bp + _si + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_bp + _si + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_bp + _si + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_bp + _si + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                    if (di.IsChecked == true && bp.IsChecked == true)
                    {
                        int _di = int.Parse(DI.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _bp = int.Parse(BP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        int _disp = int.Parse(DISP.Content.ToString(), System.Globalization.NumberStyles.HexNumber);
                        var temp = _memory[_bp + _di + _disp + 1] + _memory[_bp + _di + _disp];

                        switch (cb_From.Text)
                        {
                            case "AX":
                                _memory[_di + _bp + _disp] = AX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = AX.Content.ToString().Substring(0, 2);
                                AX.Content = temp;
                                break;

                            case "BX":
                                _memory[_di + _bp + _disp] = BX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = BX.Content.ToString().Substring(0, 2);
                                BX.Content = temp;
                                break;

                            case "CX":
                                _memory[_di + _bp + _disp] = CX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = CX.Content.ToString().Substring(0, 2);
                                CX.Content = temp;
                                break;

                            case "DX":
                                _memory[_di + _bp + _disp] = DX.Content.ToString().Substring(2, 2);
                                _memory[_di + _bp + _disp + 1] = DX.Content.ToString().Substring(0, 2);
                                DX.Content = temp;
                                break;
                        }
                    }
                }
            }
        }

        private void tb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9A-Fa-f]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            AX.Content = BX.Content = CX.Content = DX.Content = SI.Content = DI.Content = BX.Content = BP.Content = SP.Content = DISP.Content = "0000";
        }

        private void btn_random_Click(object sender, RoutedEventArgs e)
        {
            AX.Content = RandomString();
            BX.Content = RandomString();
            CX.Content = RandomString();
            DX.Content = RandomString();
            SI.Content = RandomString();
            DI.Content = RandomString();
            BX.Content = RandomString();
            BP.Content = RandomString();
        }

        private static string RandomString()
        {
            const string chars = "ABCDEF0123456789";
            return new string(Enumerable.Repeat(chars, 4)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btn_push_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_From.Text)
            {
                case "AX":
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)] = AX.Content.ToString().Substring(2, 2);
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] = AX.Content.ToString().Substring(0, 2);
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 2).ToString("X4");
                    break;
                case "BX":
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)] = BX.Content.ToString().Substring(2, 2);
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] = BX.Content.ToString().Substring(0, 2);
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 2).ToString("X4");
                    break;
                case "CX":
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)] = CX.Content.ToString().Substring(2, 2);
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] = CX.Content.ToString().Substring(0, 2);
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 2).ToString("X4");
                    break;
                case "DX":
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)] = DX.Content.ToString().Substring(2, 2);
                    _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] = DX.Content.ToString().Substring(0, 2);
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 2).ToString("X4");
                    break;
            }
        }

        private void btn_pop_Click(object sender, RoutedEventArgs e)
        {

            if (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) == 0) return;
            switch (cb_To.Text)
            {
                case "AX":
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) - 2).ToString("X4");
                    AX.Content = _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] + _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)];                    
                    break;
                case "BX":
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) - 2).ToString("X4");
                    BX.Content = _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] + _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)];
                    break;
                case "CX":
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) - 2).ToString("X4");
                    CX.Content = _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] + _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)];
                    break;
                case "DX":
                    SP.Content = (int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) - 2).ToString("X4");
                    DX.Content = _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber) + 1] + _stack[int.Parse(SP.Content.ToString(), System.Globalization.NumberStyles.HexNumber)];
                    break;


            }
        }
    }

}