using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace すらっく
{
  /// <summary>
  /// MainWindow.xaml の相互作用ロジック
  /// </summary>
  public partial class MainWindow : Window
  {
    private Dictionary<char, string> dict = new Dictionary<char, string>();

    public MainWindow()
    {
      InitializeComponent();

      dict['あ'] = "a";
      dict['い'] = "i";
      dict['う'] = "u";
      dict['え'] = "e";
      dict['お'] = "o";
      dict['か'] = "ka";
      dict['き'] = "ki";
      dict['く'] = "ku";
      dict['け'] = "ke";
      dict['こ'] = "ko";
      dict['さ'] = "sa";
      dict['し'] = "si";
      dict['す'] = "su";
      dict['せ'] = "se";
      dict['そ'] = "so";
      dict['た'] = "ta";
      dict['ち'] = "ti";
      dict['つ'] = "tu";
      dict['て'] = "te";
      dict['と'] = "to";
      dict['な'] = "na";
      dict['に'] = "ni";
      dict['ぬ'] = "nu";
      dict['ね'] = "ne";
      dict['の'] = "no";
      dict['は'] = "ha";
      dict['ひ'] = "hi";
      dict['ふ'] = "hu";
      dict['へ'] = "he";
      dict['ほ'] = "ho";
      dict['ま'] = "ma";
      dict['み'] = "mi";
      dict['む'] = "mu";
      dict['め'] = "me";
      dict['も'] = "mo";
      dict['や'] = "ya";
      dict['ゆ'] = "yu";
      dict['よ'] = "yo";
      dict['ら'] = "ra";
      dict['り'] = "ri";
      dict['る'] = "ru";
      dict['れ'] = "re";
      dict['ろ'] = "ro";
      dict['わ'] = "wa";
      dict['を'] = "wo";
      dict['ん'] = "nn";
      dict['が'] = "ga";
      dict['ぎ'] = "gi";
      dict['ぐ'] = "gu";
      dict['げ'] = "ge";
      dict['ご'] = "go";
      dict['ざ'] = "za";
      dict['じ'] = "zi";
      dict['ず'] = "zu";
      dict['ぜ'] = "ze";
      dict['ぞ'] = "zo";
      dict['だ'] = "da";
      dict['ぢ'] = "di";
      dict['づ'] = "du";
      dict['で'] = "de";
      dict['ど'] = "do";
      dict['ば'] = "ba";
      dict['び'] = "bi";
      dict['ぶ'] = "bu";
      dict['べ'] = "be";
      dict['ぼ'] = "bo";
      dict['ぱ'] = "pa";
      dict['ぴ'] = "pi";
      dict['ぷ'] = "pu";
      dict['ぺ'] = "pe";
      dict['ぽ'] = "po";
      dict['ぁ'] = "xa";
      dict['ぃ'] = "xi";
      dict['ぅ'] = "xu";
      dict['ぇ'] = "xe";
      dict['ぉ'] = "xo";
      dict['っ'] = "xtu";
      dict['ゃ'] = "xya";
      dict['ゅ'] = "xyu";
      dict['ょ'] = "xyo";
      dict['ゎ'] = "xwa";
      dict['！'] = "bikun";
      dict['？'] = "hatena";
      dict['ー'] = "-";
      dict['\r'] = "\r";
      dict['\n'] = "\n";
    }

    private void EncodeButton_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        EncodedText.Text = string.Empty;
        StringBuilder builder = new StringBuilder();
        foreach(var c in PreEncodingText.Text)
        {
          string buf;
          if(dict.TryGetValue(c, out buf))
          {
            switch(c)
            {
              case '\r':
                break;

              case '\n':
                builder.Append(Environment.NewLine);
                break;

              default:
                builder.Append(string.Format(":c_{0}:", buf));
                break;
            }
          }
          else
            throw new Exception("サポートされていない文字が入力されています");
        }
        EncodedText.Text = builder.ToString();
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
        PreEncodingText.Text = string.Empty;
        EncodedText.Text = string.Empty;
      }
    }
  }
}
