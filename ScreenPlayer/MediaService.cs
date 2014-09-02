using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ScreenPlayer
{
    [ServiceContract]
    public interface IMediaService
    {
        [OperationContract]
        bool Play(string content);

        [OperationContract]
        bool PlayByFont(string content, int fontSizeIndex, int fontColorIndex);
    }

    public class MediaService : IMediaService
    {
        public bool Play(string content)
        {
            MainWindow mainWindow = MainWindow.GetInstance();
            return mainWindow.Play(content);
        }

        public bool PlayByFont(string content, int fontSizeIndex, int fontColorIndex)
        {
            MainWindow mainWindow = MainWindow.GetInstance();
            return mainWindow.Play(content, fontSizeIndex, fontColorIndex);
        }
    }
}
