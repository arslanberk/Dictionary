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
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Threading;

namespace Dictionary.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class g_result : UserControl
    {
        ObservableCollection<Rectangle> rec;
        DispatcherTimer timer;
        public g_result()
        {
            try { 
            InitializeComponent();
            ImageBrush ib = new ImageBrush();
            string path = string.Format("{0}\\Images\\graph_background.png", AppDomain.CurrentDomain.BaseDirectory);
            ib.ImageSource = new BitmapImage(new Uri(path, UriKind.Relative));
            
            canvas.Background = ib;
            rec = new ObservableCollection<Rectangle>();
             timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
            draw();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
         
    
        }
 
        private void timer_tick(object sender, EventArgs e)
        {
            String dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dir += "\\ArslanSoftware\\";
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,(int)canvas.RenderSize.Height,96d, 94.5d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas);

            var crop = new CroppedBitmap(rtb, new Int32Rect());

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(crop));

            BitmapEncoder jpgencoder = new JpegBitmapEncoder();
            jpgencoder.Frames.Add(BitmapFrame.Create(crop));
            using (var fs = System.IO.File.OpenWrite(dir+"Images\\graph.png"))
            {
                pngEncoder.Save(fs);
            }
            using (var fs = System.IO.File.OpenWrite(dir+"Images\\graph.jpg"))
            {

                jpgencoder.Save(fs);
            }
            CommandManager.InvalidateRequerySuggested();
            rec.Clear();
           
            canvas.Children.Clear();
            draw();
        }
        public void draw()
        {
            try { 
            //drawing coordinates
            Line y = new Line();
            y.Y1 = 0;
            y.Y2 = 450;
            y.X1 = 30;
            y.X2 = 30;
            y.Stroke = new SolidColorBrush(Colors.Black);
            y.StrokeThickness = 1;
            Line x = new Line();
            x.Y1 = canvas.Height-30;
            x.Y2 = canvas.Height-30;
            x.X1 = 0;
            x.X2 = 760;
            x.Stroke = new SolidColorBrush(Colors.Black);
            x.StrokeThickness = 1;
            
            canvas.Children.Add(y);
            canvas.Children.Add(x);

            success s = new success();
            s.reader();
            int count = s.succes.Length;
            double interval=(double)(canvas.Width/(count+1));
            for (int i = 0; i < count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text =s.time[i];
                textBlock.Foreground = new SolidColorBrush(Colors.Black);
                textBlock.FontSize = 10;
                Canvas.SetLeft(textBlock, ((i * interval - 1) + ( interval-10)));
                if (i % 2 == 0)
                {
                    Canvas.SetTop(textBlock, ((canvas.Height - 30) + (5)));
                }
                else { Canvas.SetTop(textBlock, ((canvas.Height - 30) + (15))); }
                canvas.Children.Add(textBlock);
               

                Line q = new Line();
                q.Y1 = (canvas.Height - 30) - (4);
                q.Y2 = (canvas.Height - 30) + (4);
                q.X1 = (i*interval-1)+(30+interval);
                q.X2 = (i*interval-1)+(30+interval);
                q.Stroke = new SolidColorBrush(Colors.Black);
                x.StrokeThickness = 1;
                canvas.Children.Add(q);            
            
            }
            for (int i = 0; i < 10; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = ((i+1)*10).ToString();
                textBlock.Foreground = new SolidColorBrush(Colors.Black);
                textBlock.FontSize = 10;
                Canvas.SetLeft(textBlock, (10));
                Canvas.SetBottom(textBlock, ((i*27)+50)); 
                canvas.Children.Add(textBlock);

                Line q = new Line();
                q.Y1 = (canvas.Height - ( (((i+1) * 27)+30))) ;
                q.Y2 = (canvas.Height - ((((i+1) * 27)+30))) ;
                q.X1 = 30-4;
                q.X2 = 30 + 4;
                q.Stroke = new SolidColorBrush(Colors.Black);
                x.StrokeThickness = 1;
                canvas.Children.Add(q);

            }
            
            for (int i = 0; i < count; i++)
            {
             
                  Rectangle r = new Rectangle();
                r.Stroke = new SolidColorBrush(Colors.Black);
                r.Fill = new SolidColorBrush(Colors.Black);
                r.Width = interval-2;
                r.Height =(((((s.succes[i])/10)) * 27));
                r.Tag=s.succes[i];
                r.Uid =( (i * interval - 4.5) + (30 + (interval / 2))).ToString();
                rec.Add(r);
                Canvas.SetLeft(r, (i * interval - 4.5) + (30 + (interval/2)));
              Canvas.SetBottom(r, ((30)));
                canvas.Children.Add(r);

            }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
   
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            try { 
            foreach (Rectangle r in rec)
            {
                if (r.IsMouseOver == true)
                {
                    r.Fill = new SolidColorBrush(Colors.CadetBlue);
                    TextBlock tb = new TextBlock();
                    tb.Text = " " + r.Tag.ToString() + " % ";
                    tb.FontSize = 17;
                    tb.Background = new SolidColorBrush(Colors.Gold);
                    tb.Foreground = new SolidColorBrush(Colors.Black);
                    Canvas.SetBottom(tb, (r.Height/2+20));
                    Canvas.SetLeft(tb,double.Parse (r.Uid));
                    canvas.Children.Add(tb);
                    //  MessageBox.Show(r.Tag.ToString());
                }
            }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void canvas_MouseEnter(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        private void canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            timer.Stop();
        }



    }
}
