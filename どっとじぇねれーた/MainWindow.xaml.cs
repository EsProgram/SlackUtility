using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace どっとじぇねれーた
{
  /// <summary>
  /// MainWindow.xaml の相互作用ロジック
  /// </summary>
  public partial class MainWindow : Window
  {
    private Bitmap _bmp = null;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void Image_Drop(object sender, DragEventArgs e)
    {
      var paths = e.Data.GetData(DataFormats.FileDrop) as string[];
      if(paths != null)
      {
        try
        {
          string path = paths.First();
          Uri uri = new Uri(path);

          _bmp = new Bitmap(path);
          if(_bmp.Width * _bmp.Height > 400)
            throw new NotSupportedException("画像サイズは　'縦*横 < 400px'　まで指定可能です");
          BitmapImage img = new BitmapImage(uri);
          ConvertImage.Source = img;

          HelpLabel.Opacity = img == null ? 100 : 0;
        }
        catch(NotSupportedException ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
    }

    private void Convert_Click(object sender, RoutedEventArgs e)
    {
      if(_bmp == null)
      {
        MessageBox.Show("画像をドラッグ＆ドロップしてください");
        return;
      }

      ResultText.Text = string.Empty;

      StringBuilder builder = new StringBuilder();
      for(int y = 0; y < _bmp.Height; ++y)
      {
        for(int x = 0; x < _bmp.Width; ++x)
          builder.Append(SelectStampName(ConvertPixel(x, y)));
        builder.Append(Environment.NewLine);
      }

      ResultText.Text = builder.ToString();
      Clipboard.SetText(ResultText.Text);
    }

    private int ConvertPixel(int x, int y)
    {
      var color = _bmp.GetPixel(x, y);
      float f = (2 * color.R + 4 * color.G + color.B) / 7;
      return (int)Math.Floor(f);
    }

    private string SelectStampName(int f)
    {
      int mod = f % 17;
      int result;
      if(mod > 8)
        result = f + 17 - mod;
      else
        result = f - mod;

      return string.Format(":b_{0}:", result.ToString().PadLeft(3, '0'));
    }

    //public Color GetPixel(int x, int y)
    //{
    //  if(_img == null)
    //    return _bmp.GetPixel(x, y);

    //  IntPtr adr = _img.Scan0;
    //  int pos = x * 3 + _img.Stride * y;
    //  byte b = System.Runtime.InteropServices.Marshal.ReadByte(adr, pos + 0);
    //  byte g = System.Runtime.InteropServices.Marshal.ReadByte(adr, pos + 1);
    //  byte r = System.Runtime.InteropServices.Marshal.ReadByte(adr, pos + 2);
    //  return Color.FromArgb(r, g, b);
    //}
  }
}
