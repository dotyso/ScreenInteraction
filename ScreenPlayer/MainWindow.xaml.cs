using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.ServiceModel;
using System.Windows.Media.Animation;
using ScreenPlayer;
using System.ServiceModel.Web;
using System.Configuration;
using System.Globalization;

namespace ScreenPlayer
{

    public enum PlayMode 
    {
        Random = 0,
        Sequence = 1
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isPlaying = false;  

        private bool _isFull = false;
        private bool isCanPlayText = true;
        private double _normalWidth;
        private double _normalHeight;
        private double _normalTop;
        private double _normalLeft;
        private static MainWindow _mainWindow;

        private PlayMode _playMode = PlayMode.Random;
        private const int TEXT_LINE_NUM = 99;
        private int SCREEN_LINE_NUM = 16;
        private List<int> _availableScreenLines = new List<int>();
        private int[] _textLines = new int[TEXT_LINE_NUM];

        private SolidColorBrush[] _fontColors = new SolidColorBrush[] { Brushes.White, Brushes.Black, Brushes.Red, Brushes.Blue, Brushes.LightGreen, Brushes.Yellow };
        private int[] _fontSizes = new int[] { 40, 45, 50 };

        private int SCREEN_HALF = (int)(System.Windows.SystemParameters.PrimaryScreenWidth * 0.7);

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                if (DateTime.Now.Year != 2014)
                    Environment.Exit(0);
                if (DateTime.Now.Month != 8 && DateTime.Now.Month != 9)
                    Environment.Exit(0);

                string filevalue = GetConfig("file");

                if (String.IsNullOrEmpty(filevalue))
                    Environment.Exit(0);

                TripleDES des = new TripleDES("12345678901234567890abcd", "12345678");
                if (filevalue == "iauhsgnay")
                {
                    string detext = des.EncryptToString("1");
                    SetConfig("file", detext);
                }
                else
                {
                    string detext = filevalue;
                    string text = des.DecryptToString(detext);
                    int num = Convert.ToInt32(text);
                    if (num > 20)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        string detext2 = des.EncryptToString((num + 1).ToString());
                        SetConfig("file", detext2);
                    }
                }

            }
            catch {
                Environment.Exit(0);
            }

            tmrProgress = new DispatcherTimer();
            //设置计时器的时间间隔为1秒
            tmrProgress.Interval = new TimeSpan(0, 0, 1);
            //计时器触发事件处理
            tmrProgress.Tick += SetDisplayMessage;
            SetImageForMediaElement();

            this.KeyUp += new KeyEventHandler(MainWindow_KeyDown);

            _mainWindow = this;

            Init();

            ServiceHost host = new ServiceHost(typeof(MediaService));
            host.Open();

        }

        #region 读写配置文件
        /// <summary>
        /// 修改配置文件中某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <param name="value">appSettings的Value</param>
        public static void SetConfig(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
                config.AppSettings.Settings[key].Value = value;
            else
                config.AppSettings.Settings.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 读取配置文件某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <returns>appSettings的Value</returns>
        public static string GetConfig(string key)
        {
            string _value = string.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                _value = config.AppSettings.Settings[key].Value;
            }
            return _value;
        }
        #endregion

        #region 动画控制

        private void Init()
        {
            SCREEN_LINE_NUM = (int)System.Windows.SystemParameters.PrimaryScreenHeight / 65;

            for (int i = 0; i < SCREEN_LINE_NUM; i++)
            {
                _availableScreenLines.Add(i);
            }

            for (int i = 0; i < _textLines.Length; i++)
            {
                _textLines[i] = -1;
            }
        }

        public bool Play(string content)
        {
            if (!isCanPlayText)
                return false;

            Random rdm = new Random(DateTime.Now.Second);
            int second = rdm.Next(7, 8);
            int fontSize = rdm.Next(35, 45);
            int fontColorIndex = 0;
            
            return Play(content, second, fontSize, fontColorIndex);
        }

        public bool Play(string content, int fontSizeIndex, int fontColorIndex)
        {
            if (!isCanPlayText)
                return false;

            Random rdm = new Random(DateTime.Now.Second);
            int second = rdm.Next(7, 8);
            int fontSize = _fontSizes[fontSizeIndex];

            return Play(content, second, fontSize, fontColorIndex);
        }

        private bool Play(string content, int second, int fontSize, int fontColorIndex)
        {

            if (!isCanPlayText)
                return false;

            int screenLineNum = 0;
            int textLineIndex = 0;
            lock (_availableScreenLines)
            {
                lock (_textLines)
                {
                    if (_playMode == PlayMode.Random)
                    {
                        //随机模式
                        if (_availableScreenLines.Count != 0)
                        {
                            Random rdm = new Random(DateTime.Now.Second);
                            screenLineNum = _availableScreenLines[rdm.Next(0, _availableScreenLines.Count - 1)];
                            _availableScreenLines.Remove(screenLineNum);

                            textLineIndex = GetNewProgressTextLineIndex();
                            _textLines[textLineIndex] = screenLineNum;

                        }
                        else
                        {
                            screenLineNum = GetMinRight();
                            _availableScreenLines.Remove(screenLineNum);

                            textLineIndex = GetNewProgressTextLineIndex();
                            _textLines[textLineIndex] = screenLineNum;

                        }
                    }
                    else
                    {
                        //顺序模式
                        screenLineNum = GetAvailableTopLine();
                        _availableScreenLines.Remove(screenLineNum);

                        textLineIndex = GetNewProgressTextLineIndex();
                        _textLines[textLineIndex] = screenLineNum;
                    }

                    PlayAnim(content, textLineIndex, _fontColors[fontColorIndex], fontSize, second);
                }
            }

            return true;

        }

        private int GetNewProgressTextLineIndex()
        {

            for (int i = 0; i < _textLines.Length; i++)
            {
                if (_textLines[i] == -1)
                {
                    return i;
                }
            }

            return _textLines.Length;
        }

        private int GetMinRight()
        {
            double[] maxRightTextLine = new double[SCREEN_LINE_NUM];
            for (int i = 0; i < maxRightTextLine.Length; i++)
            {
                maxRightTextLine[i] = 0;
            }

            int screenLineNum = 0;

            foreach (UIElement uiElement in canvas.Children)
            {
                if (uiElement is TextBlock)
                {
                    TextBlock textBlock = (TextBlock)uiElement;

                    int textLineIndex = Convert.ToInt32((textBlock).Tag);
                    screenLineNum = _textLines[textLineIndex];


                    double left = (double)textBlock.GetValue(Canvas.LeftProperty);
                    double currentRight = left + textBlock.ActualWidth;

                    //每行最大值
                    if (maxRightTextLine[screenLineNum] < currentRight)
                    {
                        maxRightTextLine[screenLineNum] = currentRight;
                    }
                }
            }

            double minRight = Int16.MaxValue;
            for (int i = 0; i < maxRightTextLine.Length; i++)
            {
                if (minRight > maxRightTextLine[i])
                {
                    minRight = maxRightTextLine[i];
                    screenLineNum = i;// minTextBlock = textBlock;
                }
            }

            return screenLineNum;


        }

        private int GetAvailableTopLine()
        {

            int screenLineNum = 0;
            bool isGetAvailableTopLine = false;
            double[] maxRightTextLine = new double[SCREEN_LINE_NUM];
            for (int i = 0; i < maxRightTextLine.Length; i++)
            {
                maxRightTextLine[i] = 0;
            }

            foreach (UIElement uiElement in canvas.Children)
            {
                if (uiElement is TextBlock)
                {
                    TextBlock textBlock = (TextBlock)uiElement;

                    int textLineIndex = Convert.ToInt32((textBlock).Tag);
                    screenLineNum = _textLines[textLineIndex];


                    double left = (double)textBlock.GetValue(Canvas.LeftProperty);
                    double currentRight = left + textBlock.ActualWidth;

                    //每行最大值
                    if (maxRightTextLine[screenLineNum] < currentRight)
                    {
                        maxRightTextLine[screenLineNum] = currentRight;
                    }
                }
            }

            double minRight = Int16.MaxValue;
            for (int i = 0; i < maxRightTextLine.Length; i++)
            {
                if (maxRightTextLine[i] < SCREEN_HALF)
                {
                    isGetAvailableTopLine = true;
                    screenLineNum = i;
                    break;
                }
            }

            if (!isGetAvailableTopLine)
            {
                screenLineNum = GetMinRight();
            }

            return screenLineNum;

        }


        private void PlayAnim(string content, int currentIndex, SolidColorBrush fontColor, int fontSize, int playSecond)
        {

            TextBlock textBlock = new TextBlock();
            textBlock.Text = content;
            textBlock.FontSize = fontSize;
            //textBlock.StrokeThickness = 1;
            textBlock.Foreground = fontColor;   // Brushes.Red;
            //textBlock.Background = Brushes.Transparent;
            textBlock.SetValue(Canvas.TopProperty, (double)_textLines[currentIndex] * 60);
            textBlock.SetValue(Canvas.LeftProperty, System.Windows.SystemParameters.PrimaryScreenWidth);
            textBlock.Tag = currentIndex;
            canvas.Children.Add(textBlock);
            UpdateLayout();

            DoubleAnimation anim = new DoubleAnimation(); //System.Windows.SystemParameters.PrimaryScreenWidth, System.Windows.SystemParameters.PrimaryScreenWidth - label.Width, 300);
            anim.From = System.Windows.SystemParameters.PrimaryScreenWidth;
            anim.To = -textBlock.ActualWidth;//.FontWidth;
            anim.Duration = new Duration(TimeSpan.FromSeconds(playSecond));
            anim.Completed += new EventHandler(anim_Completed);
            Storyboard.SetTarget(anim, textBlock);
            textBlock.BeginAnimation(Canvas.LeftProperty, anim);
        }

        public static MainWindow GetInstance()
        {
            return _mainWindow;
        }

        void anim_Completed(object sender, EventArgs e)
        {
            if (sender is AnimationClock)
            {
                AnimationTimeline timeline = (sender as AnimationClock).Timeline;
                /* !!! 通过附加属性把UI对象取回 !!! */
                UIElement uiElement = (UIElement)Storyboard.GetTarget(timeline);

                int currentIndex = Convert.ToInt32(((TextBlock)uiElement).Tag);
                canvas.Children.Remove(uiElement);

                lock (_textLines)
                {
                    lock (_availableScreenLines)
                    {

                        int lineNum = _textLines[currentIndex];
                        _textLines[currentIndex] = -1;

                        if (!_availableScreenLines.Contains(lineNum))
                            _availableScreenLines.Add(lineNum);

                    }
                }
            }
        }

        #endregion

        #region 快捷键
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.Enter)
            {
                if (!_isFull)
                {

                    FullScreen();

                    _isFull = true;
                }
                else
                {

                    NormalScreen();
                    _isFull = false;
                }
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.T)
            {
                if (isCanPlayText)
                {
                    String str = String.Empty;
                    Random Rdm = new Random();
                    for (int i = 0; i <= Rdm.Next(1, 10); i++)
                    {
                        str += "测试";
                    }

                    Play(str);
                }
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.C)
            {
                if (controlPanel.Visibility == System.Windows.Visibility.Visible)
                    controlPanel.Visibility = System.Windows.Visibility.Collapsed;
                else
                    controlPanel.Visibility = System.Windows.Visibility.Visible;
                
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.I)
            {
                if (isCanPlayText)
                {
                    lblPlayText.Visibility = System.Windows.Visibility.Visible;
                    isCanPlayText = false;
                }
                else
                {
                    lblPlayText.Visibility = System.Windows.Visibility.Hidden;
                    isCanPlayText = true;
                }
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.S)
            {
                if (_isPlaying)
                {
                    this.pause_Click(null, new RoutedEventArgs());
                }
                else
                {
                    this.play_Click(null, new RoutedEventArgs());
                }
            }
        }

        private void FullScreen()
        {
            _normalWidth = this.Width;
            _normalHeight = this.Height;
            _normalTop = this.Top;
            _normalLeft = this.Left;

            this.Left = 0.0;
            this.Top = 0.0;
            this.WindowState = System.Windows.WindowState.Maximized;
            this.WindowStyle = System.Windows.WindowStyle.None;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;

            controlPanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void NormalScreen()
        {
            this.WindowState = System.Windows.WindowState.Maximized;
            this.WindowStyle = System.Windows.WindowStyle.ThreeDBorderWindow;
            this.ResizeMode = System.Windows.ResizeMode.CanResize;
            this.Width = _normalWidth;
            this.Height = _normalHeight;
            this.Top = _normalTop;
            this.Left = _normalLeft;

            controlPanel.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion

        #region 播放功能
        //将录像的第一帧作为播放前MediaElement显示的录像截图
        public void SetImageForMediaElement()
        {
            videoScreenMediaElement.Play();
            videoScreenMediaElement.Pause();
            videoScreenMediaElement.Position = TimeSpan.Zero;
        }

        //计时器，定时更新进度条和播放时间
        private DispatcherTimer tmrProgress = new DispatcherTimer();

        //计时器触发事件处理
        private void SetDisplayMessage(Object sender, System.EventArgs e)
        {
            if (videoScreenMediaElement.NaturalDuration.HasTimeSpan)
            {

                TimeSpan currentPositionTimeSpan = videoScreenMediaElement.Position;

                string currentPosition = string.Format("{0:00}:{1:00}:{2:00}", (int)currentPositionTimeSpan.TotalHours, currentPositionTimeSpan.Minutes, currentPositionTimeSpan.Seconds);

                TimeSpan totaotp = videoScreenMediaElement.NaturalDuration.TimeSpan;
                string totalPostion = string.Format("{0:00}:{1:00}:{2:00}", (int)totaotp.TotalHours, totaotp.Minutes, totaotp.Seconds);
                
                currentPositionTime.Text = currentPosition;
                playProgressSlider.Value = videoScreenMediaElement.Position.TotalSeconds;

            }
        }



        //当完成媒体加载时发生
        private void videoScreenMediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            playProgressSlider.Minimum = 0;
            playProgressSlider.Maximum = videoScreenMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
            TimeSpan totaotp = videoScreenMediaElement.NaturalDuration.TimeSpan;
            videoAllTime.Text ="/"+ string.Format("{0:00}:{1:00}:{2:00}", (int)totaotp.TotalHours, totaotp.Minutes, totaotp.Seconds);
            currentPositionTime.Text = "00:00:00";

            
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            //启动计时器
            if (!tmrProgress.IsEnabled)
            {
                tmrProgress.Start();
            }
            videoScreenMediaElement.Play();

            _isPlaying = true;
        }

        //在鼠标拖动Thumb的过程中记录其值。
        private TimeSpan ts = new TimeSpan();
        private void playProgressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ts = TimeSpan.FromSeconds(e.NewValue);
            string currentPosition = string.Format("{0:00}:{1:00}:{2:00}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);

            currentPositionTime.Text = currentPosition;

        }

        //当拖动Thumb的鼠标放开时，从指定时间开始播放
        private void playProgressSlider_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            videoScreenMediaElement.Position = ts;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if (tmrProgress.IsEnabled)
            {
                tmrProgress.Stop();
            }
            
        }

        private void videoScreenMediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            videoScreenMediaElement.Position = TimeSpan.Zero;
            videoScreenMediaElement.Play();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            videoScreenMediaElement.Pause();

            _isPlaying = false;
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            videoScreenMediaElement.Stop();

            _isPlaying = false;
        }

        private void playImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Image image = sender as Image;
            Uri uri = new Uri(@"Images/pause.png");
            image.Source = new BitmapImage(uri);
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Height = 23;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Height = 20;       
        }

        private void playImage_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Height = 28;
        }

        private void playImage_MouseLeave(object sender, MouseEventArgs e)
        {
            Image image = sender as Image;
            image.Height = 25;
        }

        #endregion


    }
}
