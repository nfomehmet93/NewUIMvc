using NewsUI.Bussines.Abstract;
using NewsUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NewsUI.Business.Concrete
{
    public class RequestManager : IRequestService
    {
        public ResponseNewsModel GetNews(string uri)
        {
            try
            {
                uri = string.Format("{0}/{1}", uri,"contents");

                WebRequest request = WebRequest.Create(uri);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                var jsonString = reader.ReadToEnd();

                reader.Close();
                response.Close();

                var news = JsonConvert.DeserializeObject<ResponseNewsModel>(jsonString);
                return news;
            }

            catch (Exception ex)
            {
                return new ResponseNewsModel() { IsSuccess = false, Message = "Beklenmedik bir hata ile karşılaşıldı." };
            }
        }

        public ResponseNewsDetailModel GetNewsDetail(string uri,int id=0, bool amp = false)
        {
            try
            {
                uri = string.Format("{0}/{1}/{2}?{3}={4}", uri, "contents",id,"amp",amp);

                WebRequest request = WebRequest.Create(uri);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                var jsonString = reader.ReadToEnd();

                reader.Close();
                response.Close();

                var news = JsonConvert.DeserializeObject<ResponseNewsDetailModel>(jsonString);
                return news;
            }

            catch (Exception ex)
            {
                return new ResponseNewsDetailModel() { IsSuccess = false, Message = "Beklenmedik bir hata ile karşılaşıldı." };
            }
        }
    }
}
